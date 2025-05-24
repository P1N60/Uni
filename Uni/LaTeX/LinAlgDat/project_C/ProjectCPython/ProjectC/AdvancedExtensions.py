# -*- coding: utf-8 -*-
"""
@Project: LinalgDat2022
@File: AdvancedExtensions.py

@Description: Project C Determinant and Gram-Schmidt extensions.

"""

import math
from sys import path
path.append('../Core')
from Matrix import Matrix
from Vector import Vector


Tolerance = 1e-6


def SquareSubMatrix(A: Matrix, i: int, j: int) -> Matrix:
    """
    This function creates the square submatrix given a square matrix as
    well as row and column indices to remove from it.

    Remarks:
        See page 246-247 in "Linear Algebra for Engineers and Scientists"
        by K. Hardy.

    Parameters:
        A:  N-by-N matrix
        i: int. The index of the row to remove.
        j: int. The index of the column to remove.

    Return:
        The resulting (N - 1)-by-(N - 1) submatrix.
    """
    N = A.N_Cols
    B = Matrix(N - 1, N - 1)
    # iterate through all elements in A
    for r in range(N):
        # skip the row if it is the row we want to remove
        if r == i:
            continue
        for c in range(N):
            # skip the column if it is the column we want to remove
            if c == j:
                continue
            # add the element to the correct position
            if r > i and c > j:
                B[r - 1, c - 1] = A[r, c]
            elif r > i:
                B[r - 1, c] = A[r, c]
            elif c > j:
                B[r, c - 1] = A[r, c]
            else:
                B[r, c] = A[r, c]
    return B

def Determinant(A: Matrix) -> float:
    """
    This function computes the determinant of a given square matrix.

    Remarks:
        * See page 247 in "Linear Algebra for Engineers and Scientists"
        by K. Hardy.
        * Hint: Use SquareSubMatrix.

    Parameter:
        A: N-by-N matrix.

    Return:
        The determinant of the matrix.
    """
    N = A.N_Cols
    # if the squaresubmatrix is of size 1, then return that element
    if N == 1:
        return A[0, 0]
    result = 0
    # formula for calculating the determinant recursively
    for j in range(N):
        result += A[0, j] * ((-1) ** (1 + j)) * Determinant(SquareSubMatrix(A, 0, j))
    return result

def VectorNorm(v: Vector) -> float:
    """
    This function computes the Euclidean norm of a Vector. This has been implemented
    in Project A and is provided here for convenience

    Parameter:
         v: Vector

    Return:
         Euclidean norm, i.e. (\sum v[i]^2)^0.5
    """
    nv = 0.0
    for i in range(len(v)):
        nv += v[i]**2
    return math.sqrt(nv)

def SetColumn(A: Matrix, v: Vector, j: int) -> Matrix:
    """
    This function copies Vector 'v' as a column of Matrix 'A'
    at column position j.

    Parameters:
        A: M-by-N Matrix.
        v: size M vector
        j: int. Column number.

    Return:
        Matrix A  after modification.

    Raise:
        ValueError if j is out of range or if len(v) != A.M_Rows.
    """
    M = A.M_Rows
    N = A.N_Cols
    n = v.__len__()
    # raise error if j is out of range or if v.__len__() != A.M_Rows.
    if j < 0 or j >= N or n != M:
        raise ValueError 
    for r in range(M):
        for c in range(N):
            # copy the elements of the vector into A if this is the j'th column
            if c == j:
                A[r, c] = v[r]
    return A

def extract_vector(A: Matrix, j: int) -> Vector:
    M = A.M_Rows
    N = A.N_Cols
    v = Vector(M)
    for i in range(M):
        v[i] = A[i, j]
    return v

def vector_dot_product(v: Vector, y: Vector) -> float:
    result = 0
    for i in range(v.__len__()):
        result += v[i] * y[i]
    return result

def GramSchmidt(A: Matrix) -> tuple:
    """
    This function computes the Gram-Schmidt process on a given matrix.

    Remarks:
        See page 229 in "Linear Algebra for Engineers and Scientists"
        by K. Hardy.

    Parameter:
        A: M-by-N matrix. All columns are implicitly assumed linear
        independent.

    Return:
        tuple (Q,R) where Q is a M-by-N orthonormal matrix and R is an
        N-by-N upper triangular matrix.
    """
    M = A.M_Rows
    N = A.N_Cols
    Q = Matrix(M, N)
    R = Matrix(N, N)
    for j in range(N):
        v = extract_vector(A, j)
        q = Vector(M)
        for i in range(j):
            qi = extract_vector(Q, i)
            R[i, j] = vector_dot_product(qi, v)
            for k in range(M):
                v[k] += -R[i, j] * qi[k]
        R[j, j] = VectorNorm(v)
        for k in range(M):
            q[k] = v[k] / R[j, j]
        SetColumn(Q, q, j)
    return (Q, R)
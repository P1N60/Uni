# -*- coding: utf-8 -*-
"""
@Project: LinalgDat2022
@File: GaussExtensions.py

@Description: Project B Gauss extensions

"""

import math

from sys import path
path.append('../Core')
from Vector import Vector
from Matrix import Matrix

def AugmentRight(A: Matrix, v: Vector) -> Matrix:
    """
    Create an augmented matrix from a matrix and a vector.

    This function creates a new matrix by concatenating matrix A
    and vector v. See page 12 in "Linear Algebra for Engineers and
    Scientists", K. Hardy.

    Parameters:
         A: M-by-N Matrix
         v: M-size Vector
    Returns:
        the M-by-(N+1) matrix (A|v)
    """
    M = A.M_Rows
    N = A.N_Cols
    if v.size() != M:
        raise ValueError("number of rows of A and length of v differ.")

    B = Matrix(M, N + 1)
    for i in range(M):
        for j in range(N):
            B[i, j] = A[i, j]
        B[i, N] = v[i]
    return B

def ElementaryRowReplacement(A: Matrix, i: int, m: float, j: int) -> Matrix:
    """
    Replace row i of A by row i of A + m times row j of A.

    Parameters:
        A: M-by-N Matrix
        i: int, index of the row to be replaced
        m: float, the multiple of row j to be added to row i
        j: int, index or replacing row.

    Returns:
        A modified in-place after row replacement.
    """
    N = A.N_Cols
    # iterate through all columns
    for k in range(N):
        # add the value of the other row multiplied by m
        A[i, k] += A[j, k] * m
    return A

def ElementaryRowInterchange(A: Matrix, i: int, j : int) -> Matrix:
    """
    Interchange row i and row j of A.

    Parameters:
        A: M-by-N Matrix
        i: int, index of the first row to be interchanged
        j: int, index the second row to be interchanged.

    Returns:
        A modified in-place after row interchange
    """
    N = A.N_Cols
    temp = 0
    # iterate through all columns
    for k in range(N):
        # switch positions of the elements
        temp = A[i, k]
        A[i, k] = A[j, k]
        A[j, k] = temp
    return A

def ElementaryRowScaling(A: Matrix, i: int, c: float) -> Matrix:
    """
    Replace row i of A c * row i of A.

    Parameters:
        A: M-by-N Matrix
        i: int, index of the row to be replaced
        c: float, the scaling factor

    Returns:
        A modified in-place after row scaling.
    """
    N = A.N_Cols
    # iterate through all columns in the row
    for k in range(N):
        # multiply each element in the row with 'c'
        A[i, k] = A[i, k] * c
    return A

def ForwardReduction(A: Matrix) -> Matrix:
    """
    Forward reduction of matrix A.

    This function performs the forward reduction of A provided in the
    assignment text to achieve row echelon form of a given (augmented)
    matrix.

    Parameters:
        A:  M-by-N augmented matrix
    returns
        M-by-N matrix which is the row-echelon form of A (performed in-place,
        i.e., A is modified directly).
    """
    M = A.M_Rows
    N = A.N_Cols
    iter = 0
    while M - iter > 1:
        # step 1 from the assignment:
        pivot_column = None
        for j in range(iter, N):
            for i in range(iter, M):
                    if pivot_column == None and A[i, j] != 0:
                        pivot_column = j
        if pivot_column == None:
            iter += 1
            continue
        # step 2 from the assignment:    
        pivot_row = None 
        for i in range(iter, M):
            if A[i, pivot_column] != 0 and pivot_row == None:
                pivot_row = i
        if pivot_row == None:
            iter += 1
            continue
        ElementaryRowInterchange(A, pivot_row, iter)
        pivot_row = iter
        r = A[pivot_row, pivot_column]
        for i in range(1 + iter, M):
            m = A[i, pivot_column] / r
            ElementaryRowReplacement(A, i, -m, pivot_row)
        # step 3 from the assignment:
        # increment iter with 1 and run the loop again
        iter += 1
    return A

def BackwardReduction(A: Matrix) -> Matrix:
    """
    Backward reduction of matrix A.

    This function performs the backward reduction of A provided in the
    assignment text given a matrix A in row echelon form.

    Parameters:
        A:  M-by-N augmented matrix in row-echelon form
    Returns:
        M-by-N matrix which is the reduced form of A (performed in-place,
        i.e., A is modified directly).
    """
    M = A.M_Rows
    N = A.N_Cols
    for i in range(M - 1, -1, -1):
        pivot_column = None
        for j in range(N):
            if A[i, j] != 0:
                pivot_column = j
                break
        if pivot_column is None: 
            continue
        # scale the pivot row to make the pivot element 1
        pivot_value = A[i, pivot_column]
        ElementaryRowScaling(A, i, 1 / pivot_value)
        # delete the pivot column in all rows above the current row
        for k in range(i - 1, -1, -1):
            m = -A[k, pivot_column]
            ElementaryRowReplacement(A, k, m, i)
    return A

def GaussElimination(A: Matrix, v: Vector) -> Vector:
    """
    Perform Gauss elimination to solve for Ax = v.

    This function performs Gauss elimination on a linear system given
    in matrix form by a coefficient matrix and a right-hand-side vector.
    It is assumed that the corresponding linear system is consistent and
    has exactly one solution.

    Hint: combine AugmentRight, ForwardReduction and BackwardReduction!

    Parameters:
         A: M-by_N coefficient matrix of the system
         v: N-size vector v, right-hand-side of the system.
    Return:
         M-size solution vector of the system.
    """
    raise NotImplementedError()
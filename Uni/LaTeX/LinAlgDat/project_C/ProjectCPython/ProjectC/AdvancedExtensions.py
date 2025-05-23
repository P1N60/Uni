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
    raise NotImplementedError()


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
    raise NotImplementedError()


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
    raise NotImplementedError()


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
    raise NotImplementedError()


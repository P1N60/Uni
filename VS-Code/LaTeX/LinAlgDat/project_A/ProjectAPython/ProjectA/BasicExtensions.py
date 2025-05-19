"""
@Project: LinalgDat2023
@File: BasicExtensions.py

@Description: Project A basic extensions.

"""
import math
import sys

sys.path.append('../Core')
from Vector import Vector
from Matrix import Matrix

__author__ = "François Lauze, University of Copenhagen"
__date__ = "3/28/22"
__version__ = "0.0.1"


def AugmentRight(A: Matrix, v: Vector) -> Matrix:
    """
    Create an augmented matrix from a matrix A and a vector v.

    See page 12 in 'Linear Algebra for Engineers and Scientists'
    by K. Hardy.

    :param A: a matrix of size M-by-N.
    :param v: a column vector of size M.

    :return: a matrix of size M-by-(N + 1)
    """
    M = A.M_Rows
    N = A.N_Cols
    B = Matrix(M, N + 1)
    for i in range(M):
        for j in range(N):
            B[i, j] = A[i, j]
    for i in range(M):
        B[i, N] = v[i]

    return B

def MatVecProduct(A: Matrix, v: Vector) -> Vector:
    """
    This function computes the matrix-vector product of a matrix A
    and a column vector v

    See page 68 in "Linear Algebra for Engineers and Scientists"
    by K. Hardy.
    :param A: an M-by-N Matrix.
    :param v: a size N Vector.

    :return: a size M Vector y such that y = A.v
    """
    M = A.M_Rows
    N = A.N_Cols
    y = Vector(M)
    # Iterate through all elements in A and v
    for i in range(M):
        for j in range(N):
            # Have y[row] be the sum of the product of A[row, column] * v[row]
            y[i] += A[i, j] * v[j]
    return y

def MatrixProduct(A: Matrix, B: Matrix) -> Matrix:
    """
    Compute the Matrix product of two given matrices A and B.

    See page 58 in "Linear Algebra for Engineers and Scientists"
    by K. Hardy.

    :param A: an M-by-N Matrix.
    :param B: an N-by-P Matrix.

    :returns: the M-by-P Matrix A*B.
    """
    M = A.M_Rows
    N = A.N_Cols
    P = B.N_Cols
    C = Matrix(M, P)
    # Iterate through all elements in A and B
    for i in range(M):
        for j in range(N):
            for k in range(P):
                # Have C[row, column] be the product of A[row, column] and B[columns, row]
                C[i, k] += A[i, j] * B[j, k]
    return C

def Transpose(A: Matrix) -> Matrix:
    """
    Computes the transpose of a given Matrix.

    See page 69 in "Linear Algebra for Engineers and Scientists"
    by K. Hardy.

    :param A: A M-by-N Matrix.
    :returns: A N-by-M Matrix B such that B = A^T.
    """
    M = A.M_Rows
    N = A.N_Cols
    B = Matrix(N, M)
    # Iterate through all elements in A
    for i in range(M):
        for j in range(N):
            # Have B be A on the 'opposite' side by flipping row and column index
            B[j, i] = A[i, j]
    return B        

def VectorNorm(v: Vector) -> float:
    """
    Computes the Euclidean Vector norm of a given Vector.

    See page 197 in "Linear Algebra for Engineers and Scientists"
    by K.Hardy.

    :param v: An N - dimensional Vector.
    :return: The Euclidean norm of the Vector.
    """
    n = v.__len__()
    norm = 0
    # Iterate through all elements in v
    for i in range(n):
        # Get the sum of all elements squared
        norm += v[i] * v[i]
    # Take the root
    norm = math.sqrt(norm)
    return norm

start_vector = (
Vector.fromArray(
    [0, 0, 0, 1]
))

forward = (
Matrix.fromArray(
    [[0, 0, 1, 0],
     [0, 0, 0, 1],
     [-1, 0, 2, 0],
     [0, -1, 0, 2]
    ]
))

rotate_left = (
Matrix.fromArray(
    [[1, 0, 0, 0],
     [0, 1, 0, 0],
     [1-math.cos(20), math.sin(20), math.cos(20), -math.sin(20)],
     [-math.sin(20), 1-math.cos(20), math.sin(20), math.cos(20)]
    ]
))

rotate_right = (
Matrix.fromArray(
    [[1, 0, 0, 0],
     [0, 1, 0, 0],
     [1-math.cos(20), -math.sin(20), math.cos(20), math.sin(20)],
     [math.sin(20), 1-math.cos(20), -math.sin(20), math.cos(20)]
    ]
))

print(start_vector)
matrix = start_vector
matrix = MatVecProduct(forward, start_vector)
print(matrix)
matrix = MatVecProduct(rotate_right, matrix)
print(matrix)
matrix = MatVecProduct(rotate_right, matrix)
print(matrix)
matrix = MatVecProduct(forward, matrix)
print(matrix)
matrix = MatVecProduct(forward, matrix)
print(matrix)
matrix = MatVecProduct(rotate_left, matrix)
print(matrix)
matrix = MatVecProduct(rotate_left, matrix)
print(matrix)
matrix = MatVecProduct(rotate_left, matrix)
print(matrix)
matrix = MatVecProduct(forward, matrix)
print(matrix)

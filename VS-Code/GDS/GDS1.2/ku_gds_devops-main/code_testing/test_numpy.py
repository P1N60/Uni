import numpy as np

def test_matmul():
    x = np.random.randn(5, 10)
    y = np.random.randn(10)
    xy = np.matmul(x, y)
    assert xy.shape == (5,)

def test_int_add():
    x = np.random.randint(0,10)
    y = np.random.randint(1,10)
    assert x+y != 0

def test_np_sin():
    assert np.sin(1) > 0
    assert np.sin(0) == 0
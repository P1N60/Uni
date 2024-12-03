# 1.
X <- sample(1:5, 10000, TRUE)
Y <- sample(1:5, 10000, TRUE)
Z <- abs(X-Y)
table(Z)

# 2.
mean(Z)

# 4.
X1 <- sample(1:5, 10000, TRUE)
X2 <- sample(1:5, 10000, TRUE)
W <- rep(NA, 1000000)
W[X1>2.5] <- X1[X1>2.5]
W[X1<2.5] <- X2[X1<2.5]
table(W)
mean(W)

# 5.
X3 <- sample(1:5, 10000, TRUE)
X4 <- sample(1:5, 10000, TRUE)
W2 <- rep(NA, 1000000)
W2[X1>3] <- X1[X1>3]
W2[X1<=3] <- X2[X1<=3]
table(W2)
mean(W2)

# 6.
X5 <- sample(1:5, 10000, TRUE)
X6 <- sample(1:5, 10000, TRUE)
W3 <- rep(NA, 1000000)
W3[X5>=5] <- X5[X5>=5]
W3[X5<5] <- X6[X5<5]
table(W3)
mean(W3)
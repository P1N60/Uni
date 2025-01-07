# opgave 1.5
U <- runif(10000)
X <- 2^U
mean(X)
var(X)

# opgave 3.1
data <- cement

linreg1 <- lm(styrke ~ tid, data=data)
linreg2 <- lm(logStyrke ~ reciprokTid, data=data)

# plot(linreg2)

# Opgave 3.3
summary(linreg2)
# -0.49762 og 0.02294 (værdier for Beta)
length(data)
length(data$logStyrke)
# Opgave 3.4
sqrt(((mean(data$logStyrke)/length(data$logStyrke))*(1-((mean(data$logStyrke))/length(data$logStyrke)))/length(data$logStyrke)))

# opgave 1.5
U <- runif(10000)
X <- 2^U
mean(X)
var(X)

# --------------------------------------------------------------------------
data <- cement

# opgave 3.1
linreg1 <- lm(styrke ~ tid, data=data)
linreg2 <- lm(logStyrke ~ reciprokTid, data=data)
# plot(linreg2)

# Opgave 3.3
summary(linreg2)
# -0.49762 og 0.02294 (værdier for Beta)

# Opgave 3.4
mx <- mean(data$reciprokTid)
ssdx <- var(data$reciprokTid)*20 # 20 fra: n-1
se <- 0.03276 * sqrt(1/21 + (1/21 - mx)^2/ ssdx) # 0.03276 fra: summary Residual standard error
se

# Opgave 3.5
1.60167-0.49762 * 1/14
predict(linreg2, data.frame(reciprokTid=1/14))
exp(predict(linreg2, data.frame(reciprokTid=1/14)))
exp(1.60167-0.49762 * 1/14)

# Opgave 4.1
lysData <- lysdata
qqnorm(lysData$serieA)
qqnorm(lysData$serieB)

# Opgave 4.2
t.test(lysData$serieB-lysData$serieA)
# 95% konfidensinterval: [-6.538, 77.538]

# Opgave 4.3
abs(mean(lysData$serieA)-mean(lysData$serieB))
# Da forskellen er inden for vores konfidensinterval, fortolker vi estimaterne som ens

# Opgave 4.4
sd(lysData$serieA)/sqrt(20) # 20 er datasættets størrelse

# Opgave 4.5
t.test(lysdata$serieB)
# konfidensinteval for serieB: [299827.4 299884.6]
# 299734.5 er ude for konfidensintervallet, så data'en er ikke rigtig

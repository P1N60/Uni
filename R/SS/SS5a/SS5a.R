setwd("~/GitHub/R/SS/SS5a")
data <- read.table("paydata2017.txt", header=TRUE)
data <- transform(data, logPay=log(Pay))

# 1. Opgave
payMedian <- median(data$Pay)
payAverage <- mean(data$Pay)
paySampleVariance <- var(data$Pay)
paySampleDeviation <- sd(data$Pay)
logPayMedian <- median(data$logPay)
logPayAverage <- mean(data$logPay)
logPaySampleVariance <- var(data$logPay)
logPaySampleDeviation <- sd(data$logPay)

# 2. Opgave
hist(data$Pay, prob=TRUE)
f1 <- function(x) dnorm(x, mean=payAverage, sd=paySampleDeviation)
curve(f1, add=TRUE, col="red", lwd=2.5)

hist(data$logPay, prob=TRUE)
f2 <- function(x) dnorm(x, mean=logPayAverage, sd=logPaySampleDeviation)
curve(f2, add=TRUE, col="red", lwd=2.5)

# For Pay
qqPay <- qqnorm(data$Pay, main="QQ-Plot af Pay")
abline(payAverage, paySampleDeviation, col="red", lwd=2.2, lty=2)
# For LogPay
qqLogPay <- qqnorm(data$logPay, main="QQ-Plot af LogPay")
abline(logPayAverage, logPaySampleDeviation, col="red", lwd=2.2, lty=2)

# 3. Opgave
# med normalfordeling
integrate(f1, 100000, max(data$Pay))
# uden normalfordelingsantagelse
length(data$Pay[data$Pay>=100000])/length(data$Pay)
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

hist(data$logPay, prob=TRUE)
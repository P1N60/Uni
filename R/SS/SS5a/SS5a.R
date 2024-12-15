setwd("~/GitHub/R/SS/SS5a")
data <- read.table("paydata2017.txt", header=TRUE)
data <- transform(data, logPay=log(Pay))

# 1. Opgave
payMedian <- median(data$Pay)
logPayMedian <- median(data$logPay)
payAverage <- sum(data$Pay)/length(data$Pay)
logPayAverage <- sum(data$logPay)/length(data$logPay)
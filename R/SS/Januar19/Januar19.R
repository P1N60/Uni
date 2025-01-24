# opgave 1.6
U <- runif(100000)
X <- sqrt(4/(4-3*U))
mean(sqrt(sin(X)))
0.04+0.17+0.07+0.13+0.1+0.05+0.08+0.03+0.02+0.01

# opgave 3.1
data <- filmdata$Ratio
mean(data)
sd(data)

# opgave 3.2
sqrt((0.2434*(1-0.2434))/length((data)))

# opgave 3.3
linreg <- lm(LogRevenue ~ LogBudget, data=filmdata)
summary(linreg)

qqnorm(filmdata$Revenue)
qqnorm(filmdata$LogBudget)

# opgave 3.4 
# kan opserveres i summary

# opgave 3.5
3.86880+0.81215*log(40000000)

# opgave 3.6

# opgave 3.7
OtherData <- subset(filmdata, Language=="OTHER")
qqnorm(OtherData$Ratio)
qqnorm(OtherData$LogRatio)

# opgave 3.8

# opgave 3.9
t.test(LogRatio ~ Language, data=filmdata, var.equal=TRUE)
EnData <- subset(filmdata, Language=="EN")
t.test(EnData$LogRatio, OtherData$LogRatio, var.equal=TRUE)

# opgave 3.10
length(OtherData$LogRatio)
length(EnData$LogRatio)
(125*var(OtherData$LogRatio) + 3094*var(EnData$LogRatio))/(125+3094)
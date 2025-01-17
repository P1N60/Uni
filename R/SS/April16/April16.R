data <- fatty8cc

# Opgave 3.1
flødeOst = subset(data$absorp, data$type == 'creamCheese')
length(flødeOst)

# Opgave 3.2
mean(flødeOst)
var(flødeOst)

# Opgave 3.3
t.test(flødeOst, conf.level = 0.95)

# Opgave 3.4
fløde <- subset(data$absorp, data$type == 'cream')
t.test(fløde, flødeOst)

# Opgave 3.5
mean(fløde)
mean(flødeOst)

# Opgave 3.6
ssdFløde <- (length(fløde)-1)*var(fløde)
ssdFlødeOst <- (length(flødeOst)-1)*var(flødeOst)

(ssdFløde + ssdFlødeOst)/(length(data$type)-2)

# Opgave 4.1
data <- gasData
mean(data$temp)

# Opgave 4.2
linreg <- lm(gas ~ temp, data)
plot(fitted(linreg),residuals(linreg))
abline(h=0,lty=2)

# Opgave 4.3
#Punkterne ligger omkring 0, og varierer fra 0 med omkring 8 (variansen).

# Opgave 4.4
summary(linreg)
#Aflæs

# Opgave 4.5
confint(linreg)

# Opgave 4.6
confint(linreg, level=0.9)

# Opgave 4.7
summary(linreg)
#Residual standard error: 8.375

# Opgave 4.8
newdata <- data.frame(temp=5)
predict(linreg, newdata, interval = "prediction")

# Opgave 4.9
newdata <- data.frame(temp=2)
predict(linreg, newdata, interval = "prediction")

# Opgave 4.10
var(data$temp)*((length(data$gas)-1)*(-11.0141))
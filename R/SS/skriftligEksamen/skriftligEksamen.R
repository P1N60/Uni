data <- jan2025

# Opgave 1.1
qqnorm(data$alder)
qqnorm(data$reaktionstid)
# Kun responsvariablen skal være normalfordelt?

# Opgave 1.2 
linreg <- lm(reaktionstid ~ alder, data)
summary(linreg)
(160.7)^2

# Opgave 1.3
# p-værdi fra summary eller den her?
t.test(data$reaktionstid,data$alder,data=jan2025,var.equal=TRUE)
# svarede den fra summary

# Opgave 1.4
# Estimat for alder: 1.9781
confint(linreg)

# Opgave 1.5
arrangøren <- data.frame(alder=53)
predict(linreg, arrangøren, interval="p")

# Opgave 1.6
ssdKvinde <- (128-1)*24931
ssdMand <- (93-1)*30137

(ssdKvinde + ssdMand)/(128+93-2)

# Opgave 1.7
sqrt(27118)
(164.6754)*(sqrt((1/128)+(1/93)))

# Opgave 1.8
26+qt(0.95, df = 128+93)*22.4377
26-qt(0.95, df = 128+93)*22.4377
# OMG Jeppe du er bare en gud!

# Opgave 1.9
n1 <- 128
n2 <- 93
m1 <- 870
m2 <- 844
s <- sqrt(27118)
SE <- s * sqrt(1/n1 + 1/n2)
Tobs <- (m1 - m2) / SE
p_value <- 2 * pt(-Tobs, df = n1 + n2 - 2)
c(Tobs, p_value)

# Opgave 3.2
X <- runif(10000,-1,1)
Y <- runif(10000,-1,1)
Z <- (3/2)*(X+Y)^2
plot(X[Z],Y[Z])
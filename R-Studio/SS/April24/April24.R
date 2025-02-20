library(MASS)
data(hills)
hills$climb=NULL

data <- hills

# Opgave 3.1
linreg <- lm(data$time ~ data$dist)
summary(linreg)
# Alpha = -4.84, Beta = 8.33

# Opgave 3.2
# I summart står der: "Residual standard error: 19.96"
19.96^2

# Opgave 3.3
8.3305*3 # Beta*3, da Beta beskriver distancen

# Opgave 3.4
confint(linreg)
1/7.069964*1.609*60 #øvre
1/9.590948*1.609*60 #nedre

# Opgave 3.5
newdata <- data.frame(dist=6)
predict(linreg, newdata, interval="c")
# Det hyppigeste interval

# Opgave 3.6
hills6 <- subset(hills, dist==6)
t.test(hills6$time) # konfidens interval: [34.24077; 44.93398]
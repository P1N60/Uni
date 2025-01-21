data <- happiness

# Opgave 3.1
linreg <- lm(score ~ tax, data)
summary(linreg)
# 0.018828 er estimatet for tax. Foretegnet tyder, at når glæden stiger, så stiger tax også.
confint(linreg)

# Opgave 3.2
# Der er en sammenhæng mellem lykkescoren og højeste personskatteprocent, da hældningen af vores lm er inde for vores konfidensinterval.
# Nulhypotesen forkastes.

# Opgave 3.3
plot(fitted(linreg),residuals(linreg))
abline(h=0,lty=2)

# Opgave 3.4
danmarkdata <- data.frame(tax=55.90)
finlanddata <- data.frame(tax=51.27)
koef <- abs(danmarkdata-finlanddata)
koef
4.63 * confint(linreg)["tax",]
# 95%-konfidensinterval: [0.0003456798, 0.1740053171]

# 
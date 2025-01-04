setwd("~/GitHub/R/SS/Juni23")
data <- energiforbrug

# opgave 3.1
# forbrug er responsvariabel og bnp er forklarende variable
lineærReg <- lm(data$forbrug ~ data$bnp, data)
summary(lineærReg)
# Vi aflæser β til 0,02602 
# Vi finder konfidensintervallet via confint():
confint(lineærReg)
# Vi aflæser 95% konfidensintervallet til [0,01898; 0,03307]
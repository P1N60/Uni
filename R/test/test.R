getwd()
setwd("C:/Users/Gamer/Documents/GitHub/R/test")

blodtryk <- read.table("blodtryk.txt", header=TRUE)

plot(blodtryk, blodtryk, main = "Sammenhæng mellem alder og blodtryk")

model <- lm(Alder ~ Blodtryk, data = blodtryk)
model
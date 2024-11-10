# Min orientering fra 1-100:
fordelingspolitisk = 53
værdipolitisk = 45

# Tegning af plot, samt akser og mit punkt
plot(fordelingspolitisk, 
     værdipolitisk,
     xlim = c(1, 100),
     ylim = c(1, 100),
     xlab = "Fordelingspolitisk",
     ylab = "Værdipolitisk",
     type = "b",
     axes = TRUE)

plotType = "b"
# Afstand mellem punkt og partinavn i pixels
partinavnoffset <- 3

lines(c(1,50), c(50,50), col="red", type = plotType)
lines(c(50,100), c(50,50), col="blue", type = plotType)
lines(c(50,50), c(1,50), col="green", type = plotType)
lines(c(50,50), c(50,100), col="purple", type = plotType)

text(fordelingspolitisk,
     værdipolitisk - partinavnoffset,
     labels = "Mig")

# Andre
partiFordeling = 
  c(12,      30,   40,    42,      47,      52,       55,      60,      85)
partiVærdi = 
  c(83,      75,   65,    91,      87,      55,       42,      52,      45)
partiInitial = 
  c("E",    "SF",  "A",   "Å",    "RV",     "M",      "C",     "V",    "LA")
partiFarve = 
  c("red", "red", "red", "green", "purple", "purple", "green", "blue", "cyan")

i <- 1
while (i <= length(partiInitial)) {
  lines(partiFordeling[i], partiVærdi[i], col = partiFarve[i], type = "b")
  text(partiFordeling[i], partiVærdi[i] - partinavnoffset, col = partiFarve[i], labels = partiInitial[i])
  i <- i + 1
}










# Min orientering fra 1-100:
fordelingspolitisk = 53
værdipolitisk = 45

# SF
sff = 30
sfv = 65

# SF
laf = 85
lav = 44

# Mig
plot(fordelingspolitisk, 
     værdipolitisk,
     xlim = c(1, 100),
     ylim = c(1, 100),
     xlab = "Fordelingspolitisk",
     ylab = "Værdipolitisk",
     type = "b",
     axes = TRUE)

lines(c(1,50), c(50,50), col="red", type = "b")
lines(c(50,100), c(50,50), col="blue", type = "b")
lines(c(50,50), c(1,50), col="green", type = "b")
lines(c(50,50), c(50,100), col="pink", type = "b")

text(fordelingspolitisk,
     værdipolitisk - 6,
     labels = "Mig")

# SF
lines(sff, sfv, col = "red", type = "b")
text(sff, sfv - 6, col = "red", labels = "SF")

# LA
lines(laf, lav, col = "cyan", type = "b")
text(laf, lav - 6, col = "cyan", labels = "LA")
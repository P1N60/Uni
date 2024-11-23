setwd("~/Documents/GitHub/R/SS/SS12")
ssData <- read.table("ss1920-udenhold.txt", header=TRUE)

ssData <- transform(ssData, TSek=Min*60+Sek)

studier <- c("Mat", "ML", "Andet")

hist(ssData$TSek, main=paste("Studie = Alle - Mean:", mean(ssData$TSek, na.rm=TRUE)))

for (studie in studier){
  hist(ssData$TSek[ssData$Studie == studie],
  main=paste(paste("Studie = ", studie, "- Mean: "), mean(ssData$TSek[ssData$Studie == studie], na.rm=TRUE)))
}
# SS.4 (Vektorer, gennemsnit, median, [])
R <- c(2.27, 1.98, 1.69, 1.88, 1.64, 2.14)
H <- c(8.28, 8.04, 9.06, 8.70, 7.58, 8.34)
volume <- 1/3*pi*R^2*H
average <- sum(volume)/length(volume)
median <- volume[length(sort(volume))/2]
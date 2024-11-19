open System.IO

let txt = File.CreateText "out.txt"

txt.Write "Lol"

txt.Close
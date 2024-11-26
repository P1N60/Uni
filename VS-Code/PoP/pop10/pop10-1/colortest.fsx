#r "nuget:DIKU.Canvas"
open Canvas
open Color

type state = color // state is a color

let w, h = 600, 600 // window size

let draw (s: state): Picture =
    filledRectangle s w h
    |> make

let react _ (ev: Event) : state option =
    match ev with
    | LeftArrow  -> printfn "Going red!"; Some red
    | RightArrow -> printfn "Going blue!"; Some blue
    | DownArrow  -> printfn "Going green!"; Some green
    | UpArrow    -> printfn "Going yellow!"; Some yellow
    | _          -> None // ignore event, state is not updated

let initialState = red // First state drawn by draw
let delayTime = None  // no delay time

interact "ColorTest" w h delayTime draw react initialState
#r "nuget:DIKU.Canvas"
open Canvas
open Color

type state = float * float // state is a color

let w, h = 600, 600 // window size

let draw (s: state) : Picture =
    let (x, y) = s
    filledRectangle blue (float (w/10)) (float (h/10))
    |> translate x y
    |> make
    

let react (s: state) (ev: Event) : state option =
    let (x,y) = s
    let speed = 10.0
    match ev with
    | LeftArrow  -> 
        printfn "Going left"
        Some (x-speed,y)
    | RightArrow -> 
        printfn "Going right"
        Some (x+speed,y)
    | DownArrow  -> 
        printfn "Going down"
        Some (x,y+speed)
    | UpArrow    -> 
        printfn "Going up"
        Some (x,y-speed)
    | _ -> None // ignore event, state is not updated

let initialState = (float (w/2)), (float (h/2)) // First state drawn by draw
let delayTime = None  // no delay time

interact "ColorTest" w h delayTime draw react initialState
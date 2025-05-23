module Vectors

    type Vec = float*float

    let add ((v1x,v1y) : Vec) ((v2x,v2y) : Vec) : Vec = (v1x + v2x, v1y + v2y)

    let sub ((v1x,v1y) : Vec) ((v2x,v2y) : Vec) : Vec = (v1x - v2x, v1y - v2y)

    let scale ((vx,vy) : Vec) (c : float) : Vec =
        (c * vx, vy * c)

    let div ((vx,vy) : Vec) (c : float) : Vec =
        if c = 0 then (infinity, infinity)
        else (vx / c, vy / c)

    let rot ((vx,vy) : Vec) (r : float) : Vec =
        (vx * cos(r) - vy * sin(r), vx * sin(r) + vy * cos(r))

    let dist (v1 : Vec) (v2 : Vec) : float =
        sub v1 v2 ||> fun x y -> let (dx,dy) = (x, y) in sqrt (dx*dx + dy*dy)

    let len (v : Vec) : float = dist v (0, 0)

    let norm (v : Vec) : Vec = div v (len v)

    let ang ((vx, vy) : Vec) : float = atan2 vy vx
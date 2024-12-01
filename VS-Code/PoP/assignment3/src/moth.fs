module RandomGenerator =
    let rnd = new System.Random()

    let GetRandomNum (n:float) = n*rnd.NextDouble ()
    
    let GetRandomRange (n1:float) (n2:float) = n1 + GetRandomNum (n2-n1)
    
    let GetRandomPosition (n11:float) (n12:float) (n21:float) (n22:float) : Vectors.Vec = (GetRandomRange n11 n12, GetRandomRange n21 n22)
    
    let GetRandomUnitVector() : Vectors.Vec =
        Vectors.norm (GetRandomPosition -1.0 1.0 -1.0 1.0)
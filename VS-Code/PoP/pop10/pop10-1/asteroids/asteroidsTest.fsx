namespace Asteroids

open System
open Xunit
open Asteroids
open RandomGenerator
open Vectors

module AsteroidsTests =
    // Sample test object for use in tests
    let sampleObject:Object<int> = (Asteroid, IComparableWrapper<int>(1), (0.0, 0.0), 0.0, 0.0, 10.0, 0.0, 5.0, 0.0) //PrimitiveTree simulated by ints

    [<Fact>]
    let ``cyclic function wraps values correctly`` () =
        Assert.Equal(5.0, cyclic 0.0 10.0 15.0)
        Assert.Equal(0.0, cyclic 0.0 (2.0*Math.PI) (2.0*Math.PI))
        Assert.Equal(Math.PI, cyclic 0.0 (2.0*Math.PI) -Math.PI)

    [<Fact>]
    let ``makeObject should create an object with correct properties`` () =
        let ship = makeObject SpaceShip 1 5.0
        Assert.Equal(SpaceShip, kind ship)
        Assert.Equal(1, shape ship)
        Assert.Equal(5.0, radius ship)
        let bullet = makeObject Bullet 2 4.0
        Assert.Equal(Bullet, kind bullet)
        Assert.Equal(2, shape bullet)
        Assert.Equal(4.0, radius bullet)
        let asteroid = makeObject Asteroid 3 3.0
        Assert.Equal(Asteroid, kind asteroid)
        Assert.Equal(3, shape asteroid)
        Assert.Equal(3.0, radius asteroid)

    [<Fact>]
    let ``Object property getters return correct values`` () =
        Assert.Equal(Asteroid, kind sampleObject)
        Assert.Equal(1, shape sampleObject)
        Assert.Equal((0.0, 0.0), position sampleObject)
        Assert.Equal(0.0, orientation sampleObject)
        Assert.Equal(0.0, heading sampleObject)
        Assert.Equal(10.0, speed sampleObject)
        Assert.Equal(0.0, acceleration sampleObject)
        Assert.Equal(5.0, radius sampleObject)

    [<Fact>]
    let ``Object property setters sets correct values`` () =
        Assert.Equal(SpaceShip, setKind SpaceShip sampleObject |> kind)
        Assert.Equal(10, setShape 10 sampleObject |> shape) // Dummy value for PrimitiveTree
        Assert.Equal((10.0,3.5), setPosition (10.0,3.5) sampleObject |> position)
        Assert.Equal(33.0, setOrientation 33 sampleObject |> orientation)
        Assert.Equal(65.0, setHeading 65 sampleObject |> heading)
        Assert.Equal(7.0, setSpeed 7.0 sampleObject |> speed)
        Assert.Equal(6.5, setAcceleration 6.5 sampleObject |> acceleration)
        Assert.Equal(3.2, setRadius 3.2 sampleObject |> radius)

    [<Fact>]
    let ``accelerate increases acceleration within bounds`` () =
        let acceleratedObject = accelerate 2.0 sampleObject
        printfn "%A" acceleratedObject
        Assert.Equal(2.0, acceleration acceleratedObject)

        let maxAcceleratedObject = accelerate 10.0 sampleObject
        Assert.Equal(5.0, acceleration maxAcceleratedObject) // Max acceleration is 5.0

    [<Fact>]
    let ``rotate changes orientation correctly`` () =
        let rotatedObject = rotate (Math.PI/2.0) sampleObject
        Assert.Equal((Math.PI/2.0), orientation rotatedObject) 

        let wrappedOrientation = rotate ((2.0*Math.PI)+0.1) sampleObject
        // equal to 5 decimal places
        Assert.Equal(0.1, orientation wrappedOrientation, 5) // ((2.0*Math.PI)+0.1) % (2.0*Math.PI) = 0.1

    [<Fact>]
    let ``move updates position and speed`` () =
        let a = 2.0
        let dt = 0.5
        let obj = setAcceleration a sampleObject
        let p = position obj
        let s = speed obj
        let h = heading obj
        let v = (dt*s*cos h,dt*s*sin h)
        let newP = (fst p + fst v, snd p + snd v)
        let newS = s + dt*a
        let state = Set.singleton obj
        let updatedState = move dt (0.0, 100.0) (0.0, 100.0) state
        let updatedObject = updatedState |> Set.toList |> List.head
        Assert.Equal(newP, position updatedObject)
        Assert.Equal(newS, speed updatedObject)

    [<Fact>]
    let ``move clamps speed`` () =
        let s = maxSpeed - 0.1
        let a = 2.0
        let dt = 0.5
        let obj = 
            sampleObject
            |> setAcceleration a 
            |> setSpeed s
        let state = Set.singleton obj
        let updatedState = move dt (0.0, 100.0) (0.0, 100.0) state
        let updatedObject = updatedState |> Set.toList |> List.head
        Assert.Equal(maxSpeed, speed updatedObject)

    [<Fact>]
    let ``move updates position on a torus`` () =
        let dt = 0.2
        let s = 10.0
        let bounds = (0.0,100.0)
        let p = [(1.0,1.0);(99.0,99.0)]
        let h = [0.0;Math.PI/2.0;Math.PI;Math.PI*3.0/2.0]
        let comb = List.allPairs p h
        let res = 
            [
                (3.0,1.0); (1.0,3.0); (99.0,1.0); (1.0,99.0);
                (1.0,99.0); (99.0,1.0); (97.0,99.0); (99.0,97.0)
            ]
        List.iter2 (
            fun (p,h) q -> 
                let state = sampleObject |> setSpeed s |> setPosition p |> setHeading h |> Set.singleton
                let updatedState = move dt bounds bounds state
                let updatedObject = updatedState |> Set.toList |> List.head
                let newP = position updatedObject
                Assert.Equal(fst q, fst newP, 5) // up to 5 decimals
                Assert.Equal(snd q, snd newP, 5) // up to 5 decimals
            ) comb res

    [<Fact>]
    let ``collisionHandling processes collisions correctly`` () =
        let obj1 = makeObject SpaceShip 1 3.0 |> setPosition (0.0,0.0)
        let obj2 = makeObject Asteroid 2 5.0 |> setPosition (1.0,0.0)
        let obj3 = makeObject Bullet 2 2.0 |> setPosition (10.0,0.0)
        let state = Set.ofList [obj1; obj2; obj3]
        let (collidedPairsLst, notCollided) = detectCollisions state
        Assert.True(collidedPairsLst = [(obj1,obj2)] || collidedPairsLst = [(obj2,obj1)])
        Assert.True(Set.contains obj3 notCollided)

        let obj4 = obj3 |> setPosition (0.5,0.0)
        let state2 = Set.ofList [obj1; obj2; obj4]
        let (collidedPairsLst2, notCollided2) = detectCollisions state2
        Assert.True(List.length collidedPairsLst2 = 3)
        Assert.True(Set.count notCollided2 = 0)

module VectorsTests =
    [<Fact>]
    let ``add function sums two vectors correctly`` () =
        let v1 = (1.0, 2.0)
        let v2 = (3.0, 4.0)
        let result = add v1 v2
        Assert.Equal((4.0, 6.0), result)

    [<Fact>]
    let ``sub function subtracts two vectors correctly`` () =
        let v1 = (5.0, 6.0)
        let v2 = (3.0, 2.0)
        let result = sub v1 v2
        Assert.Equal((2.0, 4.0), result)

    [<Fact>]
    let ``scale function multiplies vector by a scalar correctly`` () =
        let v = (2.0, 3.0)
        let scalar = 2.0
        let result = scale v scalar
        Assert.Equal((4.0, 6.0), result)

    [<Fact>]
    let ``div function divides vector by a scalar correctly`` () =
        let v = (6.0, 8.0)
        let scalar = 2.0
        let result = div v scalar
        Assert.Equal((3.0, 4.0), result)

    [<Fact>]
    let ``div function handles division by zero`` () =
        let v = (6.0, 8.0)
        let scalar = 0.0
        let result = div v scalar
        Assert.Equal((infinity, infinity), result) // Should return the original vector

    [<Fact>]
    let ``rot function rotates a vector correctly`` () =
        let v = (1.0, 0.0)
        let angle = Math.PI / 2.0 // 90 degrees in radians
        let result = rot v angle
        Assert.True(Math.Abs(fst result) < 1e-6) // Cos(90 degrees) ~ 0
        Assert.Equal(1.0, snd result)            // Sin(90 degrees) ~ 1

    [<Fact>]
    let ``dist function calculates distance between two vectors correctly`` () =
        let v1 = (0.0, 0.0)
        let v2 = (3.0, 4.0)
        let result = dist v1 v2
        Assert.Equal(5.0, result) // Distance should be 5.0 (3-4-5 triangle)

    [<Fact>]
    let ``len function calculates length of a vector correctly`` () =
        let v = (3.0, 4.0)
        let result = len v
        Assert.Equal(5.0, result) // Length should be 5.0

    [<Fact>]
    let ``norm function normalizes a vector correctly`` () =
        let v = (3.0, 4.0)
        let result = norm v
        let expected = (0.6, 0.8)
        Assert.True(Math.Abs(fst result - fst expected) < 1e-6)
        Assert.True(Math.Abs(snd result - snd expected) < 1e-6)

    [<Fact>]
    let ``ang function calculates angle of a vector correctly`` () =
        let v = (0.0, 1.0)
        let result = ang v
        Assert.Equal(Math.PI / 2.0, result) // 90 degrees in radians

module RandomGeneratorTests =

    [<Fact>]
    let ``GetRandomNum generates a number within the expected range`` () =
        let n = 10.0
        let result = GetRandomNum n
        Assert.InRange(result, 0.0, n)

    [<Fact>]
    let ``GetRandomRange generates a number within the specified range`` () =
        let n1 = 5.0
        let n2 = 15.0
        let result = GetRandomRange n1 n2
        Assert.InRange(result, n1, n2)

    [<Fact>]
    let ``GetRandomPosition generates a vector within the specified range`` () =
        let n11, n12 = 0.0, 10.0
        let n21, n22 = 0.0, 20.0
        let (x, y) = GetRandomPosition n11 n12 n21 n22
        Assert.InRange(x, n11, n12)
        Assert.InRange(y, n21, n22)

    [<Fact>]
    let ``GetRandomUnitVector generates a normalized vector`` () =
        let v = GetRandomUnitVector()
        let length = len v
        Assert.True(Math.Abs(length - 1.0) < 1e-6) // Length should be close to 1.0

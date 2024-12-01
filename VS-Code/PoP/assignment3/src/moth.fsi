module RandomGenerator =
    /// <summary>
    /// Generates a random number between 0 and n.
    /// </summary>
    /// <param name="n">The upper bound for the random number.</param>
    /// <returns>A random float between 0 and n.</returns>
    val GetRandomNum: n: float -> float

    /// <summary>
    /// Generates a random number within a specified range.
    /// </summary>
    /// <param name="n1">The lower bound of the range.</param>
    /// <param name="n2">The upper bound of the range.</param>
    /// <returns>A random float between n1 and n2.</returns>
    val GetRandomRange: n1: float -> n2: float -> float

    /// <summary>
    /// Generates a random position within the specified x and y bounds.
    /// </summary>
    /// <param name="n11">The lower bound for the x-coordinate.</param>
    /// <param name="n12">The upper bound for the x-coordinate.</param>
    /// <param name="n21">The lower bound for the y-coordinate.</param>
    /// <param name="n22">The upper bound for the y-coordinate.</param>
    /// <returns>A random vector (x, y) within the specified bounds.</returns>
    val GetRandomPosition: n11: float -> n12: float -> n21: float -> n22: float -> Vectors.Vec

    /// <summary>
    /// Generates a random unit vector.
    /// </summary>
    /// <returns>A random unit vector with a length of 1.</returns>
    val GetRandomUnitVector: unit -> Vectors.Vec
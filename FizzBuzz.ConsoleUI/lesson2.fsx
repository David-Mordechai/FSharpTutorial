type Shape =
    | Square of side: double
    | Rectangle of width: double * length: double

let getArea (shape: Shape) =
    match shape with
    | Square side -> side * side
    | Rectangle (width, length) -> width * length

let square = Shape.Square 2.0
let rectangle = Shape.Rectangle (2.0, 3.0)
printf $"The area of the square is {getArea square}\n"
printf $"The area of the rectangle is {getArea rectangle}\n"
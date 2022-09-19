module Tut03

open System

// Record Type
// tuple
// Anonymous record

// Product types

type Day = { DayOfTheMonth: int; Month: int }
type Person = { Name: string; Age: int }

// constructor
let david = { Name = "David"; Age = 43 }
let david2 = { Name = "David"; Age = 43 }
let moshe = { Name = "Moshe"; Age = 51 }

let b = david = david2

let incrementAge person =
    { person with Age = person.Age + 1 }
    
let david3 = incrementAge david

type Duo = {Person1: Person; Person2: Person}

let brothers = { Person1 = david; Person2 = moshe }

type Duo' = Person * Person

// tuple
let foo = (david,moshe)

let duo'' = {| Person1 = david; Person2 = moshe |}
let trio = {| duo'' with Person3 = david2 |}
let trio1 = trio

// Sum types 1:25

// Discriminated unions

type Suit =
    | Hearts
    | Clubs
    | Spades
    | Diamonds
    
let yesOrNo bool =
    match bool with
    | true -> "Yes"
    | false -> "No"
    
let yesOrNo' = function
    | true -> "Yes"
    | false -> "No"
    
let isEven = function
    | x when x % 2 = 0 -> true
    | _ -> false
    
let IsEven' x =
    x % 2 = 0
    
let isOne = function
    | 1 -> true
    | _ -> false
    
let isOne' number =
    number = 1
    
let isOne'' =
    (=) 1

let translateFizzBuzz = function
    | "Fizz" -> string 3
    | "Buzz" -> string 5
    | "FizzBuzz" -> string 15
    | x -> x

type NormalRectangle = { Base: double; Height: double }

type Rectangle =
    | Normal of NormalRectangle
    | Square of side:double

module Rectangle =
    let area = function
        | Normal {Base = b; Height = h} -> b * h
        | Square side -> side ** 2.

type Shape =
    | Rectangle of Rectangle
    | Triangle of height: double * _base: double
    | Circle of radius: double
    | Dot

module Shape =
    let area shape =
        match shape with
        | Rectangle rect -> Rectangle.area rect
        | Triangle (h,b) -> h * b / 2.
        | Circle r -> r ** 2. * System.Math.PI
        | _ -> 1.
        
let circle = Circle 1.
let circleArea = Shape.area circle

let triangle = Triangle (2.,4.)
let triangleArea = Shape.area triangle


// Sum types 1:52
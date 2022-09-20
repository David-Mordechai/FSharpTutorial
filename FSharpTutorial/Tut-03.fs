module Tut03

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

// This works with Single Case Pattern matches
// Record types
// Tuples
// Single case Discriminated unions

type OrderId = OrderId of int

let incrementOrderId (OrderId id) =
    OrderId <| id + 1
    
let incrementOrderId' =
    fun (OrderId id) ->
        OrderId <| id + 1
    
let area { Base = b; Height = h } =
    b * h
    
let area' (b,h) = b * h

let translateFizzBuzz' = function
    | "Fizz" -> Some 3
    | "Buzz" -> Some 5
    | "FizzBuzz" -> Some 15
    | _ -> None
    
let hasValue = function
    | Some _ -> true
    | None -> false
    
let inline add x y = x + y

// Collections

// Arrays
// Fixed size
// Mutable
let arr1 = [|1;2;3;4;5|]
let arr2 = [|
               1
               2
               3
               4
               5
           |]
let arr3 = [1..5]
arr1[0] <- 5

// Lists
// Immutable
// Linked list
let list1 = [1;2;3;4;5]
let list2 = [
                1
                2
                3
                4
                5
            ]

let list3 = [1..5] // increment by 1
let list4 = [1 ..2.. 10] // increment by 2

let list5 = [1. .. 0.1 .. 5.] // increment by 0.1
let list6 = ['a' .. 'z']

// // list
// // cons
// type LinkedList<'a> =
//     | ([])
//     | (::) of head:'a * tail:'a // tuple
//     
let empty = []

let addToList x xs =
    x::xs
    
let sampleList = [2;3;4]
let toList = addToList 1 sampleList

let getFirstItem = function
    | x:: _ -> Some x
    | _ -> None
    
let getFirstItem' list =
    List.tryHead list

// this line throws an exception empty list
let x: int list = List.head []

let rec printEveryItem = function // rec means recursive method
    | x::xs -> // x::xs means if there is any item in a list
        printfn $"{x}" // %O means we dont know the type there for print Object type
        printEveryItem xs
    | [] -> ()

printEveryItem [1;2;3;4]

let rec doWithEveryItem f = function // rec means recursive method
    | x::xs -> // x::xs means if there is any item in a list
        f x // %O means we dont know the type there for print Object type
        doWithEveryItem f xs
    | [] -> ()

let printEveryItem' list =
    doWithEveryItem (printfn "%O") list
    
let printEveryItem'' list =
    list
    |> List.iter (printfn "%O") // List.iter is foreach loop
    


let stringifyList (list: int list) =
    list
    |> List.map string
    
let l = 
    [1 .. 10]
    |> stringifyList
    

// Some 42
// Some "42"
let stringOption = 
    Some 43
    |> Option.map string
    
    
// 2.29
// List.fold

let testList = [1..10] // sum
let sum list =
    list
    |> List.fold (+) 0
    
let reduce list =
    list
    |> List.reduce (+)
    
let inline sum' list =
    List.sum list
    
let resultSum' =
    testList
    |> sum'
    
let ResultSum =
    testList
    |> sum
    
let ResultReduce =
    testList
    |> reduce
    
let divideInteger denominator nominator =
    match nominator % denominator with
    | 0 -> Some <| nominator / denominator
    | _ -> None
    
let divideBy2 = divideInteger 2

let bindOption = 
    24  
    |> divideBy2
    |> Option.bind divideBy2
    |> Option.bind divideBy2


// Exceptions

exception CannotConnectException of System.Uri

let handle f =
    try
        f()
    with
    | CannotConnectException _ -> ()
    | :? System.ArgumentException as e -> printf $"%s{e.Message}"
    
raise (CannotConnectException(System.Uri("http://google.com")))

type WithdrawalError =
    | InsufficientFunds of double
    | WrongPIN

type Result<'Ok, 'Error> =
    | Ok of 'Ok
    | Error of 'Error

let result = Error (InsufficientFunds 10.)


//https://www.youtube.com/watch?v=gNARAXJd_tM
//minute 24
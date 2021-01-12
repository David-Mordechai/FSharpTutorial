﻿open System
open FizzBuzz

[<EntryPoint>]
let main argv =
    let input = argv.[0]
    match Int32.TryParse input with
    | false, _ -> printfn "%s is not a valid intenger." input
    | true, number -> 
        match 1 <= number && number <= 4000 with
        | false -> printfn "You entered %i. Please enter a number between 1 and 4000" number
        | true ->
            [1 .. number]
            |> List.map (fun n -> (n, n % 3, n % 5))
            |> List.map (function
                | (_,0,0) -> "FizzBuzz"
                | (_,0,_) -> "Fizz"
                | (_,_,0) -> "Buzz"
                | (n,_,_) -> string n)
            |> String.concat "\n"
            |> printfn "Here is the output:\n%s"


    Application.application Console.ReadLine Console.WriteLine ()

    0 
    
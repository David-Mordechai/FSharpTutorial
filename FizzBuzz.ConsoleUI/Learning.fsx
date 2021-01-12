open System
open System.Threading

let currentTime () = 
    DateTime.Now

printfn "Time = %O" (currentTime())

Thread.Sleep 2000

printfn "Time = %O" (currentTime())

currentTime()
    |> printfn "Time = %O"

Thread.Sleep 2000

currentTime()
    |> printfn "Time = %O"

let list = [1;2;3]
1::list


let getFirstItem = function 
    | y::xs -> Some y
    | _ -> None

getFirstItem list
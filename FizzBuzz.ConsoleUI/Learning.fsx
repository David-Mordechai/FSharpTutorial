open System
open System.Threading

let currentTime () = 
    DateTime.Now

printfn $"Time = {currentTime()}"

Thread.Sleep 2000

printfn $"Time = {currentTime()}"

currentTime()
    |> printfn "Time = %O"

Thread.Sleep 2000

currentTime()
    |> printfn "Time = %O"

let list = [1;2;3]
1::list


let getFirstItem = function 
    | y::_ -> Some y
    | _ -> None

getFirstItem list
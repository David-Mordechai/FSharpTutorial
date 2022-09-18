module Tut01

let myOne = 1

let hello = "hello"

let letterA = 'a'

let isEnabled = true

let isTrue = isEnabled = true

let add x y = x + y
let add' = fun x y -> x + y
let add'' x = fun y -> x + y

let add5 x =
    let five = 5
    x + five
    
let add5' = add 5

let operation number = (2. * (number + 3.)) ** 2.

let add3  = (+) 3. 
let times2  = (*) 2.
let pow2  number = number ** 2.

let operation' number = pow2(times2(add3 number))

let operation'' number =
    number
    |> add3
    |> times2
    |> pow2
 
let operation''' =
    add3
    >> times2
    >> pow2
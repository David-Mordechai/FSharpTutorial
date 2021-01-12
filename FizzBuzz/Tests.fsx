#load "Library.fs"
open FizzBuzz

Parser.tryParse "2"
Parser.tryParse "Tomato"

open Validator

ValidNumber.tryValidateNumber 5
ValidNumber.tryValidateNumber 0
ValidNumber.tryValidateNumber 4500

ValidNumber.tryValidateNumber 20
    |> Option.map FizzBuzz.getFizzBuzzString
namespace FizzBuzz

module Application =
    open Domain

    type Input = unit -> string
    type Output = string -> unit

    let execute =
        Domain.execute
            Parser.tryParse
            Validator.ValidNumber.tryValidateNumber
            FizzBuzz.getFizzBuzzString

    let application (input: Input) (output: Output) =
        fun () ->
            output "Please enter a number between 1 and 4000"
            input ()
            |> execute
            |> function
                | Ok s -> 
                    $"Here is the output:\n%s{s}"
                    |> output
                | Error (ParserError (NotANumber s)) ->
                    $"%s{s} is not an integer"
                    |> output
                | Error (ValidatorError (InvalidNumber num)) ->
                    $"You entered %i{num}. Please enter valid integer between 1 and 4000."
                    |> output
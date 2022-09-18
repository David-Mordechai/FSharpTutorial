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


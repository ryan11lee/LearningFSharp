// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp
(*
open System

let add a b =
    a + b
let c = add 2 3

let d = add 2 //partial application of curry function

let e = d 4

*)

let quote symbol s =
    sprintf "%c%s%c" symbol s symbol //returns for another function as opposed to print
    
let singleQuote  = quote '\''

let doubleQuote = quote '"'

[<EntryPoint>]
let main argv =
    printfn "%s" (singleQuote "It was the best of times it was the worst of times.")
    printfn "%s" (doubleQuote "It was the best of times it was the worst of times.")
   // printfn "e: %i" e
    0 // return an integer exit code
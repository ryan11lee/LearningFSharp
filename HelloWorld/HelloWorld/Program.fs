open System

let sayHello person =
    printfn "Hello %s from my first F# program" person

let isValid person =
    not(String.IsNullOrWhiteSpace person) |> not

let isAllowed person =
    person <> "eve"
    
[<EntryPoint>]
let main argv =
    argv
    |> Array.filter isValid
    |> Array.filter isAllowed
    |> Array.iter sayHello
    printfn "Nice to meet you"
    0
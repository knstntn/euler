open System

let main = 
    let n = Console.ReadLine() |> int

    let rec fib x = 
        match x with
        | 1 -> 0
        | 2 -> 1
        | n -> fib (n - 1) + fib (n - 2)

    printfn "%d" <| fib n
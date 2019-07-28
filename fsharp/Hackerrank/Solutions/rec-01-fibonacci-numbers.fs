namespace Hackerrank.Solutions

module Fibonacci = 
    let rec private fib x = 
        match x with
        | 1 -> 0
        | 2 -> 1
        | n -> fib (n - 1) + fib (n - 2)
    
    let public Do () = 
        System.Console.ReadLine() |> int |> fib |> printfn "%d"
        ()
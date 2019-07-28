namespace Hackerrank.Solutions

open System

module SolveMeFirst =
    let public Do () = 
        let a = Console.ReadLine () |> int
        let b = Console.ReadLine () |> int
        printfn "%d" (a+b)
        ()
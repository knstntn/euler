namespace Hackerrank.Solutions

open System

module HelloWorld = 
    let public Do () = 
        Console.ReadLine() |> ignore
        printfn "Hello World"
        ()
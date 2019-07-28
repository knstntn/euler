namespace Hackerrank.Solutions

open System

module HelloWorldNTimes = 
    let public Do () = 
        let n = Console.ReadLine () |> int
        seq {1..n} |> Seq.iter (fun _ -> printfn "Hello World")
        ()
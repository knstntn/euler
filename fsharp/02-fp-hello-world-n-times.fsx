open System

let main = 
    let n = Console.ReadLine() |> int
    seq {1..n} |> Seq.iter (fun _ -> printfn "Hello World")
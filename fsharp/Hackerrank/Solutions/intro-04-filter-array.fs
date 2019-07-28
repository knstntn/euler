namespace Hackerrank.Solutions

open System

module FilterArrays = 
    let rec private readLines () = seq {
        let line = Console.ReadLine ()
        if not (String.IsNullOrEmpty line) then
            yield (line |> int)
            yield! readLines ()
    }

    let public Do () = 
        let n = Console.ReadLine () |> int
        readLines () 
            |> Seq.toList 
            |> List.filter (fun x -> x < n)
            |> List.iter (fun x -> printfn "%d" x)
        ()
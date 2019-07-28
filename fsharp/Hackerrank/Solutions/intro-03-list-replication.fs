namespace Hackerrank.Solutions

open System

module ListReplication = 
    let rec private readLines () = seq {
        let line = Console.ReadLine()
        if not (String.IsNullOrEmpty line) then
            yield line
            yield! readLines ()
    }

    let private printSeq sequence num = 
         Seq.iter (fun _ -> printfn "%s" num) sequence

    let public Do () = 
        let n = Console.ReadLine() |> int
        let sequence = seq {1..n}
        readLines () |> Seq.toList |> List.iter (fun x -> printSeq sequence x)
        ()
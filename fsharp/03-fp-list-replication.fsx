open System

let main = 
    let n = Console.ReadLine() |> int
    let arr =
        [
            let mutable key = Console.ReadLine()
            while not (key = null) do
                yield key
                key <- Console.ReadLine()
        ]
        
    arr |> List.iter (fun x -> seq {1..n} |> Seq.iter (fun _ -> printfn "%s" x))
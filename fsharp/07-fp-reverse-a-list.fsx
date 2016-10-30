open System

let main = 
    let rec readlines = seq {
        let line = Console.ReadLine()
        if line <> null then
            yield line |> int
            yield! readlines
    } 
 
    readlines
        |> Seq.mapi (fun i x -> (i, x))
        |> Seq.sortByDescending (fun x -> fst x) 
        |> Seq.iter (fun x -> printfn "%d" <| snd x)
    
    0
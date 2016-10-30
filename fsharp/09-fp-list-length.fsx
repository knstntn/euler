open System

let main = 
    let rec readlines = seq {
        let line = Console.ReadLine()
        if line <> null then
            yield line |> int
            yield! readlines
    } 
 
    let cnt = readlines |> Seq.fold (fun count _ -> count + 1) 0 
    
    printfn "%d" cnt
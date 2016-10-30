open System

let main = 
    let rec readlines = seq {
        let line = Console.ReadLine()
        if line <> null then
            yield line |> int
            yield! readlines
    } 
 
    let sum = readlines
            |> Seq.filter (fun x -> (x % 2) <> 0) 
            |> Seq.sum
    
    printfn "%d" sum
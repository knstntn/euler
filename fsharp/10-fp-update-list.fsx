open System

let main = 
    let rec readlines = seq {
        let line = Console.ReadLine()
        if line <> null then
            yield line |> int |> Math.Abs
            yield! readlines
    } 
 
    readlines |> Seq.iter (fun x -> printfn "%d" x) 
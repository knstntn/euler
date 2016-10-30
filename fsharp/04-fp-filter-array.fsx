open System

let main = 
    let x = Console.ReadLine() |> int
    let arr =
        [
            let mutable key = Console.ReadLine()
            while not (key = null) do
                yield key |> int
                key <- Console.ReadLine()
        ]
    let filter n = 
        match n with
        | num when num < x -> printfn "%d" num
        | _ -> ()
        
    arr |> List.iter filter
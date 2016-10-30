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
        
    arr
    |> List.mapi (fun i x -> (i, x)) 
    |> List.filter (fun x -> (fst x % 2) = 0)
    |> List.iter (fun x -> printfn "%s" <| snd x)
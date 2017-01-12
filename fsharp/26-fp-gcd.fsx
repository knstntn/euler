open System

let main = 
    let arr = Console.ReadLine().Split [|' '|] |> Array.map (fun x -> int x)
    let x = arr.[0]
    let y = arr.[1]

    let rec gcd x y = 
        match (x, y) with
        | (a, 0) -> a
        | (a, b) when a = b -> a
        | (a, b) when a > b -> gcd b (a%b)
        | (a, b) when a < b -> gcd a (b%a)

    printfn "%d" <| gcd x y
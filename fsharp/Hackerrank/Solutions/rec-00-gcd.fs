namespace Hackerrank.Solutions

module GCD = 
    let rec private gcd x y = 
        match (x, y) with
        | (a, 0) -> a
        | (a, b) when a = b -> a
        | (a, b) when a > b -> gcd b (a%b)
        | (a, b) when a < b -> gcd a (b%a)

    let public Do () = 
        let arr = System.Console.ReadLine().Split(' ') |> Array.map int
        let x = arr.[0]
        let y = arr.[1]
        printfn "%d" <| gcd x y
        ()
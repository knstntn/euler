namespace Hackerrank.Solutions

module SumOfOddElements = 
    let Do () = 
        Seq.initInfinite (fun _ -> System.Console.ReadLine ())
            |> Seq.takeWhile ((<>) null)
            |> Seq.map int
            |> Seq.filter (fun x -> (x % 2) <> 0)
            |> Seq.sum
            |> printf "%d"
        ()
namespace Hackerrank.Solutions

module ListLength = 
    let Do () = 
        Seq.initInfinite (fun _ -> System.Console.ReadLine ())
            |> Seq.takeWhile ((<>) null)
            |> Seq.map (fun _ -> 1)
            |> Seq.fold (+) 0 
            |> printfn "%d"
        ()
namespace Hackerrank.Solutions

module FilterPositionsInAList = 
    let Do () = 
        Seq.initInfinite (fun _ -> System.Console.ReadLine ())
            |> Seq.takeWhile ((<>) null)
            |> Seq.mapi (fun i x -> (i, x)) 
            |> Seq.filter (fun x -> (fst x % 2) = 1)
            |> Seq.iter (snd >> printfn "%s")
        ()
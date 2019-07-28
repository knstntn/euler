namespace Hackerrank.Solutions

module ReverseAList = 
    let Do () = 
        Seq.initInfinite (fun _ -> System.Console.ReadLine ())
            |> Seq.takeWhile ((<>) null)
            |> Seq.toList
            |> List.rev
            |> List.iter (fun x -> printfn "%s" x)
        ()
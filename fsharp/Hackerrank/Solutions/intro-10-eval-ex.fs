namespace Hackerrank.Solutions

module EvalEx = 
    let private factorial num = [1..num] |> Seq.fold (*) 1 

    let private ex x = 
        seq {1..9} 
            |> Seq.sumBy (fun n -> (pown x n) / (n |> factorial |> float))
            |> (+) 1.0

    let public Do () = 
        let n = System.Console.ReadLine () |> int
        
        seq {1..n}
            |> Seq.map (fun _ -> System.Console.ReadLine ())
            |> Seq.iter (float >> ex >> printfn "%.4f")
        ()
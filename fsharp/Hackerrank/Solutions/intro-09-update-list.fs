namespace Hackerrank.Solutions

module UpdateList = 
    let Do () = 
        Seq.initInfinite (fun _ -> System.Console.ReadLine ())
            |> Seq.takeWhile ((<>) null)
            |> Seq.iter (int >> System.Math.Abs >> printf "%d")
        ()
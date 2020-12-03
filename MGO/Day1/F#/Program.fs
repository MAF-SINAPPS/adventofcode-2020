// Learn more about F# at http://fsharp.org

open System

[<EntryPoint>]
let main argv =
    let values = System.IO.File.ReadAllLines("input.txt") |> Array.map int
    for i in 0 .. values.Length - 3 do
        for j in i+1 .. values.Length - 2 do
            if(values.[i]+values.[j] = 2020) then
                printfn "(%d, %d) => %d" values.[i] values.[j] (values.[i]*values.[j])
            for k in j+1 .. values.Length - 1 do
                if(values.[i]+values.[j]+values.[k] = 2020) then
                    printfn "(%d, %d, %d) => %d" values.[i] values.[j] values.[k] (values.[i]*values.[j]*values.[k])

    0 // return an integer exit code

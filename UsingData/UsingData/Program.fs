open System
open System.IO


type Student =
    {
        Surname: string
        GivenName: string
        ID: string
        MeanScore: float
        MinScore: float
        MaxScore: float
    }

module Float =
    let tryFromString s =
           if s = "N/A" then
               None
            else
                Some (float s)
    let fromStringOrValue newValue s =
        s
        |> tryFromString
        |> Option.defaultValue newValue
            

module Student =
    
    let namePart (i:int) (s:string)=
        let elements = s.Split(',')
        elements.[i].Trim()    
    let fromString (s:string) = 
        let elements = s.Split('\t')
        let surname = namePart 0 s
        let givenName = namePart 1 s
        let id = elements.[1]
        let scores =
            elements
            |>  Array.skip 2
            |> Array.map (Float.fromStringOrValue 50.0)
        let meanScore = scores |> Array.average
        let maxScore = scores |> Array.max
        let minScore = scores |> Array.min
        {
            Surname = surname
            GivenName = givenName
            ID = id
            MeanScore = meanScore
            MinScore = minScore
            MaxScore = maxScore
        }
    let printSummary (student: Student) =
        printfn "%s\t%s\t%s\t%0.1f\t%.2f\t%0.2f"
            student.Surname student.GivenName student.ID student.MeanScore
            student.MinScore student.MaxScore
let summarize filePath = 
    let rows = File.ReadAllLines filePath
    let studentCount = rows.Length - 1
    printfn "Student Count: %i" studentCount
    rows
    |> Array.skip 1
    |> Array.map Student.fromString
    |> Array.sortBy (fun student -> student.Surname)  
    |> Array.iter Student.printSummary

    
    
    
[<EntryPoint>]
let main argv =
    if argv.Length = 1 then
        let filePath = argv.[0]
        if File.Exists filePath then
            printfn "Processing File %s" filePath
            summarize filePath
            0
        else
            printfn "File not found: %s" filePath
            2
    else
        printfn "Specify File"
        1 // return an integer exit code
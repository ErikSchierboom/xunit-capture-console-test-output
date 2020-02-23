module Tests

open System
open System.Diagnostics
open System.IO
open Xunit
open Xunit.Abstractions

let test () =
    Debug.WriteLine("From debug: " + Random().Next().ToString())
    Trace.WriteLine("From trace: " + Random().Next().ToString())
    Console.WriteLine("From console: " + Random().Next().ToString())
    
    true

type Tests(testOutput: ITestOutputHelper) =
    
    let stringWriter = new StringWriter()
    
    [<Fact>]
    let ``My test`` () =
        Assert.True(test())
        
    [<Fact>]
    let ``My second test`` () =
        Assert.True(test())

    do  
        Console.SetOut(stringWriter)
        Console.SetError(stringWriter)

        Trace.Listeners.Add(new ConsoleTraceListener()) |> ignore
        
    interface IDisposable with 
        member __.Dispose() =
            testOutput.WriteLine(stringWriter.ToString())



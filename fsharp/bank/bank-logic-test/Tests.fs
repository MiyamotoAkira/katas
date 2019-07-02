module Tests

open System
open Xunit
open FsUnit.Xunit
open BankLogic.DomainTypes
open BankLogic.AccountHandling

[<Fact>]
let ``My test`` () =
    {operations = []}
    |> deposit 1000m (DateTime(2012, 1, 10))
    |> deposit 2000m (DateTime(2012, 1, 13)) 
    |> withdrawal 500m (DateTime (2012, 01, 14)) 
    |> printStatement
    |> should equal "\nDate || Credit || Debit || Balance\n14/01/2012 || -500 ||  || 2500\n13/01/2012 ||  || 2000 || 3000\n10/01/2012 ||  || 1000 || 1000"

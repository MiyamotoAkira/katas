namespace BankLogic

open System

module DomainTypes =
    type Operation =
    | Deposit of decimal
    | Withdrawal of decimal

    type OperationRecord =
        {
            operation: Operation;
            date: DateTime;
        }

    type Account =
        {
            operations: OperationRecord list;
        }    


module AccountHandling =
    open DomainTypes

    type OperationWithBalance = {operation: Operation; date: DateTime; balance: Decimal}

    let deposit amount date account =
        { account with operations = {operation = Deposit amount; date = date} :: account.operations}

    let withdrawal amount date account =
        { account with operations = {operation = Withdrawal amount; date = date} :: account.operations}

    let addBalance currentBalance operation = 
        match operation with
        | Deposit amount -> currentBalance + amount
        | Withdrawal amount -> currentBalance - amount

    let calculateRunningBalance account =
        account.operations
        |> List.rev
        |> List.fold (fun (currentBalance, operations) elem -> (addBalance currentBalance  elem.operation, {operation = elem.operation; date=elem.date; balance= addBalance currentBalance  elem.operation}:: operations)) (0m, [])
        |> snd

    let printHeader operations =
        sprintf "Date || Credit || Debit || Balance", operations

    let printOperations (output, operations) =
        output :: (operations
        |> List.map (fun elem ->
            match elem.operation with 
            | Deposit amount -> sprintf "%s ||  || %M || %M" (elem.date.ToShortDateString()) amount elem.balance
            | Withdrawal amount -> sprintf "%s || -%M ||  || %M" (elem.date.ToShortDateString()) amount elem.balance))
        |> List.fold (fun acc elem -> acc + "\n" + elem) ""

    let printStatement account =
        account
        |> calculateRunningBalance
        |> printHeader
        |> printOperations
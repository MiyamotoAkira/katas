namespace Katas

module FizzBuzz = 

    let selector value =
        let divBy3 = value % 3
        let divBy5 = value % 5

        let select value divisions = 
            match divisions with 
            | (0,0) ->  "FizzBuzz"
            | (0,_) -> "Fizz"
            | (_,0) -> "Buzz"
            | _ -> string value
         
        select value (divBy3, divBy5)

    let fizzBuzz iterations =
        let rec fizzy iteration list =
            match iteration with
                | 0 -> list
                | _ ->
                    let head = selector iteration
                    fizzy (iteration-1) (head :: list)
        
        fizzy iterations []

module Tennis =
    type Player = | Player1 | Player2

    type GameState =
        | InProgress of (int * int)
        | Complete of Player

    let newGame = InProgress(0,0)

    let scoringPlayerWillNotWin scoringPlayer p1Score p2Score =
        let difference = p1Score - p2Score
        match scoringPlayer with
        | Player1 when difference = 1 && p1Score >= 4 -> false
        | Player2 when difference = -1 && p2Score >= 4 -> false
        | _ -> true

    let score scoringPlayer p1Score p2Score =
        match scoringPlayer with
        | Player1 -> InProgress(p1Score+1, p2Score)
        | Player2 -> InProgress(p1Score, p2Score+1)

    let getNewScore scoringPlayer currentResult = 
        match currentResult with
        | InProgress(p1Score, p2Score) when scoringPlayerWillNotWin scoringPlayer p1Score p2Score -> score scoringPlayer p1Score p2Score
        | InProgress(_, _) -> Complete scoringPlayer
        | Complete _ -> failwith "The game has already finished"

module Yathzee =
    type Category = 
        |Ones
        |Twos
        |Threes
        |Fours
        |Fives
        |Sixes
        |Pair 
        |TwoPair 
        |ThreeOfAKind 
        |FourOfAKind 
        |SmallStraight 
        |LargeStraight 
        |FullHouse 
        |Yahtzee
        |Chance

    let values = [1; 2; 3; 4; 5; 6;]

    let collect minimumRepetitions dice =
        values 
        |> List.map (fun x -> (x, (dice |> List.filter (fun y -> y = x) |> List.length))) 
        |> List.filter ( fun (_,y) -> y > (minimumRepetitions - 1))

    let calculatePair dice =
        let atLeastPairs = dice |> collect 2
        if atLeastPairs |> List.length > 0
        then
            let biggest = atLeastPairs |> List.reduce (fun max value -> 
                                                        let x1, _ = value
                                                        let x2, _ = max

                                                        if x1 > x2 
                                                        then value
                                                        else max)
            let value, _ = biggest
            value * 2
        else
            0

    /// This is the original version
    let calculateTwoPair dice =
        let atLeastPairs = dice |> collect 2
        if atLeastPairs |> List.length > 1
        then
            atLeastPairs |> List.fold (fun acc elem -> 
                                          let x, _ = elem
                                          acc + (x * 2)) 0
        else
            0
    
    /// slightly more idiomatic
    let calculateTwoPair' dice =
        let atLeastPairs = dice |> collect 2
        match atLeastPairs with
        | head::second::[] -> atLeastPairs |> List.fold (fun acc elem -> 
                                          let x, _ = elem
                                          acc + (x * 2)) 0
        | _ ->   0

    /// This is the original version
    let calculateThree dice =
        let atLeastThree = dice |> collect 3
        if atLeastThree |> List.length = 1
        then
            atLeastThree |> List.fold (fun acc elem -> 
                                          let x, _ = elem
                                          acc + (x * 3)) 0
        else
            0

    /// slightly more idiomatic
    let calculateThree' dice =
        let atLeastThree = dice |> collect 3
        match atLeastThree with 
        | head::[] -> atLeastThree |> List.fold (fun acc elem -> 
                                          let x, _ = elem
                                          acc + (x * 3)) 0
        | _ -> 0


    /// This is the original version
    let calculateFour dice =
        let atLeastFour = dice |> collect 4 
        if atLeastFour |> List.length = 1
        then
            atLeastFour |> List.fold (fun acc elem -> 
                                          let x, _ = elem
                                          acc + (x * 4)) 0
        else
            0
    
    /// slightly more idiomatic
    let calculateFour' dice =
        let atLeastFour = dice |> collect 4
        match atLeastFour with 
        | head::[] -> atLeastFour |> List.fold (fun acc elem -> 
                                          let x, _ = elem
                                          acc + (x * 4)) 0
        | _ -> 0

    let calculateSmall dice =
        let sorted = dice |> List.sort
        let smallStraight = [1;2;3;4;5]
        if sorted |> List.zip smallStraight |> List.forall (fun (v1,v2) -> v1 = v2)
        then 15
        else 0

    let calculateLarge dice =
        let sorted = dice |> List.sort
        let largeStraight = [2;3;4;5;6]
        if sorted |> List.zip largeStraight |> List.forall (fun (v1,v2) -> v1 = v2)
        then 20
        else 0

    let calculateFull dice =
        let collected  = dice |> collect 2
        match collected with
        | (v1,y1) :: (v2,y2) ::[] when (y1 = 2 && y2 = 3) || (y1 = 3 && y2 = 2)-> (v1 * y1) + (v2 * y2)
        | _ -> 0

    let calculateYathzee dice =
        let collected = dice |> collect 5
        match collected with
        | head::[] -> 50
        | _ -> 0

    let calculateChance dice =
        dice |> List.sum

    let calculateSingles dieValue dice =
        dice |> List.filter (fun y -> y = dieValue) |> List.sum

    let calculateScore category d1 d2 d3 d4 d5 =
        let dice = [d1; d2; d3; d4; d5]
        match category with
        | Ones -> calculateSingles 1 dice
        | Twos -> calculateSingles 2 dice
        | Threes -> calculateSingles 3 dice
        | Fours -> calculateSingles 4 dice
        | Fives -> calculateSingles 5 dice
        | Sixes -> calculateSingles 6 dice
        | Pair -> calculatePair dice
        | TwoPair -> calculateTwoPair' dice
        | ThreeOfAKind -> calculateThree' dice
        | FourOfAKind -> calculateFour' dice
        | SmallStraight -> calculateSmall dice
        | LargeStraight -> calculateLarge dice
        | FullHouse -> calculateFull dice
        | Yahtzee -> calculateYathzee dice
        | Chance -> calculateChance dice

module RomanNumerals =
    let getOnesValue digit =
        match digit with
        | '1' -> "I"
        | '2' -> "II"
        | '3' -> "III"
        | '4' -> "IV"
        | '5' -> "V"
        | '6' -> "VI"
        | '7' -> "VII"
        | '8' -> "VIII"
        | '9' -> "IX"
        | _ -> failwith "you have passed an incorrect value"

    let getTensValue digit =
        match digit with
        | '1' -> "X"
        | '2' -> "XX"
        | '3' -> "XXX"
        | '4' -> "XL"
        | '5' -> "L"
        | '6' -> "LX"
        | '7' -> "LXX"
        | '8' -> "LXXX"
        | '9' -> "XC"
        | _ -> failwith "you have passed an incorrect value"

    let getHundredsValue digit =
        match digit with
        | '1' -> "C"
        | '2' -> "CC"
        | '3' -> "CCC"
        | '4' -> "CD"
        | '5' -> "D"
        | '6' -> "DC"
        | '7' -> "DCC"
        | '8' -> "DCCC"
        | '9' -> "CM"
        | _ -> failwith "you have passed an incorrect value"

    let getThousandsValue digit =
        match digit with
        | '1' -> "M"
        | '2' -> "MM"
        | '3' -> "MMM"
        | _ -> failwith "you have passed an incorrect value"

    let getValue digit position =
        match position with
        | 1 -> getOnesValue digit
        | 2 -> getTensValue digit
        | 3 -> getHundredsValue digit
        | 4 -> getThousandsValue digit
        | _ -> failwith "Not implemented.Too big a number"

    let convertToRoman digits =
        let digitList = digits.ToString() |> List.ofSeq
        let rec processDigits remainingDigits convertedRoman =
            let position = remainingDigits |> List.length
            match remainingDigits with
            | digit::tail when digit = '0' -> processDigits tail convertedRoman
            | digit::tail -> processDigits tail (convertedRoman + (getValue digit position))
            | _ -> convertedRoman
        
        processDigits digitList ""  

module Bowling=

    let score roll =
        match roll with
        | 'X' -> 10
        | '/' -> 10
        | '-' -> 0
        | x -> (int)(string x)


    let bowl series =
        let listSeries = series |> Seq.toList

        let rec calculateValue rolls total previous frameCounter =
            match rolls with
            | [] -> total
            | x :: rest ->
                let newFrameCounter =
                    match x with
                    | 'X' -> frameCounter + 2
                    | _ -> frameCounter + 1
                
                let value = 
                    match x with
                    | 'X' when newFrameCounter <= 20 -> (score x) + (score rest.Head) + (score rest.Tail.Head)        
                    | '/' when newFrameCounter <= 20 -> (score x) - previous + (score rest.Head)       
                    | _ when newFrameCounter > 20 -> 0
                    | _ -> score x
                
                calculateValue rest (total+value) value newFrameCounter
        
        calculateValue listSeries 0 0 0

module KarateChop=
    let chop valueToFind array =
        ignore

module Floupia=
    type FluopiaCoins =
        {
            Coins : List<int>
        }

    let processBill bill fluopiaCoins =
        match bill with
        | 0 -> ([],[])
        | _ ->
            let coins = fluopiaCoins.Coins |> List.sort |> List.rev
            let possibleReturn = coins |> List.tryFind (fun x -> x = bill)

            match possibleReturn with
            | Some x -> ([(x, 1)], [])
            | None -> ([],[]) 

        // can I divide by bill by the coin? If so, then the value is bigger otherwise, we can see how many coins we get in return

        //need to keep a minimum.
        //Order from bigger coin to smallest
        //Start on 
        // x = ab + cd+ ef+ gh


namespace Tests

module TestFizzBuzz = 

    open Katas.FizzBuzz
    open NUnit.Framework
    open FsUnit

    [<Test>]
    [<TestCase (1, Result="1")>]
    [<TestCase (3, Result="Fizz")>]
    [<TestCase (5, Result="Buzz")>]
    [<TestCase (6, Result="Fizz")>]
    [<TestCase (10, Result="Buzz")>]
    [<TestCase (15, Result="FizzBuzz")>]
    [<TestCase (30, Result="FizzBuzz")>]
    [<TestCase (23, Result="23")>]
    let ``Passing the selector a value x returns the correct result`` value =
        selector value


    [<Test>]
    [<TestCase (1, Result = [|"1"|])>]
    [<TestCase (2, Result= [|"1"; "2"|])>]
    [<TestCase (5, Result= [|"1"; "2"; "Fizz";"4";"Buzz"|])>]
    [<TestCase (15, Result= [|"1"; "2"; "Fizz";"4";"Buzz";"Fizz";"7";"8";"Fizz";"Buzz";"11";"Fizz";"13";"14";"FizzBuzz"|])>]
    let ``I Pass a number of iterations and get the right result`` iterations =
        fizzBuzz iterations

module TestTennis =

    open Katas.Tennis
    open NUnit.Framework
    open FsUnit

    [<Test>]
    let ``I play a game of tennis``() =
        let points = [Player1; Player2; Player1; Player1; Player2; Player2; Player2; Player1; Player1; Player1]

        let rec playgame options result =
            match options with
            | playerScoring :: tail -> playgame tail (getNewScore playerScoring result)
            | [] -> result

        let result = playgame points newGame

        result |> should equal (Complete Player1)
        //Assert.AreEqual ((Complete (Player1)), result)

    [<Test>]
    let ``A new game should start at 0 0`` ()=
        newGame |> should equal (InProgress (0,0))
        //Assert.AreEqual ((InProgress (0,0)), newGame)

    [<Test>]
    [<TestCase(0,0,1,1,0)>]
    [<TestCase(1,0,1,2,0)>]
    [<TestCase(2,0,1,3,0)>]
    [<TestCase(3,0,1,4,0)>]
    [<TestCase(0,0,2,0,1)>]
    [<TestCase(0,3,2,0,4)>]
    [<TestCase(4,3,2,4,4)>]
    [<TestCase(4,4,2,4,5)>]
    [<TestCase(9,10,1,10,10)>]
    let ``There is some score one player scores the game does not finish`` player1InitialScore player2InitialScore scoringPlayer expectedPlayer1Score expectedPlayer2Score =
        let currentResult = InProgress(player1InitialScore, player2InitialScore)
        let expectedResult = InProgress(expectedPlayer1Score, expectedPlayer2Score)
        let player =
            match scoringPlayer with
            | 1 -> Player1
            | 2 -> Player2
            | _ -> failwith "This is not a valid player" 
        
        let newResult = getNewScore player currentResult

        newResult |> should equal expectedResult

    [<Test>]
    [<TestCase(4,3,1)>]
    [<TestCase(3,4,2)>]
    [<TestCase(12,11,1)>]
    [<TestCase(17,18,2)>]
    let ``There is some score one player scores and wins the game`` player1InitialScore player2InitialScore scoringPlayer =
        let currentResult = InProgress(player1InitialScore, player2InitialScore)
        let player =
            match scoringPlayer with
            | 1 -> Player1
            | 2 -> Player2
            | _ -> failwith "This is not a valid player" 
        
        let expectedResult = Complete(player)
        let newResult = getNewScore player currentResult

        newResult |> should equal expectedResult

module TestYathzee =

    open Katas.Yathzee
    open NUnit.Framework
    open FsUnit

    //Ones, Twos, Threes, Fours, Fives, Sixes: The player scores the sum of the dice that reads one, two, three, four, five or six, 
    //respectively. For example, 1, 1, 2, 4, 4 placed on "fours" gives 8 points.
    [<Test>]
    [<TestCase(3,3,3,4,4,0)>]
    [<TestCase(1,3,1,4,1,3)>]
    [<TestCase(1,2,3,4,5,1)>]
    let ``We throw the dice, choose ones and get the expected value`` d1 d2 d3 d4 d5 expectedValue =
        let result = calculateScore Ones d1 d2 d3 d4 d5
        result |> should equal expectedValue

    [<Test>]
    [<TestCase(3,3,3,4,4,0)>]
    [<TestCase(1,3,2,4,2,4)>]
    [<TestCase(1,2,3,4,5,2)>]
    let ``We throw the dice, choose twos and get the expected value`` d1 d2 d3 d4 d5 expectedValue =
        let result = calculateScore Twos d1 d2 d3 d4 d5
        result |> should equal expectedValue
      
    [<Test>]
    [<TestCase(1,2,1,4,4,0)>]
    [<TestCase(1,3,3,3,1,9)>]
    [<TestCase(1,2,3,4,5,3)>]
    let ``We throw the dice, choose threes and get the expected value`` d1 d2 d3 d4 d5 expectedValue =
        let result = calculateScore Threes d1 d2 d3 d4 d5
        result |> should equal expectedValue

    [<Test>]
    [<TestCase(3,3,3,1,2,0)>]
    [<TestCase(1,4,1,4,1,8)>]
    [<TestCase(1,2,3,4,5,4)>]
    let ``We throw the dice, choose fours and get the expected value`` d1 d2 d3 d4 d5 expectedValue =
        let result = calculateScore Fours d1 d2 d3 d4 d5
        result |> should equal expectedValue

    [<Test>]
    [<TestCase(3,3,3,4,4,0)>]
    [<TestCase(1,5,5,4,5,15)>]
    [<TestCase(1,2,3,4,5,5)>]
    let ``We throw the dice, choose fives and get the expected value`` d1 d2 d3 d4 d5 expectedValue =
        let result = calculateScore Fives d1 d2 d3 d4 d5
        result |> should equal expectedValue


    [<Test>]
    [<TestCase(3,3,3,4,4,0)>]
    [<TestCase(1,3,6,6,1,12)>]
    [<TestCase(1,2,3,4,6,6)>]
    let ``We throw the dice, choose sixes and get the expected value`` d1 d2 d3 d4 d5 expectedValue =
        let result = calculateScore Sixes d1 d2 d3 d4 d5
        result |> should equal expectedValue

    //Pair: The player scores the sum of the two highest matching dice. For example, 3, 3, 3, 4, 4 placed on "pair" gives 8.
    [<Test>]
    [<TestCase(3,3,3,4,4,8)>]
    [<TestCase(1,3,1,4,1,2)>]
    [<TestCase(1,2,3,4,5,0)>]
    let ``We throw the dice, choose pair and get the expected value`` d1 d2 d3 d4 d5 expectedValue =
        let result = calculateScore Pair d1 d2 d3 d4 d5
        result |> should equal expectedValue

    //Two pairs: If there are two pairs of dice with the same number, the player scores the sum of these dice. If not, the player scores 0. For example, 1, 1, 2, 3, 3 placed on "two pairs" gives 8.
    [<Test>]
    [<TestCase(3,3,3,4,4,14)>]
    [<TestCase(1,3,1,4,3,8)>]
    [<TestCase(1,2,3,2,5,0)>]
    let ``We throw the dice, choose two pair and get the expected value`` d1 d2 d3 d4 d5 expectedValue =
        let result = calculateScore TwoPair d1 d2 d3 d4 d5
        result |> should equal expectedValue

    //Three of a kind: If there are three dice with the same number, the player scores the sum of these dice. Otherwise, the player scores 0. For example, 3, 3, 3, 4, 5 places on "three of a kind" gives 9.
    [<Test>]
    [<TestCase(3,3,4,4,3,9)>]
    [<TestCase(1,3,1,4,3,0)>]
    let ``We throw the dice, choose three of a kind and get the expected value`` d1 d2 d3 d4 d5 expectedValue =
        let result = calculateScore ThreeOfAKind d1 d2 d3 d4 d5
        result |> should equal expectedValue

    //Four of a kind: If there are four dice with the same number, the player scores the sum of these dice. Otherwise, the player scores 0. For example, 2, 2, 2, 2, 5 places on "four of a kind" gives 8.
    [<Test>]
    [<TestCase(3,3,4,3,3,12)>]
    [<TestCase(1,3,1,4,3,0)>]
    let ``We throw the dice, choose four of a kind and get the expected value`` d1 d2 d3 d4 d5 expectedValue =
        let result = calculateScore FourOfAKind d1 d2 d3 d4 d5
        result |> should equal expectedValue

    //Small straight: If the dice read 1,2,3,4,5, the player scores 15 (the sum of all the dice), otherwise 0.
    [<Test>]
    [<TestCase(1,2,3,4,5,15)>]
    [<TestCase(2,3,4,5,6,0)>]
    [<TestCase(5,3,1,4,2,15)>]
    let ``We throw the dice, choose small straight and get the expected value`` d1 d2 d3 d4 d5 expectedValue =
        let result = calculateScore SmallStraight d1 d2 d3 d4 d5
        result |> should equal expectedValue

    //Large straight: If the dice read 2,3,4,5,6, the player scores 20 (the sum of all the dice), otherwise 0.
    [<Test>]
    [<TestCase(1,2,3,4,5,0)>]
    [<TestCase(2,3,4,5,6,20)>]
    [<TestCase(5,3,6,4,2,20)>]
    let ``We throw the dice, choose large straight and get the expected value`` d1 d2 d3 d4 d5 expectedValue =
        let result = calculateScore LargeStraight d1 d2 d3 d4 d5
        result |> should equal expectedValue

    //Full house: If the dice are two of a kind and three of a kind, the player scores the sum of all the dice. For example, 1,1,2,2,2 placed on "full house" gives 8. 4,4,4,4,4 is not "full house".
    [<Test>]
    [<TestCase(1,2,3,4,5,0)>]
    [<TestCase(4,3,4,3,3,17)>]
    [<TestCase(4,4,4,4,4,0)>]
    [<TestCase(4,4,1,3,3,0)>]
    let ``We throw the dice, choose full house and get the expected value`` d1 d2 d3 d4 d5 expectedValue =
        let result = calculateScore FullHouse d1 d2 d3 d4 d5
        result |> should equal expectedValue

    //Yahtzee: If all dice are the have the same number, the player scores 50 points, otherwise 0.
    [<Test>]
    [<TestCase(1,2,3,4,5,0)>]
    [<TestCase(4,3,3,3,3,0)>]
    [<TestCase(4,4,4,4,4,50)>]
    [<TestCase(4,4,1,3,3,0)>]
    let ``We throw the dice, choose yahtzee and get the expected value`` d1 d2 d3 d4 d5 expectedValue =
        let result = calculateScore Yahtzee d1 d2 d3 d4 d5
        result |> should equal expectedValue

    //Chance: The player gets the sum of all dice, no matter what they read.
    [<Test>]
    [<TestCase(1,2,3,4,5,15)>]
    [<TestCase(4,3,3,2,3,15)>]
    [<TestCase(4,4,4,4,4,20)>]
    [<TestCase(4,4,1,3,3,15)>]
    let ``We throw the dice, choose chance and get the expected value`` d1 d2 d3 d4 d5 expectedValue =
        let result = calculateScore Chance d1 d2 d3 d4 d5
        result |> should equal expectedValue

module TestRomanNumerals =

// The Romans were a clever bunch. They conquered most of Europe and ruled it for hundreds of years. 
//They invented concrete and straight roads and even bikinis[1]. One thing they never discovered though was the number zero. 
//This made writing and dating extensive histories of their exploits slightly more challenging, but the system of numbers 
//they came up with is still in use today. For example the BBC uses Roman numerals to date their programmes.
//The Romans wrote numbers using letters - I, V, X, L, C, D, M. 
//The Kata says you should write a function to convert from normal numbers to Roman Numerals: eg
//     1 --> I
//     10 --> X
//     7 --> VII
//etc.
//There is no need to be able to convert numbers larger than about 3000. The Romans themselves didn't tend to go any higher
//Note that you can't write numerals like "IM" for 999. Wikipedia says: Modern Roman numerals ... are written by expressing 
//each digit separately starting with the left most digit and skipping any digit with a value of zero. To see this in practice, 
//consider the ... example of 1990. In Roman numerals 1990 is rendered: 1000=M, 900=CM, 90=XC; resulting in MCMXC. 2008 is written 
//as 2000=MM, 8=VIII; or MMVIII.
//Part II of the Kata
//    Write a function to convert in the other direction, ie numeral to digit *)

    open NUnit.Framework
    open FsUnit
    open Katas.RomanNumerals    

    [<Test>]
    [<TestCase('1', "I")>]
    [<TestCase('2', "II")>]
    [<TestCase('3', "III")>]
    [<TestCase('4', "IV")>]
    [<TestCase('5', "V")>]
    [<TestCase('6', "VI")>]
    [<TestCase('7', "VII")>]
    [<TestCase('8', "VIII")>]
    [<TestCase('9', "IX")>]
    let ``convert ones to roman numeral`` digit expectedNumeral =
        let result = getOnesValue digit
        result |> should equal expectedNumeral

    [<Test>]
    [<TestCase('1', "X")>]
    [<TestCase('2', "XX")>]
    [<TestCase('3', "XXX")>]
    [<TestCase('4', "XL")>]
    [<TestCase('5', "L")>]
    [<TestCase('6', "LX")>]
    [<TestCase('7', "LXX")>]
    [<TestCase('8', "LXXX")>]
    [<TestCase('9', "XC")>]
    let ``convert tens to roman numeral`` digit expectedNumeral =
        let result = getTensValue digit
        result |> should equal expectedNumeral

    [<Test>]
    [<TestCase('1', "C")>]
    [<TestCase('2', "CC")>]
    [<TestCase('3', "CCC")>]
    [<TestCase('4', "CD")>]
    [<TestCase('5', "D")>]
    [<TestCase('6', "DC")>]
    [<TestCase('7', "DCC")>]
    [<TestCase('8', "DCCC")>]
    [<TestCase('9', "CM")>]
    let ``convert hundreds to roman numeral`` digit expectedNumeral =
        let result = getHundredsValue digit
        result |> should equal expectedNumeral

    [<Test>]
    [<TestCase('1', "M")>]
    [<TestCase('2', "MM")>]
    [<TestCase('3', "MMM")>]
    let ``convert thousands to roman numeral`` digit expectedNumeral =
        let result = getThousandsValue digit
        result |> should equal expectedNumeral

    [<Test>]
    [<TestCase(1990,"MCMXC")>]
    [<TestCase(2008,"MMVIII")>]
    let ``convert digit to roman numeral`` digits expectedNumeral =
        let result = convertToRoman digits
        result |> should equal expectedNumeral


module TestBowling =
(*
Create a program, which, given a valid sequence of rolls for one line of American Ten-Pin Bowling, produces the total score for the game. 
Here are some things that the program will not do:

    We will not check for valid rolls.
    We will not check for correct number of rolls and frames.
    We will not provide scores for intermediate frames. 

Depending on the application, this might or might not be a valid way to define a complete story, but we do it here for purposes of 
keeping the kata light. I think you'll see that improvements like those above would go in readily if they were needed for real.

We can briefly summarize the scoring for this form of bowling:

    -Each game, or "line" of bowling, includes ten turns, or "frames" for the bowler.
    -In each frame, the bowler gets up to two tries to knock down all the pins.
    -If in two tries, he fails to knock them all down, his score for that frame is the total number of pins knocked down in his two tries.
    -If in two tries he knocks them all down, this is called a "spare" and his score for the frame is ten plus the number of pins knocked 
    down on his next throw (in his next turn).
    -If on his first try in the frame he knocks down all the pins, this is called a "strike". His turn is over, and his score for the 
    frame is ten plus the simple total of the pins knocked down in his next two rolls.
    -If he gets a spare or strike in the last (tenth) frame, the bowler gets to throw one or two more bonus balls, respectively. These 
    bonus throws are taken as part of the same turn. If the bonus throws knock down all the pins, the process does not repeat: the bonus 
    throws are only used to calculate the score of the final frame.
    -The game score is the total of all frame scores. 

More info on the rules at: www.topendsports.com/sport/tenpin/scoring.htm

Clues

What makes this game interesting to score is the lookahead in the scoring for strike and spare. At the time we throw a strike or spare, 
we cannot calculate the frame score: we have to wait one or two frames to find out what the bonus is.

Suggested Test Cases

(When scoring "X" indicates a strike, "/" indicates a spare, "-" indicates a miss)

    "XXXXXXXXXXXX" (12 rolls: 12 strikes) = 10+10+10 + 10+10+10 + 10+10+10 + 10+10+10 + 10+10+10 + 10+10+10 + 10+10+10 + 10+10+10 + 10+10+10 + 10+10+10 = 300
    "9-9-9-9-9-9-9-9-9-9-" (20 rolls: 10 pairs of 9 and miss) = 9 + 9 + 9 + 9 + 9 + 9 + 9 + 9 + 9 + 9 = 90
    "5/5/5/5/5/5/5/5/5/5/5" (21 rolls: 10 pairs of 5 and spare, with a final 5) = 10+5 + 10+5 + 10+5 + 10+5 + 10+5 + 10+5 + 10+5 + 10+5 + 10+5 + 10+5 = 150 *)
    open NUnit.Framework
    open FsUnit
    open Katas.Bowling

    [<Test>]
    [<TestCase("-",0)>]
    [<TestCase("1",1)>]
    [<TestCase("2",2)>]
    [<TestCase("3",3)>]
    [<TestCase("4",4)>]
    [<TestCase("5",5)>]
    [<TestCase("6",6)>]
    [<TestCase("7",7)>]
    [<TestCase("8",8)>]
    [<TestCase("9",9)>]
    [<TestCase("/",10)>]
    [<TestCase("X",10)>]
    let ``Calculate the single roll correctly`` roll expectedValue =
        let result = score roll
        result |> should equal expectedValue

    [<Test>]
    [<TestCase("123", 6)>]
    [<TestCase("XXXXXXXXXXXX", 300)>]
    [<TestCase("9-9-9-9-9-9-9-9-9-9-", 90)>]
    [<TestCase("9-9-9-9-9-9-9-9-X9-", 100)>]
    [<TestCase("5/5/5/5/5/5/5/5/5/5/5", 150)>]
    let ``I bow a series and get the right result`` series expectedResult =
        let result = bowl series
        result |> should equal expectedResult

(* module TestFloupia =
    //Floup is an island-country in the South Pacific with a currency known as the floupia; coins are denominated 
    //in units of 1, 3, 7, 31 and 153 floupias. Merchants and customers engage in a curious transaction when it comes 
    //time to pay the bill; they exchange the smallest number of coins necessary to complete the payment. 
    //For instance, to pay a bill of 17 floupia, a customer could pay three 7-floupia coins and receive single 1-floupia and 3-floupia 
    //coins in exchange, a total of five coins, but it is more efficient for the customer to pay a single 31-floupia coin 
    //and receive two 7-floupia coins in exchange.

    //Your task is to write a program that determines the most efficient set of coins needed to make a payment,
    // generalized for any set of coins, not just the set 1, 3, 7, 31 and 153 described above. When you are finished, 
    //you are welcome to read or run a suggested solution, or to post your own solution or discuss the exercise in the comments below.

    open NUnit.Framework
    open FsUnit
    open Katas.Floupia

    [<TestFixture>]
    type OriginalFluopia () =
        let floupiaCoins = {Coins= [1; 3; 7; 31; 153]}

        [<Test>]
        [<TestCase(1)>]
        [<TestCase(3)>]
        [<TestCase(7)>]
        [<TestCase(31)>]
        [<TestCase(153)>]
        member x.``The bill matches one of the coins`` bill =
            let expectedGiven = [(bill,1)]
            let expectedReturned = [] 

            let actualGiven, actualReturned = processBill bill floupiaCoins

            actualGiven |> should equal expectedGiven
            actualReturned |> should equal expectedReturned

        [<Test>]
        member x.``The bill is 0. Nothing is given nor returned`` () =
            let expectedGiven = []
            let expectedReturned = [] 

            let actualGiven, actualReturned = processBill 0 floupiaCoins

            actualGiven |> should equal expectedGiven
            actualReturned |> should equal expectedReturned

        [<Test>]
        [<TestCase(2)>]
        [<TestCase(6)>]
        [<TestCase(30)>]
        [<TestCase(152)>]
        member x.``The bill is -1  one of the coins. Gets a single 1-fluopia coin returned`` bill =
            let expectedGiven = [(bill+1,1)]
            let expectedReturned = [(1,1)] 

            let actualGiven, actualReturned = processBill bill floupiaCoins

            actualGiven |> should equal expectedGiven
            actualReturned |> should equal expectedReturned

        [<Test>]
        member x.firstTest () =
            let bill = 17
            let expectedGiven = [(31,1)]
            let expectedReturned = [(7,2)]

            let actualGiven, actualReturned = processBill bill floupiaCoins

            actualGiven |> should equal expectedGiven
            actualReturned |> should equal expectedReturned


    //Today’s exercise is Problem A from the Google Code Jam Beta 2008. The problem is to accept three points as input, determine 
    //if they form a triangle, and, if they do, classify it at equilateral (all three sides the same), isoceles (two sides the same, 
    //the other different), or scalene (all three sides different), and also classify it as acute (all three angles less than 90 degrees), 
    //obtuse (one angle greater than 90 degrees) or right (one angle equal 90 degrees).

    //Your task is to write the triangle classifier. When you are finished, you are welcome to read or run a suggested solution, 
    //or to post your own solution or discuss the exercise in the comments below. *)


(* Kata02: Karate Chop

A binary chop (sometimes called the more prosaic binary search) finds the position of value in a sorted array of values. It achieves 
some efficiency by halving the number of items under consideration each time it probes the values: in the first pass it determines 
whether the required value is in the top or the bottom half of the list of values. In the second pass in considers only this half, 
again dividing it in to two. It stops when it finds the value it is looking for, or when it runs out of array to search. Binary searches 
are a favorite of CS lecturers.

This Kata is straightforward. Implement a binary search routine (using the specification below) in the language and technique of your 
choice. Tomorrow, implement it again, using a totally different technique. Do the same the next day, until you have five totally unique 
implementations of a binary chop. (For example, one solution might be the traditional iterative approach, one might be recursive, one 
might use a functional style passing array slices around, and so on).
Goals

This Kata has three separate goals:

    As you’re coding each algorithm, keep a note of the kinds of error you encounter. A binary search is a ripe breeding ground for 
    “off by one” and fencepost errors. As you progress through the week, see if the frequency of these errors decreases (that is, do 
    you learn from experience in one technique when it comes to coding with a different technique?).

    What can you say about the relative merits of the various techniques you’ve chosen? Which is the most likely to make it in to 
    production code? Which was the most fun to write? Which was the hardest to get working? And for all these questions, ask yourself 
    “why?”.

    It’s fairly hard to come up with five unique approaches to a binary chop. How did you go about coming up with approaches four and 
    five? What techniques did you use to fire those “off the wall” neurons?

Specification

Write a binary chop method that takes an integer search target and a sorted array of integers. It should return the integer index of 
the target in the array, or -1 if the target is not in the array. The signature will logically be:

chop(int, array_of_int)  -> int

You can assume that the array has less than 100,000 elements. For the purposes of this Kata, time and memory performance are not 
issues (assuming the chop terminates before you get bored and kill it, and that you have enough RAM to run it).
Test Data

Here is the Test::Unit code I used when developing my methods. Feel free to add to it. The tests assume that array indices start 
at zero. You’ll probably have to do a couple of global search-and-replaces to make this compile in your language of choice (unless 
your enlightened choice happens to be Ruby).    

def test_chop
  assert_equal(-1, chop(3, []))
  assert_equal(-1, chop(3, [1]))
  assert_equal(0,  chop(1, [1]))
  #
  assert_equal(0,  chop(1, [1, 3, 5]))
  assert_equal(1,  chop(3, [1, 3, 5]))
  assert_equal(2,  chop(5, [1, 3, 5]))
  assert_equal(-1, chop(0, [1, 3, 5]))
  assert_equal(-1, chop(2, [1, 3, 5]))
  assert_equal(-1, chop(4, [1, 3, 5]))
  assert_equal(-1, chop(6, [1, 3, 5]))
  #
  assert_equal(0,  chop(1, [1, 3, 5, 7]))
  assert_equal(1,  chop(3, [1, 3, 5, 7]))
  assert_equal(2,  chop(5, [1, 3, 5, 7]))
  assert_equal(3,  chop(7, [1, 3, 5, 7]))
  assert_equal(-1, chop(0, [1, 3, 5, 7]))
  assert_equal(-1, chop(2, [1, 3, 5, 7]))
  assert_equal(-1, chop(4, [1, 3, 5, 7]))
  assert_equal(-1, chop(6, [1, 3, 5, 7]))
  assert_equal(-1, chop(8, [1, 3, 5, 7]))
end *)

module KarateChopTests =
    open NUnit.Framework
    open FsUnit
    open Katas.KarateChop

    [<Test>]
    [<TestCase(-1, 3, [||])>]
    [<TestCase(-1, 3, [|1|])>]
    [<TestCase(0,  1, [|1|])>]
    [<TestCase(0,  1, [|1; 3; 5|])>]
    [<TestCase(1,  3, [|1; 3; 5|])>]
    [<TestCase(2,  5, [|1; 3; 5|])>]
    [<TestCase(-1, 0, [|1; 3; 5|])>]
    [<TestCase(-1, 2, [|1; 3; 5|])>]
    [<TestCase(-1, 4, [|1; 3; 5|])>]
    [<TestCase(-1, 6, [|1; 3; 5|])>]
    [<TestCase(0,  1, [|1; 3; 5; 7|])>]
    [<TestCase(1,  3, [|1; 3; 5; 7|])>]
    [<TestCase(2,  5, [|1; 3; 5; 7|])>]
    [<TestCase(3,  7, [|1; 3; 5; 7|])>]
    [<TestCase(-1, 0, [|1; 3; 5; 7|])>]
    [<TestCase(-1, 2, [|1; 3; 5; 7|])>]
    [<TestCase(-1, 4, [|1; 3; 5; 7|])>]
    [<TestCase(-1, 6, [|1; 3; 5; 7|])>]
    [<TestCase(-1, 8, [|1; 3; 5; 7|])>]
    let ``chop the array with expected result`` expectedLocation valueToFind array =
        let location = chop valueToFind array
        location |> should equal expectedLocation


(*

Kata03: How Big? How Fast?

Rough estimation is a useful talent to possess. As you’re coding away, you may suddenly need to work out approximately how big a data structure will be, or how fast some loop will run. The faster you can do this, the less the coding flow will be disturbed.

So this is a simple kata: a series of questions, each asking for a rough answer. Try to work each out in your head. I’ll post my answers (and how I got them) in a week or so.
How Big?

    roughly how many binary digits (bit) are required for the unsigned representation of:
        1,000
        1,000,000
        1,000,000,000
        1,000,000,000,000
        8,000,000,000,000

    My town has approximately 20,000 residences. How much space is required to store the names, addresses, and a phone number for all of these (if we store them as characters)?

    I’m storing 1,000,000 integers in a binary tree. Roughly how many nodes and levels can I expect the tree to have? Roughly how much space will it occupy on a 32-bit architecture?

How Fast?

    My copy of Meyer’s Object Oriented Software Construction has about 1,200 body pages. Assuming no flow control or protocol overhead, about how long would it take to send it over an async 56k baud modem line?

    My binary search algorithm takes about 4.5mS to search a 10,000 entry array, and about 6mS to search 100,000 elements. How long would I expect it to take to search 10,000,000 elements (assuming I have sufficient memory to prevent paging).

    Unix passwords are stored using a one-way hash function: the original string is converted to the ‘encrypted’ password string, which cannot be converted back to the original string. One way to attack the password file is to generate all possible cleartext passwords, applying the password hash to each in turn and checking to see if the result matches the password you’re trying to crack. If the hashes match, then the string you used to generate the hash is the original password (or at least, it’s as good as the original password as far as logging in is concerned). In our particular system, passwords can be up to 16 characters long, and there are 96 possible characters at each position. If it takes 1mS to generate the password hash, is this a viable approach to attacking a password?

*)
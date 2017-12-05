module Tests

open System
open Xunit
open GameOfLife.Universe

let compare expectedUniverse actualUniverse =
    Assert.True ((CompareList expectedUniverse actualUniverse),  sprintf "Should be %A but was %A" expectedUniverse actualUniverse)

[<Fact>]
let ``Empty Universe returns Empty Universe`` () =
    let emptyUniverse = []
    let universe = []
    NextUniverse emptyUniverse
    |> compare universe

[<Fact>]
let ``Universe with one cell returns Empty Universe`` () =
    let universeWithOne = [ { x = 0; y = 0} ]
    let universe = []
    NextUniverse universeWithOne
    |> compare universe

[<Fact>]
let ``Universe with one cell surrounded by two returns Universe with single cell`` () =
    let universeWithThree = [ { x = 0; y = 0}; { x = 1; y = 1}; { x = 2; y = 2}  ]
    let universe = [{ x = 1; y = 1}]
    NextUniverse universeWithThree
    |> compare universe


[<Fact>]
let ``get neighbours`` ()=
    let cell = {x = 0; y = 0}
    let neighbours = GetNeighbours cell
    let expected = [ { x = -1; y = -1};
                     { x = 0; y = -1};
                     { x = 1; y = -1};
                     { x = -1; y = 0};
                     { x = 1; y = 0};
                     { x = -1; y = 1};
                     { x = 0; y = 1};
                     { x = 1; y = 1}]
    compare expected neighbours

[<Fact>]
let ``compare two cells`` () =
    let cell1 = {x = 0; y = 0}
    let cell2 = {x = 0; y = 0}
    Assert.True (CompareCell cell1 cell2)

[<Fact>]
let ``compare contents`` () =
    let cell1 = [{x = 0; y = 0}]
    let cell2 = [{x = 0; y = 0}]
    Assert.True (CompareContents cell1 cell2)

[<Fact>]
let ``Two neighbours then alive`` () =
    Assert.True (CheckIfAlive {x = 0; y = 0} [{x = 1; y = 0}; {x = 1; y = 1}])

[<Fact>]
let ``Three neighbours then alive`` () =
    Assert.True (CheckIfAlive {x = 0; y = 0} [{x = 1; y = 0}; {x = 1; y = 1}; {x = -1; y = 0}])

[<Fact>]
let ``Four neighbours then dead`` () =
    Assert.False (CheckIfAlive {x = 0; y = 0} [{x = 1; y = 0}; {x = 1; y = 1}; {x = -1; y = 0}; {x = 1; y = -1};])


[<Fact>]
let ``One neighbours then dead`` () =
    Assert.False (CheckIfAlive {x = 0; y = 0} [{x = 1; y = 1}])

let singleCellUniverse = [{ x = 0; y = 0}]

let CompareExpected actualUniverse =
    Assert.True (CompareList singleCellUniverse actualUniverse)

[<Fact>]
let ``Empty cell becomes alive`` () =
    [{ x = -1; y = -1};
     { x = 1; y = 1};
     { x = -1; y = 1}]
    |> NextUniverse
    |> CompareExpected
    
[<Fact>]
let ``Empty cell is born`` () =
    let universeWithThree = [ { x = -1; y = -1}; { x = 1; y = 1}; { x = -1; y = 1}  ]
    let universe = [{ x = 0; y = 0}]
    BornWithThree universeWithThree
    |> compare universe

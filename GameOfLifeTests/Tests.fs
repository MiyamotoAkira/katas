module Tests

open System
open Xunit
open GameOfLife.Universe

let compare expectedUniverse actualUniverse =
    Assert.True ((compareList expectedUniverse actualUniverse),  sprintf "Should be %A but was %A" expectedUniverse actualUniverse)

[<Fact>]
let ``Empty Universe returns Empty Universe`` () =
    let emptyUniverse = []
    let universe = []
    NextUniverse emptyUniverse
    |> compare universe

[<Fact>]
let ``Universe with one cell returns Empty Universe`` () =
    let universeWithOne = [ { xPosition = 0; yPosition = 0} ]
    let universe = []
    NextUniverse universeWithOne
    |> compare universe

[<Fact>]
let ``Universe with one cell  surrounded by two returns Universe with single cell`` () =
    let universeWithThree = [ { xPosition = 0; yPosition = 0}; { xPosition = 1; yPosition = 1}; { xPosition = 2; yPosition = 2}  ]
    let universe = [{ xPosition = 1; yPosition = 1}]
    NextUniverse universeWithThree
    |> compare universe


[<Fact>]
let ``get neighbours`` ()=
    let cell = {xPosition = 0; yPosition = 0}
    let neighbours = GetNeighbours cell
    let expected = [ { xPosition = -1; yPosition = -1}; { xPosition = 0; yPosition = -1}; { xPosition = 1; yPosition = -1};
                      { xPosition = -1; yPosition = 0}; { xPosition = 1; yPosition = 0};
                      { xPosition = -1; yPosition = 1}; { xPosition = 0; yPosition = 1}; { xPosition = 1; yPosition = 1}]
    compare expected neighbours

[<Fact>]
let ``compare two cells`` () =
    let cell1 = {xPosition = 0; yPosition = 0}
    let cell2 = {xPosition = 0; yPosition = 0}
    Assert.True (compareCell cell1 cell2)

[<Fact>]
let ``compare contents`` () =
    let cell1 = [{xPosition = 0; yPosition = 0}]
    let cell2 = [{xPosition = 0; yPosition = 0}]
    Assert.True (compareContents cell1 cell2)

[<Fact>]
let ``Two neighbours then alive`` () =
    Assert.True (CheckIfAlive {xPosition = 0; yPosition = 0} [{xPosition = 1; yPosition = 0}; {xPosition = 1; yPosition = 1}])

[<Fact>]
let ``Three neighbours then alive`` () =
    Assert.True (CheckIfAlive {xPosition = 0; yPosition = 0} [{xPosition = 1; yPosition = 0}; {xPosition = 1; yPosition = 1}; {xPosition = -1; yPosition = 0}])

[<Fact>]
let ``Four neighbours then dead`` () =
    Assert.False (CheckIfAlive {xPosition = 0; yPosition = 0} [{xPosition = 1; yPosition = 0}; {xPosition = 1; yPosition = 1}; {xPosition = -1; yPosition = 0}; {xPosition = 1; yPosition = -1};])


[<Fact>]
let ``One neighbours then dead`` () =
    Assert.False (CheckIfAlive {xPosition = 0; yPosition = 0} [{xPosition = 1; yPosition = 1}])
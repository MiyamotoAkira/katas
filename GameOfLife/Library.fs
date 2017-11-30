namespace GameOfLife
module Universe =

    type Cell = {xPosition: int; yPosition: int}

    let neighbours = [(-1,-1); (0, -1); (1, -1); (-1, 0); (1, 0); (-1, 1); (0, 1); (1, 1);]

    let AddNeighbour cell mods universe =
        { xPosition = cell.xPosition + fst mods;
          yPosition = cell.yPosition +  snd mods}
        :: universe

    let GetNeighbours (cell:Cell) : List<Cell> =
        let CalculateNeighboursForCell acc elem = AddNeighbour cell elem acc
        List.fold CalculateNeighboursForCell [] neighbours
        |> List.rev

    let FindOnUniverse list1 list2 =
        List.filter (fun (x) -> List.exists (fun(y) -> x = y) list2) list1

    let CheckIfAlive cell universe =
        let mutable alive  = GetNeighbours cell
        alive <- FindOnUniverse universe alive
        (List.length alive) = 2
        || (List.length alive = 3)

    let CheckIfThree cell universe =
        let neighbours = GetNeighbours cell
        let alive = FindOnUniverse universe neighbours
        List.length alive = 3

    let CompareCell cell1 cell2 =
        (cell1.xPosition = cell2.xPosition) && (cell1.yPosition = cell2.yPosition)

    let CompareContents list1 list2 =
        List.zip list1 list2
        |> List.forall (fun (x) -> CompareCell (fst x) (snd x))

    let CompareList list1 list2 =
        (List.length list1) = (List.length list2) && (CompareContents list1 list2)

    let Born universe =
        //get all neighbours from live cells
        List.fold (fun acc elem -> (GetNeighbours elem) @ acc) [] universe
        //dedup all neighbours
        |> Set.ofList
        |> Set.toList
        //eliminate cells that are alive already
        |> List.filter (fun x -> not (List.exists (fun y -> CompareCell x y) universe))
        //for remaining cells find if has three neighbours
        |> List.fold (fun acc elem ->
                      match CheckIfThree elem universe with
                      | true -> elem :: acc
                      | false -> acc) []
 
    let NextUniverse universe =
        List.fold (fun acc elem ->
        match CheckIfAlive elem universe with
        | false -> acc 
        | true -> elem :: acc) [] universe @ (Born universe)

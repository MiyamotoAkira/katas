namespace GameOfLife
module Universe =

    type Cell = {x: int; y: int}

    let neighbours = [(-1,-1); (0, -1); (1, -1); (-1, 0); (1, 0); (-1, 1); (0, 1); (1, 1);]

    let CompareCell cell1 cell2 =
        (cell1.x = cell2.x) && (cell1.y = cell2.y)

    let CompareContents list1 list2 =
        List.zip list1 list2
        |> List.forall (fun (x) -> CompareCell (fst x) (snd x))

    let CompareList list1 list2 =
        (List.length list1) = (List.length list2) && (CompareContents list1 list2)

    let AddNeighbour cell mods universe =
        { x = cell.x + fst mods;
          y = cell.y + snd mods}
        :: universe

    let GetNeighbours (cell:Cell) : List<Cell> =
        let CalculateNeighboursForCell acc elem = AddNeighbour cell elem acc
        List.fold CalculateNeighboursForCell [] neighbours
        |> List.rev

    let FindOnUniverse list1 list2 =
        List.filter (fun (x) -> List.exists (fun(y) -> x = y) list2) list1

    let NotIn list =
        fun x -> not (List.exists (fun y -> CompareCell x y) list)
        
    let NotAnyIn list from =
        List.filter (NotIn list) from

    let CheckIfAlive cell universe =
        let mutable alive  = GetNeighbours cell
        alive <- FindOnUniverse universe alive
        (List.length alive) = 2
        || (List.length alive = 3)

    let CheckIfThree cell universe =
        let neighbours = GetNeighbours cell
        let alive = FindOnUniverse universe neighbours
        List.length alive = 3

    let CollateNeighbours acc elem = (GetNeighbours elem) @ acc

    let Born check universe =
        //get all neighbours from live cells
        List.fold CollateNeighbours [] universe
        //dedup all neighbours
        |> Set.ofList
        |> Set.toList
        //eliminate cells that are alive already
        |> NotAnyIn universe
        //for remaining cells find if has three neighbours
        |> List.fold (fun acc elem ->
                      match check elem universe with
                      | true -> elem :: acc
                      | false -> acc) []

    let BornWithThree universe =
        Born CheckIfThree universe
 
    let NextUniverse universe =
        List.fold (fun acc elem ->
        match CheckIfAlive elem universe with
        | false -> acc 
        | true -> elem :: acc) [] universe @ (BornWithThree universe)

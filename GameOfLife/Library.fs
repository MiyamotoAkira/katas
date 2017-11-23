namespace GameOfLife
module Universe =

    type Cell = {xPosition: int; yPosition: int}

    let neighbours = [(-1,-1); (0, -1); (1, -1); (-1, 0); (1, 0); (-1, 1); (0, 1); (1, 1);]

    let GetNeighbours (cell:Cell) : List<Cell> =
        List.fold (fun acc elem -> { xPosition = cell.xPosition + fst elem; yPosition = cell.yPosition +  snd elem} :: acc) [] neighbours
        |> List.rev


    let FindOnUniverse list1 list2 =
        List.filter (fun (x) -> List.exists (fun(y) -> x = y) list2) list1

    let CheckIfAlive cell universe =
        let neighbours = GetNeighbours cell
        let alive = FindOnUniverse universe neighbours
        (List.length alive) = 2 || (List.length alive = 3)

    let NextUniverse universe =
        List.fold (fun acc elem -> 
        match CheckIfAlive elem universe with
        | false -> acc 
        | true -> elem :: acc) [] universe
        
    let compareCell cell1 cell2 =
        (cell1.xPosition = cell2.xPosition) && (cell1.yPosition = cell2.yPosition)

    let compareContents list1 list2 =
        List.zip list1 list2
        |> List.forall (fun (x) -> compareCell (fst x) (snd x))

    let compareList list1 list2 =
        (List.length list1) = (List.length list2) && (compareContents list1 list2)

        
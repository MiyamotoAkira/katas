defmodule MarsroverTest do
  use ExUnit.Case
  use ExUnit.Parameterized

  test "acceptance test" do
    input = ["5 5","1 2 N", "LMLMLMLMM", "3 3 E", "MMRMMRMRRM"]
    expected_output = ["1 3 N", "5 1 E"]

    actual_output = Marsrover.process(input)

    assert actual_output == expected_output
  end

  test "extract parts" do
    input = ["5 5","1 2 N", "LMLMLMLMM", "3 3 E", "MMRMMRMRRM"]
    expected_output = %{world: %{x: 5, y: 5},
                        rovers: [
                          %{position: %{x: 1, y: 2, direction: :N},
                           moves: [:L, :M, :L, :M, :L, :M, :L, :M, :M]},
                          %{position: %{x: 3, y: 3, direction: :E},
                           moves: [:M, :M, :R, :M, :M, :R, :M, :R, :R, :M]}]}

    actual_output = Marsrover.extract_parts(input)

    assert actual_output == expected_output
  end

  test "extract_world" do
    input = ["5 5","1 2 N", "LMLMLMLMM", "3 3 E", "MMRMMRMRRM"]
    expected_output = {%{world: %{x: 5, y: 5}},  List.delete_at(input, 0)}

    actual_output = Marsrover.extract_world(input)
    
    assert actual_output == expected_output
  end

  test "process_world" do
    input = "5 5"
    expected_output = %{world: %{x: 5, y: 5}}

    actual_output = Marsrover.process_world(input)

    assert actual_output == expected_output
  end

  test "extract_rovers" do
    input = {%{world: %{x: 5, y: 5}}, ["1 2 N", "LMLMLMLMM", "3 3 E", "MMRMMRMRRM"]}
    expected_output = %{world: %{x: 5, y: 5},
                        rovers: [
                          %{position: %{x: 1, y: 2, direction: :N},
                           moves: [:L, :M, :L, :M, :L, :M, :L, :M, :M]},
                          %{position: %{x: 3, y: 3, direction: :E},
                            moves: [:M, :M, :R, :M, :M, :R, :M, :R, :R, :M]}]}
    
    actual_output = Marsrover.extract_rovers(input)

    assert actual_output == expected_output
  end

  test "create_rover_info" do
    input = {"1 2 N", "LMLMLMLMM"}
    expected_output = %{position: %{x: 1, y: 2, direction: :N},
                        moves: [:L, :M, :L, :M, :L, :M, :L, :M, :M]}

    actual_output = Marsrover.create_rover_info(input)

    assert actual_output == expected_output
  end

  test "create_starting_position" do
    input = "1 2 N"
    expected_output = %{position: %{x: 1, y: 2, direction: :N}}

    actual_output = Marsrover.create_starting_position(input)

    assert actual_output == expected_output
  end

  test "add_moves" do
    initial = %{position: %{x: 1, y: 2, direction: :N}}
    moves =  "LMLMLMLMM"

    expected_output = %{position: %{x: 1, y: 2, direction: :N},
                        moves: [:L, :M, :L, :M, :L, :M, :L, :M, :M]}

    actual_output = Marsrover.add_moves(initial, moves)

    assert actual_output == expected_output
  end

  test "move_rover" do
    world = %{x: 5, y: 5}
    rover = %{position: %{x: 1, y: 2, direction: :N},
              moves: [:L, :M, :L, :M, :L, :M, :L, :M, :M]}
    expected_output = %{x: 1, y: 3, direction: :N}

    actual_output = Marsrover.move_rover(world, rover)
    
    assert actual_output == expected_output
  end

  test_with_params "single_move", fn position, expected_output, move ->
    world = %{x: 5, y: 5}
    actual_output = Marsrover.single_move(world, move, position)
    
    assert actual_output == expected_output
  end do
    [
      {%{x: 1, y: 2, direction: :N}, %{x: 1, y: 2, direction: :W}, :L},
      {%{x: 1, y: 2, direction: :N}, %{x: 1, y: 2, direction: :E}, :R},
      {%{x: 1, y: 2, direction: :W}, %{x: 1, y: 2, direction: :S}, :L},
      {%{x: 1, y: 2, direction: :W}, %{x: 1, y: 2, direction: :N}, :R},
      {%{x: 1, y: 2, direction: :S}, %{x: 1, y: 2, direction: :E}, :L},
      {%{x: 1, y: 2, direction: :S}, %{x: 1, y: 2, direction: :W}, :R},
      {%{x: 1, y: 2, direction: :E}, %{x: 1, y: 2, direction: :N}, :L},
      {%{x: 1, y: 2, direction: :E}, %{x: 1, y: 2, direction: :S}, :R},
      {%{x: 2, y: 2, direction: :N}, %{x: 2, y: 3, direction: :N}, :M},
      {%{x: 2, y: 2, direction: :W}, %{x: 1, y: 2, direction: :W}, :M},
      {%{x: 2, y: 2, direction: :S}, %{x: 2, y: 1, direction: :S}, :M},
      {%{x: 2, y: 2, direction: :E}, %{x: 3, y: 2, direction: :E}, :M}
    ]
  end

  test_with_params "wrapping on single move", fn position, expected_output, move ->
    world = %{x: 5, y: 5}
    actual_output = Marsrover.single_move(world, move, position)

    assert actual_output == expected_output
  end do
    [
      {%{x: 1, y: 5, direction: :N}, %{x: 1, y: 1, direction: :N}, :M},
      {%{x: 1, y: 1, direction: :S}, %{x: 1, y: 5, direction: :S}, :M},
      {%{x: 5, y: 1, direction: :E}, %{x: 1, y: 1, direction: :E}, :M},
      {%{x: 1, y: 1, direction: :W}, %{x: 5, y: 1, direction: :W}, :M},
    ]
  end
end

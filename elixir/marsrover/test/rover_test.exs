defmodule RoverTest do
  use ExUnit.Case
  use ExUnit.Parameterized
  
  test "extract_rovers" do
    input = {%{world: %{x: 5, y: 5}}, ["1 2 N", "LMLMLMLMM", "3 3 E", "MMRMMRMRRM"]}
    expected_output = %{world: %{x: 5, y: 5},
                        rovers: [
                          {:ok, %{position: %Position{x: 1, y: 2, direction: :N},
                           moves: [:L, :M, :L, :M, :L, :M, :L, :M, :M]}},
                          {:ok, %{position: %Position{x: 3, y: 3, direction: :E},
                            moves: [:M, :M, :R, :M, :M, :R, :M, :R, :R, :M]}}]}
    
    actual_output = Rover.extract_rovers(input)

    assert actual_output == expected_output
  end

  test "create_rover_info" do
    input = {:ok, {"1 2 N", "LMLMLMLMM"}}
    expected_output =  {:ok, %{position: %Position{x: 1, y: 2, direction: :N},
                        moves: [:L, :M, :L, :M, :L, :M, :L, :M, :M]}}

    actual_output = Rover.create_rover_info(input)

    assert actual_output == expected_output
  end

  test "create_starting_position" do
    input = "1 2 N"
    expected_output = %{position: %Position{x: 1, y: 2, direction: :N}}

    actual_output = Rover.create_starting_position(input)

    assert actual_output == expected_output
  end

  test "add_moves" do
    initial = %{position: %Position{x: 1, y: 2, direction: :N}}
    moves =  "LMLMLMLMM"

    expected_output = %{position: %Position{x: 1, y: 2, direction: :N},
                        moves: [:L, :M, :L, :M, :L, :M, :L, :M, :M]}

    actual_output = Rover.add_moves(initial, moves)

    assert actual_output == expected_output
  end

  test "move_rover" do
    world = %{x: 5, y: 5}
    rover = {:ok, %{position: %Position{x: 1, y: 2, direction: :N},
              moves: [:L, :M, :L, :M, :L, :M, :L, :M, :M]}}
    expected_output = {:ok, %Position{x: 1, y: 3, direction: :N}}

    actual_output = Rover.move_rover(world, rover)
    
    assert actual_output == expected_output
  end

  test_with_params "validate_rover_info returns :ok on correct data", fn data ->
    actual_output = Rover.validate_rover_info (data)
    assert actual_output == {:ok, data}
  end do
    [
      {{"1 2 N", "LMLMRMLLM"}}
    ]
  end

  test_with_params "validate_rover_info returns :error on bad data", fn data ->
    actual_output = Rover.validate_rover_info (data)
    assert actual_output == {:error, data}
  end do
    [
      {{"1 2 N", "LMLMLMLDM"}}
    ]
  end
end

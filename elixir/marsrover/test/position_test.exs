defmodule PositionTest do
  use ExUnit.Case
  use ExUnit.Parameterized

  test "process_world" do
    input = "5 5"
    expected_output = %{world: %{x: 5, y: 5}}

    actual_output = Marsrover.process_world(input)

    assert actual_output == expected_output
  end

  test_with_params "single_move", fn position, expected_output, move ->
    world = %{x: 5, y: 5}
    actual_output = Position.single_move(world, move, position)
    
    assert actual_output == expected_output
  end do
    [
      {%Position{x: 1, y: 2, direction: :N}, %Position{x: 1, y: 2, direction: :W}, :L},
      {%Position{x: 1, y: 2, direction: :N}, %Position{x: 1, y: 2, direction: :E}, :R},
      {%Position{x: 1, y: 2, direction: :W}, %Position{x: 1, y: 2, direction: :S}, :L},
      {%Position{x: 1, y: 2, direction: :W}, %Position{x: 1, y: 2, direction: :N}, :R},
      {%Position{x: 1, y: 2, direction: :S}, %Position{x: 1, y: 2, direction: :E}, :L},
      {%Position{x: 1, y: 2, direction: :S}, %Position{x: 1, y: 2, direction: :W}, :R},
      {%Position{x: 1, y: 2, direction: :E}, %Position{x: 1, y: 2, direction: :N}, :L},
      {%Position{x: 1, y: 2, direction: :E}, %Position{x: 1, y: 2, direction: :S}, :R},
      {%Position{x: 2, y: 2, direction: :N}, %Position{x: 2, y: 3, direction: :N}, :M},
      {%Position{x: 2, y: 2, direction: :W}, %Position{x: 1, y: 2, direction: :W}, :M},
      {%Position{x: 2, y: 2, direction: :S}, %Position{x: 2, y: 1, direction: :S}, :M},
      {%Position{x: 2, y: 2, direction: :E}, %Position{x: 3, y: 2, direction: :E}, :M}
    ]
  end

  test_with_params "wrapping on single move", fn position, expected_output, move ->
    world = %{x: 5, y: 5}
    actual_output = Position.single_move(world, move, position)

    assert actual_output == expected_output
  end do
    [
      {%Position{x: 1, y: 5, direction: :N}, %Position{x: 1, y: 1, direction: :N}, :M},
      {%Position{x: 1, y: 1, direction: :S}, %Position{x: 1, y: 5, direction: :S}, :M},
      {%Position{x: 5, y: 1, direction: :E}, %Position{x: 1, y: 1, direction: :E}, :M},
      {%Position{x: 1, y: 1, direction: :W}, %Position{x: 5, y: 1, direction: :W}, :M},
    ]
  end
  
end

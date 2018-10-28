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
                          {:ok, %{position: %Position{x: 1, y: 2, direction: :N},
                           moves: [:L, :M, :L, :M, :L, :M, :L, :M, :M]}},
                          {:ok, %{position: %Position{x: 3, y: 3, direction: :E},
                           moves: [:M, :M, :R, :M, :M, :R, :M, :R, :R, :M]}}]}

    actual_output = Marsrover.extract_parts(input)

    assert actual_output == expected_output
  end

  test "extract_world" do
    input = ["5 5","1 2 N", "LMLMLMLMM", "3 3 E", "MMRMMRMRRM"]
    expected_output = {%{world: %{x: 5, y: 5}},  List.delete_at(input, 0)}

    actual_output = Marsrover.extract_world(input)
    
    assert actual_output == expected_output
  end

  test_with_params "wrong world data throws errors", fn data ->
    assert_raise ArgumentError, fn ->
      Marsrover.process(data)
    end
  end do
    [
      {["5 5 3","1 2 N", "LMLMLMLMM", "3 3 E", "MMRMMRMRRM"]},
      {["5 N","1 2 N", "LMLMLMLMM", "3 3 E", "MMRMMRMRRM"]},
      {["5","1 2 N", "LMLMLMLMM", "3 3 E", "MMRMMRMRRM"]}
    ]
  end

  test "wrong number of rover lines throws error" do
    data = ["5 5","1 2 N", "LMLMLMLMM", "MMRMMRMRRM"]

    assert_raise ArgumentError, fn ->
      Marsrover.process(data)
    end
  end

  test_with_params "wrong info on a rovers skips that rover", fn data, expected_output->
 
    actual_output = Marsrover.process(data)

    assert actual_output == expected_output
  end do
    [
      {["5 5","1 2 N", "LMLMLMLDM", "3 3 E", "MMRMMRMRRM"], ["5 1 E"]}
    ]
  end
end

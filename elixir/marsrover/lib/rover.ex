defmodule Rover do
  def move_rovers(input) do
    input[:rovers]
    |> Enum.map(fn rover -> move_rover(input[:world], rover) end)
  end

  def move_rover(world, {:ok, rover}) do
    rover[:moves]
    |> Enum.reduce(rover[:position], fn move, position -> Position.single_move(world, move, position) end)
    |> (fn position -> {:ok, position} end).()
  end

  def move_rover(_, {:error, data}) do
    {:error, data}
  end

  def extract_rovers({world, rest}) do
    rest
    |> Enum.chunk_every(2)
    |> Enum.map(&({Enum.at(&1, 0), Enum.at(&1, 1)}))
    |> Enum.map(&validate_rover_info/1)
    |> Enum.map(&create_rover_info/1)
    |> (&(Map.put(world, :rovers, &1))).()
  end

  def validate_rover_info({initial, moves}) when moves != nil do
    non_valid_moves = moves
    |> String.graphemes
    |> Enum.filter(&(&1 != "L" && &1 != "M" && &1 != "R"))
    |> Enum.count
    
    if non_valid_moves > 0 do
      {:error, {initial, moves}}
    else
      {:ok, {initial, moves}}
    end
  end

  def validate_rover_info(_) do
    raise ArgumentError, "Number of rover lines is incorrect"
  end

  def create_rover_info({:ok, {initial, moves}}) do
    initial
    |> create_starting_position
    |> add_moves(moves)
    |> (fn moves -> {:ok, moves} end).()
  end

  def create_rover_info({:error, data}) do
    {:error, data}
  end

  def create_starting_position(initial) do
    initial
    |> String.split
    |> (&(%{position: %Position{x: String.to_integer(Enum.at(&1, 0)), y: String.to_integer(Enum.at(&1, 1)), direction: String.to_atom(Enum.at(&1, 2))}})).()
  end

  def add_moves(initial, moves) do
    moves
    |> String.graphemes
    |> Enum.reduce([], fn x, acc -> acc ++ [String.to_atom(x)] end)
    |> (&(Map.put(initial, :moves, &1))).()
  end
end

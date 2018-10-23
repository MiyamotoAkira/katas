defmodule Marsrover do
   @moduledoc """
  Documentation for Marsrover.
  """

  def process(input) do
    input
    |> extract_parts
    |> move_rovers
    |> get_results
  end

  def extract_parts(input) do
    input
    |> extract_world
    |> extract_rovers
  end

  def move_rovers(input) do
    input[:rovers]
    |> Enum.map(fn rover -> move_rover(input[:world], rover) end)
  end

  def move_rover(world, rover) do
    rover[:moves]
    |> Enum.reduce(rover[:position], fn move, position -> single_move(world, move, position) end)
  end

  def single_move(world, move, position) do
    case move do
      :L -> move_left(position)
      :R -> move_right(position)
      :M -> move_forward(position)
    end
    |> wrap(world)
  end

  def wrap(position, world) do
    position
    |> wrap_high_y(world)
    |> wrap_low_y(world)
    |> wrap_high_x(world)
    |> wrap_low_x(world)
  end

  def wrap_high_y(position, world) do
    if position.y > world.y  do
      %{position | y: 1}
    else 
      position
    end
  end

  def wrap_low_y(position, world) do
    if position.y < 1 do
      %{position | y: world.y}
    else 
      position
    end
  end

  def wrap_high_x(position, world) do
    if position.x > world.x do
      %{position | x: 1}
    else 
      position
    end
  end

  def wrap_low_x(position, world) do
    if position.x < 1 do
      %{position | x: world.x}
    else
      position
    end
  end
  
  def move_left(position) do
    case position.direction do
      :N -> %{position | direction: :W}
      :W -> %{position | direction: :S}
      :S -> %{position | direction: :E}
      :E -> %{position | direction: :N}
    end
  end

  def move_right(position) do
    case position.direction do
      :N -> %{position | direction: :E}
      :W -> %{position | direction: :N}
      :S -> %{position | direction: :W}
      :E -> %{position | direction: :S}
    end
  end

  def move_forward(position) do
    case position.direction do
      :N -> %{position | y: position.y + 1}
      :W -> %{position | x: position.x - 1}
      :S -> %{position | y: position.y - 1}
      :E -> %{position | x: position.x + 1}
    end
  end
  
  def get_results(input) do
    input
    |> Enum.map(fn position -> "#{position.x} #{position.y} #{Atom.to_string(position.direction)}" end)
  end

  def extract_world(input) do
    {world_raw, rest} = List.pop_at(input, 0)
    world = process_world(world_raw)
    {world, rest}
  end

  def extract_rovers({world, rest}) do
    rest
    |> Enum.chunk_every(2)
    |> Enum.map(&({Enum.at(&1, 0), Enum.at(&1, 1)}))
    |> Enum.map(&create_rover_info/1)
    |> (&(Map.put(world, :rovers, &1))).()
  end

  def create_rover_info({initial, moves}) do
    initial
    |> create_starting_position
    |> add_moves(moves)
  end

  def create_starting_position(initial) do
    initial
    |> String.split
    |> (&(%{position: %{x: String.to_integer(Enum.at(&1, 0)), y: String.to_integer(Enum.at(&1, 1)), direction: String.to_atom(Enum.at(&1, 2))}})).()
  end

  def add_moves(initial, moves) do
    moves
    |> String.graphemes
    |> Enum.reduce([], fn x, acc -> acc ++ [String.to_atom(x)] end)
    |> (&(Map.put(initial, :moves, &1))).()
  end

  def process_world(world_raw) do
    world_raw
    |> String.split
    |> (&(%{world: %{x: String.to_integer(Enum.at(&1, 0)), y: String.to_integer(Enum.at(&1, 1))}})).()
  end
end

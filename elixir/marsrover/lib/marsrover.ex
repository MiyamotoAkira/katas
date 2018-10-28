defmodule Marsrover do
   @moduledoc """
  Documentation for Marsrover.
  """

  def process(input) do
    input
    |> extract_parts
    |> Rover.move_rovers
    |> get_results
   end

  def validate_world_number(elements) do
    if Enum.count(elements) != 2 do
      raise ArgumentError, message: "World line is expected to have two elements"
    else
      elements
    end
  end

  def extract_parts(input) do
    input
    |> extract_world
    |> Rover.extract_rovers
  end

  def get_results(input) do
    input
    |> Enum.filter(fn {result, _} -> :ok == result end)
    |> Enum.map(fn {_, position} -> "#{position.x} #{position.y} #{Atom.to_string(position.direction)}" end)
  end

  def extract_world(input) do
    {world_raw, rest} = List.pop_at(input, 0)
    world = process_world(world_raw)
    {world, rest}
  end

  def process_world(world_raw) do
    world_raw
    |> String.split
    |> validate_world_number
    |> (&(%{world: %{x: String.to_integer(Enum.at(&1, 0)), y: String.to_integer(Enum.at(&1, 1))}})).()
  end
end

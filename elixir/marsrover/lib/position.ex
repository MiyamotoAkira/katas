defmodule Position do
  defstruct x: 0, y: 0, direction: :N
  
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
  
end

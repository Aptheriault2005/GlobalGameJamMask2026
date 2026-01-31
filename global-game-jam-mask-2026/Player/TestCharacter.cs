using Godot;
using System;

public partial class TestCharacter : Node2D
{
	[Export] private float Speed = 100;

	public static TestCharacter currentPlayer;

    public override void _EnterTree()
    {
		currentPlayer = this;
    }


	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Position += (float)delta * Speed * Input.GetVector("move_left", "move_right", "move_up", "move_down");
	} 
}

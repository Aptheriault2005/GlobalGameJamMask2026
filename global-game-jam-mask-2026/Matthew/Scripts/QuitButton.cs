using Godot;
using System;

public partial class QuitButton : Button
{
	
	public static Button Quit;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Quit = this;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	public override void _Pressed() {
		GetTree().Quit();
	}
}

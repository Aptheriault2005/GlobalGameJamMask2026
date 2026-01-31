using Godot;
using System;

public partial class ControlsScreen : CanvasLayer
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Globals.Instance.PrevScene = "res://Matthew/Scenes/settings_screen.tscn";
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}

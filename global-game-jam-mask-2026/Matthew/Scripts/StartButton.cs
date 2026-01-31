using Godot;
using System;

public partial class StartButton : Button
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Globals.Instance.PrevScene = "res://Matthew/Scenes/title_screen.tscn";
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	public override void _Pressed() {
		GetTree().ChangeSceneToFile("res://Matthew/Scenes/testing.tscn");
		Globals.Instance.Started = true;
	}
}

using Godot;
using System;

public partial class TitleScreen : Button
{
	
	public static Button Title;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Title = this;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	public override void _Pressed() {
		Globals.Instance.Started = false;
		if (GetTree().Paused) 
		{
			GetTree().Paused = false;
		}
		GetTree().ChangeSceneToFile("res://Matthew/Scenes/title_screen.tscn");
		Globals.Instance.PrevScene = "res://Matthew/Scenes/title_screen.tscn";
	}
}

using Godot;
using System;

public partial class ControlsButton : Button
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		// Brings player to main menu if game hasn't started
		// Brings player back to game if have started
		
		if (Globals.Instance.Started) {
			//Change after merge
			Globals.Instance.PrevScene = "res://Matthew/Scenes/testing.tscn";
		}
		else {
			Globals.Instance.PrevScene = "res://Matthew/Scenes/title_screen.tscn";
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	public override void _Pressed() {
		GetTree().ChangeSceneToFile("res://Matthew/Scenes/controls_screen.tscn");
	}
	
}

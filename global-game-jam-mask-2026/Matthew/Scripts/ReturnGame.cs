using Godot;
using System;

public partial class ReturnGame : Button
{
	
	[Export] private PauseMenu pm;
	
	public static Button Rtrn;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Rtrn = this;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	public override void _Pressed() 
	{
		GetTree().Paused = false;
		pm.Visible = false;
		
		//All below are temporary - just testing purposes only
		//Globals.Instance.Score = int.Parse(Score.SLabel.GetText());
		//Globals.Instance.ElapsedTime = TimerLabel.Elapsed;
		//GetTree().ChangeSceneToFile("res://Matthew/Scenes/end_screen.tscn");
	}
}

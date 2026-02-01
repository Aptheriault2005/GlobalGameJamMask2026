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
	
	public async override void _Pressed() {
		var tr = GetNode<TransitionScreen>("/root/TransitionScreen");
		await tr.Transition("res://LevisCode/levis_gym.tscn");
		Globals.Instance.Started = true;
	}
}

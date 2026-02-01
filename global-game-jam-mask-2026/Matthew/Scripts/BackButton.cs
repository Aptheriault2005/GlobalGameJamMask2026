using Godot;
using System;

public partial class BackButton : Button
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	public async override void _Pressed() {
		var tr = GetNode<TransitionScreen>("/root/TransitionScreen");
		await tr.Transition(Globals.Instance.PrevScene);
	}
}

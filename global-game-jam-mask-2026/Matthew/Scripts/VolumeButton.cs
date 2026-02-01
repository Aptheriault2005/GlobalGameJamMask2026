using Godot;
using System;

public partial class VolumeButton : Button
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
		SoundScene.sfxButton.Play();
		var tr = GetNode<TransitionScreen>("/root/TransitionScreen");
		await tr.Transition("res://Matthew/Scenes/volume_screen.tscn");
	}
}

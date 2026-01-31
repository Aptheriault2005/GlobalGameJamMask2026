using Godot;
using System;

public partial class MusicSlider : HSlider
{
	int music;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		 music = AudioServer.GetBusIndex("Music");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	public void OnValueChanged(double value) {
		AudioServer.SetBusVolumeDb(music, Mathf.LinearToDb((float) value));
	}
}

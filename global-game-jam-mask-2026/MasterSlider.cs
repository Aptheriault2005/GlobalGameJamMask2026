using Godot;
using System;

public partial class MasterSlider : HSlider
{
	int master;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		 master = AudioServer.GetBusIndex("Master");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	public void OnValueChanged(double value) {
		AudioServer.SetBusVolumeDb(master, Mathf.LinearToDb((float) value));
	}
}

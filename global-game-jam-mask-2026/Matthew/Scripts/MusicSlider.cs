using Godot;
using System;

public partial class MusicSlider : HSlider
{
	
	[Export] public String busName;
	private int busIdx;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		busIdx = AudioServer.GetBusIndex(busName);
		
		this.Value = Mathf.DbToLinear(AudioServer.GetBusVolumeDb(busIdx));
	}
	
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	private void _onValueChanged(float value){
		AudioServer.SetBusVolumeDb(busIdx, Mathf.LinearToDb(value));
	}
}

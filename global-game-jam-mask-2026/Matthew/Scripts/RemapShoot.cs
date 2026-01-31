using Godot;
using System;

public partial class RemapShoot : Button
{
	
	public static Button RmpShoot;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		this.SetText("Shoot: " + InputMap.ActionGetEvents("fire")[0].AsText());
		RmpShoot = this;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	public override void _Pressed() {
		WaitUserInput.wui.Remapping("shoot");
	}
}

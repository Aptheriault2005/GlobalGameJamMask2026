using Godot;
using System;

public partial class RemapRight : Button
{
	public static Button RmpRight;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		this.SetText("Right: " + InputMap.ActionGetEvents("ui_right")[0].AsText());
		RmpRight = this;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	public override void _Pressed() {
		WaitUserInput.wui.Remapping("right");
	}
}

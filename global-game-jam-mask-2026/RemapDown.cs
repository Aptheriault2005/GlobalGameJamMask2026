using Godot;
using System;

public partial class RemapDown : Button
{
	public static Button RmpDown;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		this.SetText("Down: " + InputMap.ActionGetEvents("ui_down")[0].AsText());
		RmpDown = this;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	public override void _Pressed() {
		WaitUserInput.wui.Remapping("down");
	}
}

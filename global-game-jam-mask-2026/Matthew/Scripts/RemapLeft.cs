using Godot;
using System;

public partial class RemapLeft : Button
{
	public static Button RmpLeft;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		this.SetText("Left: " + InputMap.ActionGetEvents("ui_left")[0].AsText());
		RmpLeft = this;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	public override void _Pressed() {
		WaitUserInput.wui.Remapping("left");
	}
}

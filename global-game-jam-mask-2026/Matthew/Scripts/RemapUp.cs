using Godot;
using System;

public partial class RemapUp : Button
{
	public static Button RmpUp;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		this.SetText("Up: " + InputMap.ActionGetEvents("ui_up")[0].AsText());
		RmpUp = this;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	public override void _Pressed() {
		WaitUserInput.wui.Remapping("up");
	}
}

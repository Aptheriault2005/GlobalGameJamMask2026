using Godot;
using System;

public partial class RemapLeft : Button
{
	
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		this.SetText("Left: " + InputMap.ActionGetEvents("ui_left")[0].AsText());
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	public override void _Pressed() {
		InputMap.ActionEraseEvents("ui_left");
		this.SetText("Select new control");
		
		ChangeControls();
		//var keyEvent = new InputEventKey();
		//keyEvent.SetKeycode(Key.A);
		//InputMap.ActionAddEvent("ui_left", keyEvent);
		//this.SetText("Left: " + InputMap.ActionGetEvents("ui_left")[0].AsText());
	}
	
	private void ChangeControls() {
		var keyEvent = new InputEventKey();
		
		while (!Input.IsAnythingPressed()) {
			if (Input.IsAnythingPressed()) {
				keyEvent.SetKeycode(InputEve)
				break;
			}
			else {
				continue;
			}
		}
		
		
	}
}

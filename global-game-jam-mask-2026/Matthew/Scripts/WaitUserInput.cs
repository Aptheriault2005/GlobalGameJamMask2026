using Godot;
using System;

public partial class WaitUserInput : CanvasLayer
{
	public static WaitUserInput wui;
	
	private bool RemappingActive;
	
	private bool left;
	private bool right;
	private bool up;
	private bool down;
	private bool shoot;
	
	InputEventKey keyEvent = new InputEventKey();
	
	public override void _EnterTree() {
		wui = this;
	}
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		RemappingActive = false;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	public override void _Input(InputEvent @event) {
		if (@event is InputEventKey newInput && newInput.Pressed && RemappingActive) {
			keyEvent.SetKeycode(newInput.Keycode);
			
			if (left) {
				InputMap.ActionEraseEvents("ui_left");
				InputMap.ActionAddEvent("ui_left", keyEvent);
				RemapLeft.RmpLeft.SetText("Left: " + InputMap.ActionGetEvents("ui_left")[0].AsText());
				left = false;
			}
			if (right) {
				InputMap.ActionEraseEvents("ui_right");
				InputMap.ActionAddEvent("ui_right", keyEvent);
				RemapRight.RmpRight.SetText("Right: " + InputMap.ActionGetEvents("ui_right")[0].AsText());
				right = false;
			}
			else if (up) {
				InputMap.ActionEraseEvents("ui_up");
				InputMap.ActionAddEvent("ui_up", keyEvent);
				RemapUp.RmpUp.SetText("Up: " + InputMap.ActionGetEvents("ui_up")[0].AsText());
				up = false;
			}
			else if (down) {
				InputMap.ActionEraseEvents("ui_down");
				InputMap.ActionAddEvent("ui_down", keyEvent);
				RemapDown.RmpDown.SetText("Down: " + InputMap.ActionGetEvents("ui_up")[0].AsText());
				down = false;
			}
			else if (shoot) {
				InputMap.ActionEraseEvents("fire");
				InputMap.ActionAddEvent("fire", keyEvent);
				RemapShoot.RmpShoot.SetText("Shoot: " + InputMap.ActionGetEvents("fire")[0].AsText());
				shoot = false;
			}
			
			RemappingActive = false;
			
			GetTree().ReloadCurrentScene();
		}
	}
	
	public void Remapping(string control) {
			RemappingActive = true;
			if (control == "left") {
				left = true;
			}
			else if (control == "right") {
				right = true;
			}
			else if (control == "up") {
				up = true;
			}
			else if (control == "down") {
				down = true;
			}
			else if (control == "shoot") {
				shoot = true;
			}
	}
}

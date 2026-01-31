using Godot;
using System;

public partial class Testing : Area2D
{
	[Export]
	public int Speed {get; set;} = 400;
		
	public Vector2 ScreenSize;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		ScreenSize = GetViewportRect().Size;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		var velocity = Vector2.Zero; // The player's movement vector.

	if (Input.IsActionPressed("ui_right"))
	{
		velocity.X += 1;
	}

	if (Input.IsActionPressed("ui_left"))
	{
		velocity.X -= 1;
	}

	if (Input.IsActionPressed("ui_down"))
	{
		velocity.Y += 1;
	}

	if (Input.IsActionPressed("ui_up"))
	{
		velocity.Y -= 1;
	}
	var animatedSprite2D = GetNode<AnimatedSprite2D>("animsprite2d");

	if (velocity.Length() > 0)
	{
		velocity = velocity.Normalized() * Speed;
		animatedSprite2D.Play();
	}
	else
	{
		animatedSprite2D.Stop();
	}
	Position += velocity * (float)delta;
	Position = new Vector2(
		x: Mathf.Clamp(Position.X, 0, ScreenSize.X),
		y: Mathf.Clamp(Position.Y, 0, ScreenSize.Y)
		);
	
	// Needs to change to settings overlay or smth
	if (Input.IsActionPressed("ui_cancel")) {
		GetTree().ChangeSceneToFile("res://settings_screen.tscn");
	}
	
	}
}

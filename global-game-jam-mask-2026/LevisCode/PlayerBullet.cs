using Godot;
using System;

public partial class PlayerBullet : Area2D
{
	public float speed = 500.0f;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GetNode<Sprite2D>("Sprite2D").Modulate = new Color(0, 0.8f, 1);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		MoveLocalY(speed * (float)delta);
	}
	
	public void timeout()
	{
		QueueFree();
	}
}

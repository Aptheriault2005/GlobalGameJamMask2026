using Godot;
using System;

public partial class EnemyBullet : Node2D
{
	[Export] public float speed = 500.0f;
	[Export] private HitBox hitBox;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GetNode<Sprite2D>("Sprite2D").Modulate = new Color(1, 0, 0);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		MoveLocalX(speed * (float)delta);
	}

	public void timeout()
	{
		QueueFree();
	}
}

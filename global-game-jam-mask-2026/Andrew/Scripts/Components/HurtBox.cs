using Godot;
using System;

public partial class HurtBox : Area2D
{
	[Export] public float Radius = 10;
	[Export] private CollisionShape2D collisionShape2D;

	public override void _Ready()
	{
		SetCollisionCircle(Radius);
	}

	private void SetCollisionCircle(float radius)
	{
		CircleShape2D collisionCircle = new CircleShape2D();
		collisionCircle.Radius = radius;
		collisionShape2D.Shape = collisionCircle;
	}
}

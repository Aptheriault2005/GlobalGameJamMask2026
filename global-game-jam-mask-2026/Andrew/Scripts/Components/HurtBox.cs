using Godot;
using System;

public partial class HurtBox : Area2D
{
	[Export] public float Radius = 10;
	[Export] private CollisionShape2D collisionShape2D;
	public bool canBeHit { get; private set; } = true;

	public override void _Ready()
	{
		SetCollisionCircle(Radius);
	}

	// public void DisableHurtBox()
	// {
	// 	canBeHit = false;
	// }

	private void SetCollisionCircle(float radius)
	{
		CircleShape2D collisionCircle = new CircleShape2D();
		collisionCircle.Radius = radius;
		collisionShape2D.Shape = collisionCircle;
	}
}

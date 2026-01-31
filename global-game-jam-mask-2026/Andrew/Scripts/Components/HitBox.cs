using Godot;
using System;

public partial class HitBox : Area2D
{
	[Export] public float Damage = 10;
	[Export] public float Radius = 10;
	[Export] private CollisionShape2D collisionShape2D;

	public override void _Ready()
	{
		SetCollisionCircle(Radius);
	}

	public override void _Process(double delta)
	{
		// if (Engine.IsEditorHint())
		// {
		// 	SetCollisionCircle(Radius);
		// }
	}

	public void OnBodyEntered(Node2D body)
	{
		HealthComponent healthComponent = null;

		if (body.GetChildren != null)
		{
			foreach (Node child in body.GetChildren())
			{
				if (child is HealthComponent)
				{
					healthComponent = child as HealthComponent;
				}
			}
		}

		if (healthComponent != null)
		{
			healthComponent.Damage(Damage);
		}
	}

	private void SetCollisionCircle(float radius)
	{
		CircleShape2D collisionCircle = new CircleShape2D();
		collisionCircle.Radius = radius;
		collisionShape2D.Shape = collisionCircle;
	}
}

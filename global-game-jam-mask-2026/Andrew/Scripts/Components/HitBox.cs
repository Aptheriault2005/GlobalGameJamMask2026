using Godot;
using System;

public partial class HitBox : Area2D
{
	[Export] public float Damage = 10;
	[Export] public float Radius = 10;
	[Export] private CollisionShape2D collisionShape2D;
	[Export] public StringName TargetMetadata;

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
		return;
		// GD.Print(body.Name, " found");

		// if (!body.HasMeta(TargetMetadata))
		// {
		// 	return;
		// }


		// GD.Print(body.Name, " hit");
		// HealthComponent healthComponent = null;

		// if (body.GetChildren != null)
		// {
		// 	foreach (Node child in body.GetChildren())
		// 	{
		// 		if (child is HealthComponent)
		// 		{
		// 			healthComponent = child as HealthComponent;
		// 		}
		// 	}
		// }

		// if (healthComponent != null)
		// {
		// 	healthComponent.Damage(Damage);
		// }
	}

	public void OnAreaEntered(Area2D area)
	{
		// GD.Print(area.GetParent().Name, " found");

		if (!area.GetParent().HasMeta(TargetMetadata))
		{
			return;
		}

		// HurtBox hurtBox = area as HurtBox;

		// if (!hurtBox.canBeHit)
		// {
		// 	return;
		// }

		// GD.Print(area.GetParent().Name, " hit");
		HealthComponent healthComponent = null;

		if (area.GetParent().GetChildren != null)
		{
			foreach (Node child in area.GetParent().GetChildren())
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
			GetParent().QueueFree();
		}
	}

	private void SetCollisionCircle(float radius)
	{
		CircleShape2D collisionCircle = new CircleShape2D();
		collisionCircle.Radius = radius;
		collisionShape2D.Shape = collisionCircle;
	}
}

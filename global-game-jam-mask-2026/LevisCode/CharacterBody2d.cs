using Godot;
using System;

public partial class CharacterBody2d : CharacterBody2D
{
	public const float Speed = 300.0f;
	private Timer cooldown;
	private Timer bulletDirection;
	
	[Export]
	public PackedScene bullet { get; set; }

	public override void _Ready()
	{
		cooldown = GetNode<Timer>("Cooldown");
		bulletDirection = GetNode<Timer>("Direction");
	}

	public override void _PhysicsProcess(double delta)
	{
		if (Input.IsActionPressed("fire") && cooldown.TimeLeft == 0)
		{
			Node2D b = ResourceLoader.Load<PackedScene>("res://LevisCode/player_bullet.tscn").Instantiate<Node2D>();
			AddSibling(b);
			b.Position = Position;
			b.Rotation = (float)bulletDirection.TimeLeft * 5;
			Node2D b2 = ResourceLoader.Load<PackedScene>("res://LevisCode/player_bullet.tscn").Instantiate<Node2D>();
			AddSibling(b2);
			b2.Position = Position;
			b2.Rotation = -(float)bulletDirection.TimeLeft * 5;
			cooldown.Start();
		}
		
		//----------------------//
		
		Vector2 velocity = Velocity;

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		if (direction != Vector2.Zero)
		{
			velocity.X = direction.X * Speed;
			velocity.Y = direction.Y * Speed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
			velocity.Y = Mathf.MoveToward(Velocity.Y, 0, Speed);
		}

		Velocity = velocity;
		MoveAndSlide();
	}
}

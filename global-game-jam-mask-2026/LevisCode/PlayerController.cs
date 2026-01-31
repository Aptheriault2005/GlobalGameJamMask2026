using Godot;
using System;

public partial class PlayerController : CharacterBody2D
{
	public const float Speed = 300.0f;
	[Export] private GhostbusterSprayPattern gbsp;
	[Export] private SpiralSprayPattern ssp;
	[Export] private PulseSprayPattern psp;
	private AnimatedSprite2D playerSprite;
	private int sprayPattern = 0;
	private float sinTimer = 0.0f;
	
	[Export]
	public PackedScene bullet { get; set; }
	
	public static PlayerController Player;
	
	public override void _EnterTree()
	{
		Player = this;
	}

	public override void _Ready()
	{
		playerSprite = GetNode<AnimatedSprite2D>("Sprite2D");
	}

	public override void _PhysicsProcess(double delta)
	{
		if (Input.IsActionPressed("fire"))
		{
			switch (sprayPattern)
			{
				case 0:
					gbsp.Spray();
					break;
				case 1:
					ssp.Spray();
					break;
				case 2:
					psp.Spray();
					break;
			}
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
		
		if (direction.X == 1) playerSprite.SetAnimation("Move_right");
		else if (direction.X == -1) playerSprite.SetAnimation("Move_left");
		
		if (direction.Y == 1) playerSprite.SetAnimation("Move_down");
		else if (direction.Y == -1) playerSprite.SetAnimation("Move_up");

		playerSprite.Position = new Vector2(0, playerSprite.Position.Y + ((float)Math.Sin(sinTimer * 4) / 4));
		sinTimer += (float)delta;

		Velocity = velocity;
		MoveAndSlide();
	}
	
	public void SwapPowerup(int powerup)
	{
		GD.Print("swap me please");
		sprayPattern = powerup;
	}
}

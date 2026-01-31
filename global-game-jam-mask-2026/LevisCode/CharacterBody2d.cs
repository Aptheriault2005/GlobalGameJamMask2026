using Godot;
using System;

public partial class CharacterBody2d : CharacterBody2D
{
	public const float Speed = 300.0f;
	[Export] private GhostbusterSprayPattern gbsp;
	[Export] private SpiralSprayPattern ssp;
	[Export] private PulseSprayPattern psp;
	private int sprayPattern = 0;
	
	[Export]
	public PackedScene bullet { get; set; }

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
		
		if (Input.IsActionJustPressed("DEBUG_switch"))
		{
			if (sprayPattern == 2) sprayPattern = 0;
			else sprayPattern++;
			switch (sprayPattern)
			{
				case 0:
					GD.Print("Ghostbuster");
					break;
				case 1:
					GD.Print("Spiral");
					break;
				case 2:
					GD.Print("Pulse");
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

		Velocity = velocity;
		MoveAndSlide();
	}
}

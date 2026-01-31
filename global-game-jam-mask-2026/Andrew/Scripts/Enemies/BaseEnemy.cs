using Godot;
using System;

public partial class BaseEnemy : Node2D
{
	[Export] public HealthComponent healthComponent { get; private set; }
	[Export] public PlayerOrbitMovementComponent playerOrbitMovementComponent { get; private set; }


	public override void _Ready()
	{

	}

	public override void _Process(double delta)
	{

	}
}

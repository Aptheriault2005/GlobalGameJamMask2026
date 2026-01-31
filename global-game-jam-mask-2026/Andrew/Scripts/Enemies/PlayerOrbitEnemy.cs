using Godot;
using System;

public partial class PlayerOrbitEnemy : BaseEnemy
{
	[Export] public HealthComponent healthComponent { get; private set; }
	[Export] public PlayerOrbitMovementComponent playerOrbitMovementComponent { get; private set; }
}

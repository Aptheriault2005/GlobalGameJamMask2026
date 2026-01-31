using Godot;
using System;

public partial class EnvironmentOrbitEnemy : BaseEnemy
{
	[Export] public HealthComponent healthComponent { get; private set; }
	[Export] public EnvironmentOrbitMovementComponent environmentOrbitMovementComponent { get; private set; }
}

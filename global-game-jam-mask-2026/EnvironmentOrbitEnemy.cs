using Godot;
using System;

public partial class EnvironmentOrbitEnemy : BaseEnemy
{
	[Export] public EnvironmentOrbitMovementComponent environmentOrbitMovementComponent { get; private set; }
}

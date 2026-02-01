using Godot;
using System;

public partial class EnvironmentOrbitEnemy : BaseEnemy
{
	[Export] public HealthComponent healthComponent { get; private set; }
	[Export] public EnvironmentOrbitMovementComponent environmentOrbitMovementComponent { get; private set; }

	public override void _Ready()
	{
		healthComponent.Death += OnDeath;
		healthComponent.HealthChanged += OnHealthChanged;
	}

    public override void _ExitTree()
    {
        healthComponent.Death -= OnDeath;
		healthComponent.HealthChanged -= OnHealthChanged;
    }
}

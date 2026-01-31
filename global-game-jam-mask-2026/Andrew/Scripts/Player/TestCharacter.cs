using Godot;
using System;

public partial class TestCharacter : CharacterBody2D
{
	[Export] private float Speed = 1000;
	[Export] public HealthComponent healthComponent { get; private set; }

	public static TestCharacter currentPlayer;

	public override void _EnterTree()
	{
		currentPlayer = this;
	}

    public override void _ExitTree()
    {
        healthComponent.HealthChanged -= OnHealthChanged;
		healthComponent.Death -= OnDeath;
    }

	public override void _Ready()
	{
		healthComponent.HealthChanged += OnHealthChanged;
		healthComponent.Death += OnDeath;
	}

	public override void _PhysicsProcess(double delta)
	{
		Velocity = Speed * Input.GetVector("move_left", "move_right", "move_up", "move_down");
		MoveAndSlide();
	}

	public override void _Input(InputEvent @event)
	{
		if (Input.IsActionJustPressed("heal"))
		{
			healthComponent.Damage(10);
		}
		if (Input.IsActionJustPressed("hurt"))
		{
			healthComponent.Heal(10);
		}
	}

	public void OnDeath()
	{
		Hide();
		GD.Print("YOU DIED");
	}
	
	public void OnHealthChanged(float amount)
	{
		GD.Print("New Health: ", amount);
	}

}

using Godot;
using System;

public partial class HealthBar : PanelContainer
{
	[Export] private Node2D NodeToTrack;
	[Export] private ProgressBar healthBar;
	[Export] private Label healthLabel;
	private HealthComponent healthComponent;

	public override void _Ready()
	{
		FindHealthComponent();
		if (healthComponent != null)
		{
			healthComponent.Death += OnDeath;
			healthComponent.HealthChanged += OnHealthChanged;
			UpdateHealthBarText(healthComponent.MaxHealth);
			UpdateHealthbarPercentage(healthComponent.MaxHealth);
		}
		else
		{
			GD.PrintErr("NodeToTrack doesn't have a health component");
		}
	}

    public override void _Input(InputEvent @event)
    {
		if (Input.IsActionJustPressed("heal"))
		{
			healthComponent.Heal(10);
		}
		else if (Input.IsActionJustPressed("hurt"))
		{
			healthComponent.Damage(10);
		}
    }

	public override void _ExitTree()
	{
		if (healthComponent != null)
		{
			healthComponent.Death -= OnDeath;
			healthComponent.HealthChanged -= OnHealthChanged;
		}
	}

	public void OnDeath()
	{
		healthLabel.Text = "DEAD";
		UpdateHealthbarPercentage(0);
		healthLabel.Modulate = new Color(1, 0, 0, 1);
	}

	public void OnHealthChanged(float newHealth)
	{
		UpdateHealthBarText(newHealth);
		UpdateHealthbarPercentage(newHealth);
	}

	private void FindHealthComponent()
	{
		if (NodeToTrack.GetChildren() != null)
		{
			foreach (Node child in NodeToTrack.GetChildren())
			{
				if (child is HealthComponent)
				{
					healthComponent = child as HealthComponent;
				}
			}
		}
	}

	private void UpdateHealthbarPercentage(float newHealth)
	{
		healthBar.Value = newHealth / healthComponent.MaxHealth;
	}
	
	private void UpdateHealthBarText(float newHealth)
	{
		healthLabel.Text = "Health: " + newHealth.ToString() + " / " + healthComponent.MaxHealth.ToString();
	}
}

using Godot;
using System;

public partial class HealthComponent : Node
{
	[Export] public float MaxHealth { get; private set; }
	public float CurrentHealth { get; private set; }

	public Action<float> HealthChanged;
	public Action Death;
	
	// I am so sorry - Levi
	[Export] public Sprite2D modulateSprite;
	private bool StartAnimating = false;
	private float AnimTime = 0.0f;

	public override void _Ready()
	{
		CurrentHealth = MaxHealth;
	}
	
	public override void _Process(double delta)
	{
		if (!StartAnimating) return;
		modulateSprite.Modulate = new Color(1, 1-(AnimTime*4), 1-(AnimTime*4));
		AnimTime -= (float) delta;
		if (AnimTime <= 0) StartAnimating = false;
	}

	public void Damage(float amount)
	{
		if (CurrentHealth - amount <= 0)
		{
			Death?.Invoke();
		}
		else
		{
			CurrentHealth -= amount;
			HealthChanged?.Invoke(CurrentHealth);
			//--------------------//
			AnimTime = 0.25f;
			StartAnimating = true;
		}
	}

	public void Heal(float amount)
	{
		CurrentHealth += amount;
		CurrentHealth = Mathf.Clamp(CurrentHealth, 0, MaxHealth);
		HealthChanged?.Invoke(CurrentHealth);
	}

}

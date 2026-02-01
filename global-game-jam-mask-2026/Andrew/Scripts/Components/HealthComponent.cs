using Godot;
using System;

public partial class HealthComponent : Node
{
	[Export] public float MaxHealth { get; private set; }
	public float CurrentHealth { get; private set; }

	public Action<float> HealthChanged;
	public Action Death;
	
	// I am so sorry - Levi
	// [Export] public Sprite2D modulateSprite;
	// [Export] public Area2D hurtbox;
	// [Export] public Node bulletPattern;
	// [Export] public HomingPattern hp;
	// private bool StartAnimating = false;
	// private bool isDying = false;
	// private float AnimTime = 0.0f;
	// private float DeathAnimTime = 0.0f;

	public override void _Ready()
	{
		CurrentHealth = MaxHealth;
	}
	
	// public override void _Process(double delta)
	// {
	// 	if (isDying && bulletPattern.GetChildCount() == 1) Death?.Invoke();
	// 	if (!StartAnimating) return;
	// 	if (isDying)
	// 	{
	// 		modulateSprite.Modulate = new Color(1, 1, 1, DeathAnimTime);
	// 		modulateSprite.Scale = new Vector2(DeathAnimTime, DeathAnimTime);
	// 	} 
	// 	else 
	// 	{
	// 		modulateSprite.Modulate = new Color(1, 1-(AnimTime*4), 1-(AnimTime*4));
	// 	}
	// 	AnimTime -= (float) delta;
	// 	DeathAnimTime -= (float) delta;
	// 	if (AnimTime <= 0 && DeathAnimTime <= 0) 
	// 	{
	// 		StartAnimating = false;
	// 	}
	// }

	public void Damage(float amount)
	{
		if (CurrentHealth - amount <= 0)
        {
            // hurtbox.ProcessMode = Node.ProcessModeEnum.Disabled;
            // hp.active = false;
            Death?.Invoke();
			// DeathAnimTime = 1.0f;
			// StartAnimating = true;
			// isDying = true;
		}
		else
		{
			CurrentHealth -= amount;
			HealthChanged?.Invoke(CurrentHealth);
			//--------------------//
			// AnimTime = 0.25f;
			// StartAnimating = true;
		}
	}

	public void Heal(float amount)
	{
		CurrentHealth += amount;
		CurrentHealth = Mathf.Clamp(CurrentHealth, 0, MaxHealth);
		HealthChanged?.Invoke(CurrentHealth);
	}

}

using Godot;
using System;

public partial class HealthComponent : Node
{
    [Export] public float MaxHealth { get; private set; }
    public float CurrentHealth { get; private set; }

    public Action<float> HealthChanged;
    public Action Death;

    public override void _Ready()
    {
        CurrentHealth = MaxHealth;
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
        }
    }

    public void Heal(float amount)
    {
        CurrentHealth += amount;
        CurrentHealth = Mathf.Clamp(CurrentHealth, 0, MaxHealth);
        HealthChanged?.Invoke(CurrentHealth);
    }

}

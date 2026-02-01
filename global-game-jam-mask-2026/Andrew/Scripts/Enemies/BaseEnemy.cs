using Godot;
using System;

[GlobalClass, Tool]
public partial class BaseEnemy : Node2D
{
    public void OnHealthChanged(float amount)
    {

    }
    
    public void OnDeath()
    {
        QueueFree();
    }
}

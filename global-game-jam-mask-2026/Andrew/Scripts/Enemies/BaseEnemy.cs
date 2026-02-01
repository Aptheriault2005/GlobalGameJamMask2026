using Godot;
using System;

[GlobalClass, Tool]
public partial class BaseEnemy : Node2D
{
	[Export] int PointsOnDeath = 5;
	public void OnHealthChanged(float amount)
	{

	}
	
	public void OnDeath()
	{
		EnemyManager.enemyManager.RemoveEnemy(this);
		Score.AddScore(PointsOnDeath);
		QueueFree();
	}
}

using Godot;
using System;

public partial class OrbitPoint : Node2D
{
	[Export] public BaseEnemy EnemyAtPoint { get; private set; } = null;

	public void SetEnemyAtPoint(BaseEnemy enemy)
	{
		EnemyAtPoint = enemy;
	}

	public bool IsValidPoint()
	{
		if (EnemyAtPoint == null)
		{
			return true;
		}
		else
		{
			return false;
		}
	}
	
}

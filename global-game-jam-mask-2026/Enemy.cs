using Godot;
using System;

public partial class Enemy : Node2D
{
	[Export] private EnemyController enemyController;
	[Export] public float MoveSpeed;
	[Export] public float OrbitFrequency;
	[Export] public float OrbitDistance;

	public override void _Ready()
	{
		
	}
}

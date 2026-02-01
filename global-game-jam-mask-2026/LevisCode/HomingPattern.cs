using Godot;
using System;

public partial class HomingPattern : Node
{
	private Timer cooldown;
	private Node2D pc;
	public bool active = true;
	
	public override void _Ready()
	{
		cooldown = GetNode<Timer>("Cooldown");
		pc = GetNode<Node2D>("..");
	}
	
	public override void _PhysicsProcess(double delta)
	{
		if (!active) return;
		if (cooldown.TimeLeft != 0) return;
		Node2D b = ResourceLoader.Load<PackedScene>("res://LevisCode/enemy_bullet.tscn").Instantiate<Node2D>();

		EnemyManager.enemyManager.EnemyBulletContainer.AddChild(b);

		b.Position = pc.Position;
		Vector2 otherPos = PlayerController.GetPlayerPosition();
		b.Rotation = (float) Math.Atan2((otherPos.Y - b.Position.Y), (otherPos.X - b.Position.X));
		cooldown.Start();
	}
}

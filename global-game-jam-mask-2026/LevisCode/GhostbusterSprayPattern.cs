using Godot;
using System;

public partial class GhostbusterSprayPattern : Node2D
{
	private Timer cooldown;
	private Timer bulletDirection;
	
	public override void _Ready()
	{
		cooldown = GetNode<Timer>("Cooldown");
		bulletDirection = GetNode<Timer>("Direction");
	}
	
	public void Spray()
	{
		if (cooldown.TimeLeft != 0) return;
		Node2D b = ResourceLoader.Load<PackedScene>("res://LevisCode/player_bullet.tscn").Instantiate<Node2D>();
		AddSibling(b);
		b.Position = Position;
		b.Rotation = (float)bulletDirection.TimeLeft * 5;
		Node2D b2 = ResourceLoader.Load<PackedScene>("res://LevisCode/player_bullet.tscn").Instantiate<Node2D>();
		AddSibling(b2);
		b2.Position = Position;
		b2.Rotation = -(float)bulletDirection.TimeLeft * 5;
		cooldown.Start();
	}
}

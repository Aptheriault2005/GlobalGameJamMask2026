using Godot;
using System;

public partial class SpiralSprayPattern : Node
{
	private Timer cooldown;
	private Timer bulletDirection;
	private CharacterBody2D pc;
	
	public override void _Ready()
	{
		cooldown = GetNode<Timer>("Cooldown");
		bulletDirection = GetNode<Timer>("Direction");
		pc = GetNode<CharacterBody2D>("..");
	}
	
	public void Spray()
	{
		if (cooldown.TimeLeft != 0) return;
		Node2D b = ResourceLoader.Load<PackedScene>("res://LevisCode/player_bullet.tscn").Instantiate<Node2D>();
		AddChild(b);
		b.Position = pc.Position;
		b.Rotation = (float)bulletDirection.TimeLeft * 5;
		Node2D b2 = ResourceLoader.Load<PackedScene>("res://LevisCode/player_bullet.tscn").Instantiate<Node2D>();
		AddChild(b2);
		b2.Position = pc.Position;
		b2.Rotation = ((float)bulletDirection.TimeLeft + (float)Math.PI) * 5;
		cooldown.Start();
	}
}

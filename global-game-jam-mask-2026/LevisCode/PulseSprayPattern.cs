using Godot;
using System;

public partial class PulseSprayPattern : Node
{
	private Timer cooldown;
	private CharacterBody2D pc;
	
	public override void _Ready()
	{
		cooldown = GetNode<Timer>("Cooldown");
		pc = GetNode<CharacterBody2D>("..");
	}
	
	public void Spray()
	{
		if (cooldown.TimeLeft != 0) return;
		for (int i = 0; i < 16; i++)
		{
			Node2D b = ResourceLoader.Load<PackedScene>("res://LevisCode/player_bullet.tscn").Instantiate<Node2D>();
			AddChild(b);
			b.Position = pc.Position;
			b.Rotation = i * 0.393f;
		}
		cooldown.Start();
	}
}

using Godot;
using System;

public partial class PulseSprayPattern : Node2D
{
	private Timer cooldown;
	
	public override void _Ready()
	{
		cooldown = GetNode<Timer>("Cooldown");
	}
	
	public void Spray()
	{
		if (cooldown.TimeLeft != 0) return;
		for (int i = 0; i < 16; i++)
		{
			Node2D b = ResourceLoader.Load<PackedScene>("res://LevisCode/player_bullet.tscn").Instantiate<Node2D>();
			AddSibling(b);
			b.Position = Position;
			b.Rotation = i * 0.393f;
		}
	}
}

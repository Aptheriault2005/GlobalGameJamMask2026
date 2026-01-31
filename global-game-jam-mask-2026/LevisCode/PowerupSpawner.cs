using Godot;
using System;

public partial class PowerupSpawner : Node2D
{
	private Timer timer;
	Random rnd = new Random();
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		timer = GetNode<Timer>("Timer");
	}

	public void Timeout()
	{
		Position = new Vector2(rnd.Next(100, 1800), -100);
		Powerup p = ResourceLoader.Load<PackedScene>("res://LevisCode/powerup.tscn").Instantiate<Powerup>();
		AddSibling(p);
		p.Position = Position;
		p.value = rnd.Next(0, 3);
		p.Recolor();
	}
}

using Godot;
using System;

public partial class Powerup : Area2D
{
	[Export] private PlayerController player;
	public float speed = 100.0f;
	[Export] public int value = 0;
	
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		MoveLocalY(speed * (float)delta);
		if (Position.Y >= 1080) QueueFree();
	}
	
	public new void BodyEntered(Node2D other)
	{
		if (other.HasNode("PlayerTag"))
		{
			PlayerController p = PlayerController.Player;
			if (p != null)
			{
				p.SwapPowerup(value);
			} else GD.Print("NULL NULL NULL");
			QueueFree();
		}
	}
	
	public void Recolor()
	{
		switch(value)
		{
			case 0:
				GetNode<Sprite2D>("Sprite2D").Modulate = new Color(0, 1, 0);
				break;
			case 1:
				GetNode<Sprite2D>("Sprite2D").Modulate = new Color(1, 0, 1);
				break;
			case 2:
				GetNode<Sprite2D>("Sprite2D").Modulate = new Color(1, 0, 0);
				break;
		}
	}
}

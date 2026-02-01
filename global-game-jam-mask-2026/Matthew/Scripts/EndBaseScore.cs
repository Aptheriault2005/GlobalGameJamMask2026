using Godot;
using System;

public partial class EndBaseScore : Label
{
	public static int baseScore;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		baseScore = Globals.Instance.Score;
		this.Text = "Score: " + baseScore;
	}
}

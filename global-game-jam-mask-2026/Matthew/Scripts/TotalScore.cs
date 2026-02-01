using Godot;
using System;

public partial class TotalScore : Label
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		this.Text = "Total Score: " + (EndBaseScore.baseScore + 500 * ((int) TimeScore.TotalTime));
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}

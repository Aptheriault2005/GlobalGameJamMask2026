using Godot;
using System;

public partial class TimeScore : Label
{
	public static double TotalTime;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		TotalTime = Globals.Instance.ElapsedTime;
		this.Text = "Time: " + ((int) TotalTime);
	}
}

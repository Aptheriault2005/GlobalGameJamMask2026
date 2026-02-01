using Godot;
using System;

public partial class TimerLabel : Label
{
	public static double Elapsed = 0.0;
	private Label TLabel;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		TLabel = this;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Elapsed += delta;
		TLabel.Text = "" + ((int) Elapsed);
	}
	
	private string FormatTime(double t) {
		int minutes = (int) (t / 60);
		int seconds = (int) (t % 60);
		return minutes + " : " + seconds;
	}
}

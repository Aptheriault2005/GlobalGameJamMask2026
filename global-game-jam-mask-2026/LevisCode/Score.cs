using Godot;
using System;

public partial class Score : Label
{
	private int score = 0;
	
	public static Score SLabel;
	public override void _EnterTree()
	{
		SLabel = this;
	}
	
	public void UpdateLabel()
	{
		Text = score.ToString();
	}
	
	public static void AddScore(int s)
	{
		SLabel.score += s;
		SLabel.UpdateLabel();
	}

	public int GetScore()
	{
		return score;
	}
}

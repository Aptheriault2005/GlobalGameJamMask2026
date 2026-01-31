using Godot;
using System;

public partial class PauseMenu : CanvasLayer
{
	Button Rtrn;
	Button Title;
	Button Quit;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Rtrn = new ReturnGame();
		Title = new TitleScreen();
		Quit = new QuitButton();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if ((this.Visible == false) && Globals.Instance.Started) 
		{
			Rtrn.Disabled = true;
			Title.Disabled = true;
			Quit.Disabled = true;
		}
	}
	
	
}

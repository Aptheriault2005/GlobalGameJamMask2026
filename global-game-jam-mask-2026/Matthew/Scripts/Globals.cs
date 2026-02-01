using Godot;
using System;
using System.Collections.Generic;

public partial class Globals : Node
{
	public static Globals Instance {get; private set;}
	public string PrevScene {get; set;}
	public int Score {get; set;}
	public double ElapsedTime {get; set;}
	
	//Better way?
	
	public bool Started {get; set;}
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Instance = this;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
}

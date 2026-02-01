using Godot;
using System;

public partial class SoundScene : Node
{
	
	public static AudioStreamPlayer master;
	public static AudioStreamPlayer music;
	public static AudioStreamPlayer sfxButton;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		master = GetNode<AudioStreamPlayer>("MasterStream");
		music = GetNode<AudioStreamPlayer>("MusicStream");
		sfxButton = GetNode<AudioStreamPlayer>("SFXStreamButton");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}

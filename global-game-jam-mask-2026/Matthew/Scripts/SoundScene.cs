using Godot;
using System;

public partial class SoundScene : Node
{
	
	public static AudioStreamPlayer master;
	public static AudioStreamPlayer music;
	public static AudioStreamPlayer sfxButton;
	public static AudioStreamPlayer sfxHit;
	public static AudioStreamPlayer sfxDeath;
	public static AudioStreamPlayer sfxShoot;
	public static AudioStreamPlayer sfxGrape;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		master = GetNode<AudioStreamPlayer>("MasterStream");
		music = GetNode<AudioStreamPlayer>("MusicStream");
		sfxButton = GetNode<AudioStreamPlayer>("SFXStreamButton");
		sfxHit = GetNode<AudioStreamPlayer>("SFXStreamHit");
		sfxDeath = GetNode<AudioStreamPlayer>("SFXStreamPlayerDeath");
		sfxShoot = GetNode<AudioStreamPlayer>("SFXStreamShoot");
		sfxGrape = GetNode<AudioStreamPlayer>("SFXStreamGrape");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}

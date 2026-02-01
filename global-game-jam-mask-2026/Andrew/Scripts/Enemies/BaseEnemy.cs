using Godot;
using System;

[GlobalClass, Tool]
public partial class BaseEnemy : Node2D
{
	[Export] public HealthComponent healthComponent { get; private set; }
	[Export] int PointsOnDeath = 5;
	[Export] public Sprite2D modulateSprite;
	[Export] public Godot.Collections.Array<Texture2D> randomSprite { get; set; }
	[Export] public HurtBox hurtbox;
	[Export] public HomingPattern bulletPattern;
	[Export] public Timer HitAnimTimer;
	[Export] public Timer DeathAnimTimer;
	protected float AnimTime = 0.0f;
	protected float DeathAnimTime = 0.0f;
	protected bool isAnimating = false;
	protected bool isDying = false;
	protected bool isHurting = false;
	
	public override void _Ready()
	{
		Random rnd = new Random();
		healthComponent.Death += OnDeath;
		healthComponent.HealthChanged += OnHealthChanged;
		modulateSprite.Texture = randomSprite[rnd.Next(0,5)];
	}

	public override void _ExitTree()
	{
		healthComponent.Death -= OnDeath;
		healthComponent.HealthChanged -= OnHealthChanged;
	}
	
	public override void _Process(double delta)
	{
		if (isDying)
		{
			modulateSprite.Modulate = new Color(1, 1, 1, DeathAnimTime);
			modulateSprite.Scale = new Vector2(DeathAnimTime, DeathAnimTime);
		} 
		else 
		{
			modulateSprite.Modulate = new Color(1, 1-(AnimTime*4), 1-(AnimTime*4));
		}
		AnimTime -= (float)delta;
		AnimTime = float.Clamp(AnimTime, 0, 10);
		DeathAnimTime -= (float) delta;
		if (AnimTime <= 0 && DeathAnimTime <= 0) 
		{
			isAnimating = false;
		}
	}

	public void OnHealthChanged(float amount)
	{
		HitAnimTimer.Start();
		if (!isAnimating)
		{
			AnimTime = 0.25f;
			isAnimating = true;
			isHurting = true;
		}
	}

	public void OnDeath()
	{
		if (!isDying)
		{
			//GD.Print("Start death timer");
			DeathAnimTimer.Start();
			DeathAnimTime = 1.0f;
			isAnimating = true;
			isDying = true;
		}
	}

	public void OnDeathTimerTimeout()
	{
		EnemyManager.enemyManager.RemoveEnemy(this);
		Score.AddScore(PointsOnDeath);
		QueueFree();
	}
	
	public void OnHitAnimTimerTimeout()
	{
		isAnimating = false;
		isHurting = false;
	}
}

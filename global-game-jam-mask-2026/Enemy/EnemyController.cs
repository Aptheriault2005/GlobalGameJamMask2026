using Godot;
using System;

public partial class EnemyController : Node
{
    [Export] public Enemy Enemy;
    [Export] public Timer Timer;

    public override void _Ready()
    {
        GD.Print(TestCharacter.currentPlayer.Name);
        Timer.WaitTime = Enemy.OrbitFrequency;
        Timer.Start();
    }

    public override void _Process(double delta)
    {
        MoveTowardsTarget(TestCharacter.currentPlayer, delta);
        //OrbitTarget(TestCharacter.currentPlayer, Enemy.OrbitDistance, delta);
    }

    private void MoveTowardsTarget(Node2D target, double delta)
    {
        Enemy.Position += Enemy.Position.DirectionTo(target.Position) * Enemy.MoveSpeed * (float)delta;
    }

    private void OrbitTarget(Node2D target, float distance, double delta)
    {
        Vector2 position;
        position.X = target.Position.X + (float)(distance * Math.Cos(2 * Math.PI * Timer.TimeLeft / Enemy.OrbitFrequency));
        position.Y = target.Position.Y + (float)(distance * Math.Sin(2 * Math.PI * Timer.TimeLeft / Enemy.OrbitFrequency));
        Enemy.Position = position;
    }
}

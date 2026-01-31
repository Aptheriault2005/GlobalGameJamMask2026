using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class EnemyManager : Node
{
    [Export] private Timer SpawnTimer;
    [Export] private Node EnemyContainer;
    [Export] private int MaxEnemyCount;
    [Export] private PackedScene EnemyScene;
    private Enemy[] Enemies = [];

    public override void _Ready()
    {
        SpawnEnemy();
    }

    public void OnTimerTimeout()
    {
        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        Enemy newEnemy = EnemyScene.Instantiate() as Enemy;
        Enemies.Append(newEnemy);
        EnemyContainer.AddChild(newEnemy);
    }
}

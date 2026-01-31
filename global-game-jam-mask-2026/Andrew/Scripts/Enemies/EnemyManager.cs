using Godot;
using Godot.Collections;
using System;
using System.Linq;

public partial class EnemyManager : Node
{
    [Export] public Timer SpawnTimer { get; private set; }
    [Export] public OrbitPointGenerator orbitPointGenerator { get; private set; }
    [Export] public Node2D PlayerOrbitsContainer { get; private set; }
    [Export] private Node EnemyContainer;
    [Export] private int MaxEnemyCount = 100;
    [Export] private PackedScene EnemyScene;
    [Export] private Array<BaseEnemy> Enemies = [];

    public static EnemyManager enemyManager;

    public override void _EnterTree()
    {
        enemyManager = this;
    }

    public override void _Ready()
    {
        SpawnEnemy();
    }

    public override void _PhysicsProcess(double delta)
    {
        PlayerOrbitsContainer.Position = TestCharacter.currentPlayer.Position;
    }

    public bool HasValidPlayerOrbitPoints()
    {
        foreach (Node node in PlayerOrbitsContainer.GetChildren())
        {
            if (node is OrbitPointGenerator)
            {
                OrbitPointGenerator orbitPointGenerator = node as OrbitPointGenerator;
                if (orbitPointGenerator.HasValidOrbits())
                {
                    return true;
                }
            }
        }

        return false;
    }

    public OrbitPoint FindValidPlayerOrbitPoint()
    {
        Array<OrbitPointGenerator> orbitPointGenerators = [];

        foreach (Node node in PlayerOrbitsContainer.GetChildren())
        {
            //GD.Print(node.Name, " found");
            if (node is OrbitPointGenerator)
            {
                OrbitPointGenerator orbitPointGenerator = node as OrbitPointGenerator;
                if (orbitPointGenerator.HasValidOrbits())
                {
                    //GD.Print(node.Name, " has valid orbits");
                    orbitPointGenerators.Add(orbitPointGenerator);
                }
            }
        }
        
        if (orbitPointGenerators.Count == 0)
        {
            return null;
        }
        return orbitPointGenerators.PickRandom().GetRandomValidOrbitNode();
    }

    public void OnTimerTimeout()
    {
        if (Enemies.Count < MaxEnemyCount)
        {
            GD.Print(Enemies.Count);
            if (HasValidPlayerOrbitPoints())
            {
                SpawnEnemy();
            }
            
        }
    }

    private void SpawnEnemy()
    {
        BaseEnemy newEnemy = EnemyScene.Instantiate() as BaseEnemy;
        //newEnemy.Position = ;
        newEnemy.Name = "Enemy" + Enemies.Count.ToString();
        EnemyContainer.AddChild(newEnemy);
        Enemies.Add(newEnemy);
    }
}

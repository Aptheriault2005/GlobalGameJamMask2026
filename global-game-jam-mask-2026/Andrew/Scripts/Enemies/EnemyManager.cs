using Godot;
using Godot.Collections;
using System;
using System.Linq;

public partial class EnemyManager : Node
{
    private PlayerController player;
    [Export] public Timer SpawnTimer { get; private set; }
    [Export] public Node2D PlayerOrbitsContainer { get; private set; }
    [Export] public Node2D EnvironmentOrbitsContainer { get; private set; }
    [Export] private Node EnemyContainer;
    [Export] private int MaxEnemyCount = 5;
    [Export] private PackedScene PlayerOrbitEnemyScene;
    [Export] private PackedScene EnvironmentOrbitEnemyScene;
    [Export] private Array<BaseEnemy> Enemies = [];

    public static EnemyManager enemyManager;

    public override void _EnterTree()
    {
        enemyManager = this;
    }

    public override void _Ready()
    {
        player = PlayerController.Player;
    }

    public override void _PhysicsProcess(double delta)
    {
        PlayerOrbitsContainer.Position = player.Position;
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
    
    public bool HasValidEnvironmentOrbitPoints()
    {
        foreach (Node node in EnvironmentOrbitsContainer.GetChildren())
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

    public OrbitPoint FindValidEnvironmentOrbitPoint()
    {
        Array<OrbitPointGenerator> orbitPointGenerators = [];

        foreach (Node node in EnvironmentOrbitsContainer.GetChildren())
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
            //GD.Print(Enemies.Count);
            SpawnEnemies();
        }
    }

    public void RemoveEnemy(BaseEnemy enemy)
    {
        Enemies.Remove(enemy);
    }

    private void SpawnEnemies()
    {
        if (HasValidPlayerOrbitPoints())
            {
                SpawnPlayerOrbitEnemy();
            }
            else if (HasValidEnvironmentOrbitPoints())
            {
                SpawnEnvironmentOrbitEnemy();
            }
    }

    private void SpawnPlayerOrbitEnemy()
    {
        PlayerOrbitEnemy newEnemy = PlayerOrbitEnemyScene.Instantiate() as PlayerOrbitEnemy;

        Vector2 spawnPos = new();
        RandomNumberGenerator rng = new();

        spawnPos.X = rng.RandiRange(0, 1920);
        spawnPos.Y = rng.RandiRange(0, 1080);

        newEnemy.Position = spawnPos;

        newEnemy.Name = "PlayerOrbitEnemy" + Enemies.Count.ToString();
        EnemyContainer.AddChild(newEnemy);
        Enemies.Add(newEnemy);
    }

    private void SpawnEnvironmentOrbitEnemy()
    {
        EnvironmentOrbitEnemy newEnemy = EnvironmentOrbitEnemyScene.Instantiate() as EnvironmentOrbitEnemy;

        Vector2 spawnPos = new();
        RandomNumberGenerator rng = new();

        spawnPos.X = rng.RandiRange(0, 1920);
        spawnPos.Y = rng.RandiRange(0, 1080);

        newEnemy.Position = spawnPos;

        newEnemy.Name = "EnvironmentOrbitEnemy" + Enemies.Count.ToString();
        EnemyContainer.AddChild(newEnemy);
        Enemies.Add(newEnemy);
    }
}

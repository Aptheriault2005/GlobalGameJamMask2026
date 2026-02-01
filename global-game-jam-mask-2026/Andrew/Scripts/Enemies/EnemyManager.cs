using Godot;
using Godot.Collections;
using System;
using System.Linq;

public partial class EnemyManager : Node
{
    [ExportCategory("References")]
    [Export] public Timer SpawnTimer { get; private set; }
    [Export] public Node2D PlayerOrbitsContainer { get; private set; }
    [Export] public Node2D EnvironmentOrbitsContainer { get; private set; }
    [Export] public Node EnemyContainer { get; private set; }

    [ExportCategory("Enemy Scenes")]
    [Export] private PackedScene PlayerOrbitEnemyScene;
    [Export] private PackedScene EnvironmentOrbitEnemyScene;

    [ExportCategory("Enemy Spawning")]
    [Export] private int MaxEnemyCount = 5;
    [Export] private float StartTimerWaitTime = 5.0f;
    [Export] private float MinTimerWaitTime = 0.1f;
    [Export] private float NextWaitTimeDecrement = 0.1f;
    [Export] private int MaxEnemyIncrementThresholdRate = 100;
    private int MaxEnemyIncrementThreshold;
    private float NextTimerWaitTime = 5.0f;

    public enum EnemyType
    {
        PlayerOrbitEnemy,
        EnvironmentOrbitEnemy
    }

	public static EnemyManager enemyManager;

    private Array<BaseEnemy> Enemies = [];
    private PlayerController player;

    public override void _EnterTree()
    {
        enemyManager = this;
    }

    public override void _Ready()
    {
        player = PlayerController.Player;
        SpawnTimer.Start(StartTimerWaitTime);

        NextTimerWaitTime = StartTimerWaitTime;
        MaxEnemyIncrementThreshold = MaxEnemyIncrementThresholdRate;
    }

    public override void _PhysicsProcess(double delta)
    {
        PlayerOrbitsContainer.Position = player.Position;

        if (Score.SLabel.GetScore() >= MaxEnemyIncrementThreshold)
        {
            MaxEnemyCount += 1;
            MaxEnemyIncrementThreshold += MaxEnemyIncrementThresholdRate;
        }
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
            NextTimerWaitTime = float.Clamp(NextTimerWaitTime - NextWaitTimeDecrement, MinTimerWaitTime, float.MaxValue);
            SpawnEnemies();
        }
        SpawnTimer.Start(NextTimerWaitTime);
    }

	public void RemoveEnemy(BaseEnemy enemy)
	{
		Enemies.Remove(enemy);
	}

    private void SpawnEnemies()
    {
        EnemyType[] allPossibleEnemyTypes = Enum.GetValues<EnemyType>();
        Array<EnemyType> validEnemyTypes = [];

        foreach (EnemyType enemyType in allPossibleEnemyTypes)
        {
            if (EnemyCanBeSpawned(enemyType))
            {
                validEnemyTypes.Add(enemyType);
            }
        }

        if (validEnemyTypes.Count == 0)
        {
            return;
        }

        EnemyType enemyToSpawn = validEnemyTypes.PickRandom();

        SpawnEnemy(enemyToSpawn);
    }

    private bool EnemyCanBeSpawned(EnemyType enemyType)
    {
        switch (enemyType)
        {
            case EnemyType.PlayerOrbitEnemy:
                return HasValidPlayerOrbitPoints();
            case EnemyType.EnvironmentOrbitEnemy:
                return HasValidEnvironmentOrbitPoints();
        }

        return false;
    }

    private void SpawnEnemy(EnemyType enemyType)
    {
        switch (enemyType)
        {
            case EnemyType.PlayerOrbitEnemy:
                if (HasValidPlayerOrbitPoints())
                {
                    SpawnPlayerOrbitEnemy();
                }
                break;
            case EnemyType.EnvironmentOrbitEnemy:
                if (HasValidEnvironmentOrbitPoints())
                {
                    SpawnEnvironmentOrbitEnemy();
                }
                break;
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

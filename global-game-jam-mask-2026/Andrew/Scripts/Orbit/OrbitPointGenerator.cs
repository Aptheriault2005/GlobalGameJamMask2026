using Godot;
using Godot.Collections;
using System;
using System.Linq;

public partial class OrbitPointGenerator : Node2D
{
    [Export] private PackedScene PointScene;
    //[Export] private bool generate = false;
    [Export] private Vector2 OrbitCenter = Vector2.Zero;
    [Export] private float OrbitSpeed = 1;
    [Export] private int OrbitPointCount = 8;
    [Export] private float OrbitPointDistance = 100;
    private Array<OrbitPoint> OrbitPoints = new();

    public override void _Process(double delta)
    {
        if (Engine.IsEditorHint())
        {
            // if (generate == true)
            // {
            //     SpawnOrbitPoints();
            //     generate = false;
            // }
        }
        else
        {
            Rotation += (float)(OrbitSpeed * delta);
        }
    }

    public override void _Ready()
    {
        SpawnOrbitPoints();
    }

    public bool HasValidOrbits()
    {
        Array<OrbitPoint> validOrbitPoints = [];

        foreach (OrbitPoint orbitPoint in OrbitPoints)
        {
            //GD.Print(orbitPoint.Name, " found");
            if (orbitPoint.IsValidPoint())
            {
                //GD.Print(orbitPoint.Name, " is valid");
                validOrbitPoints.Add(orbitPoint);
            }
        }

        if (validOrbitPoints.Count >= 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public OrbitPoint GetRandomValidOrbitNode()
    {
        Array<OrbitPoint> validOrbitPoints = [];

        foreach (OrbitPoint orbitPoint in OrbitPoints)
        {
            if (orbitPoint.IsValidPoint())
            {
                validOrbitPoints.Add(orbitPoint);
            }
        }

        OrbitPoint orbitNode = validOrbitPoints.PickRandom();
        return orbitNode;
    }

    private void SpawnOrbitPoints()
    {
        ClearData();
        for (int i = 0; i < OrbitPointCount; i++)
        {
            SpawnOrbitPoint(i);
        }
    }

    private void SpawnOrbitPoint(int i)
    {
        OrbitPoint orbitPoint = PointScene.Instantiate() as OrbitPoint;

        orbitPoint.Name = "Point" + i.ToString();

        Vector2 vectorAngle;
        vectorAngle.X = (float)Math.Cos(2.0 * Math.PI * i / OrbitPointCount);
        vectorAngle.Y = (float)Math.Sin(2.0 * Math.PI * i / OrbitPointCount);
        orbitPoint.Position = OrbitCenter + (vectorAngle * OrbitPointDistance);

        AddChild(orbitPoint);
        OrbitPoints.Add(orbitPoint);
    }

    private void ClearData()
    {
        OrbitPoints = new();

        if (GetChildCount() != 0)
        {
            foreach (Node child in GetChildren())
            {
                child.QueueFree();
            }
        }
    }
}

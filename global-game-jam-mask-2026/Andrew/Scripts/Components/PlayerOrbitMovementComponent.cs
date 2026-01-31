using Godot;
using System;

public partial class PlayerOrbitMovementComponent : Node
{
    [Export] public BaseEnemy Enemy { get; private set; }
    [Export] public Node2D OrbitSlotNode { get; private set; }
    [Export] public Timer MoveInTimer { get; private set; }

    private bool Orbiting = false;

    public override void _Ready()
    {
        OrbitPoint orbitNode = EnemyManager.enemyManager.FindValidPlayerOrbitPoint();
        SetOrbitSlotNode(orbitNode);
    }

    public override void _Process(double delta)
    {
        if (Orbiting)
        {
            SetPositionToOrbitSlotNode();
        }
        else
        {
            Enemy.GlobalPosition = OrbitSlotNode.GlobalPosition.Lerp(Enemy.GlobalPosition, (float)MoveInTimer.TimeLeft);
        }
    }

    public void OnMoveInTimerTimeout()
    {
        Orbiting = true;
    }

    public void SetOrbitSlotNode(OrbitPoint orbitPoint)
    {
        OrbitSlotNode = orbitPoint;
        orbitPoint.SetEnemyAtPoint(Enemy);
        //GD.Print(OrbitSlotNode.Name);
    }

    public void SetPositionToOrbitSlotNode()
    {
        Enemy.Position = OrbitSlotNode.GlobalPosition;
    }
}

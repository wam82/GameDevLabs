using System.Collections.Generic;
using BehaviorTree;

public class GuardBT : Tree
{
    public UnityEngine.Transform[] waypoints;

    public static float speed = 2f;
    public static float fovRange = 6f;
    public static float attackRange = 1f;

    protected override Node SetupTree()
    {
        Node root = new Selector(new List<Node>
        {
            //TODO :Add attack behavior
            new Sequence(new List<Node>
            {
               //TODO: Add check enemy and go to behavior
               new CheckEnemyInAttackRange(transform),
               new TaskAttack(transform)
            }),
            new Sequence(new List<Node>
            {
                //TODO: Add check enemy and go to behavior
                new CheckEnemyInFOVRange(transform),
                new TaskGoToTarget(transform)
            }),
        new TaskPatrol(transform, waypoints)
        });

        return root;
    }
}

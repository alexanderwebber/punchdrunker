using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaf : Node
{
    private readonly Func<EnemyBehaviorTree, Result> action;

    public Leaf(Func<EnemyBehaviorTree, Result> action)
    {
        this.action = action;
    }

    public Result Execute(EnemyBehaviorTree tree)
    {
        return action(tree);
    }

    public bool IsConditional()
    {
        return false;
    }

    public List<Node> Children()
    {
        return null;
    }
}


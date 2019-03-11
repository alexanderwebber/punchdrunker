using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Selector : Node
{
    private Func<EnemyBehaviorTree, Result> conditionFunction;
    private Node leafIfTrue;
    private Node leafIfFalse;

    public Selector(Func<EnemyBehaviorTree, Result> conditionFunction, Node leafIfTrue, Node leafIfFalse)
    {
        this.conditionFunction = conditionFunction;
        this.leafIfTrue = leafIfTrue;
        this.leafIfFalse = leafIfFalse;
    }

    public Result Execute(EnemyBehaviorTree tree)
    {
        var state = tree.NodeAndState[this];

        if (state == EnemyBehaviorTree.NodeState.RUNNING)
            return new Result(true);

        Result outcome = conditionFunction(tree);

        if (state == EnemyBehaviorTree.NodeState.RUNNING)
            return new Result(true);

        if (outcome.BooleanResult)
        {
            tree.NodeAndState[leafIfTrue] = EnemyBehaviorTree.NodeState.IN_QUEUE;
            tree.NodeAndState[leafIfFalse] = EnemyBehaviorTree.NodeState.IGNORE;
        }
        else
        {
            tree.NodeAndState[leafIfTrue] = EnemyBehaviorTree.NodeState.IGNORE;
            tree.NodeAndState[leafIfFalse] = EnemyBehaviorTree.NodeState.IN_QUEUE;
        }

        return outcome;
    }

    public bool IsConditional()
    {
        return true;
    }

    public List<Node> Children()
    {
        return new List<Node> { leafIfTrue, leafIfFalse };
    }
}


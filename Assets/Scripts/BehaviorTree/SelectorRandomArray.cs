using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class SelectorRandomArray : Node
{
    private Dictionary<Node, float> leafArrayAndChance;

    public SelectorRandomArray(Dictionary<Node, float> leafArrayAndChance)
    {
        this.leafArrayAndChance = leafArrayAndChance;
    }

    public Result Execute(EnemyBehaviorTree tree)
    {
        var state = tree.NodeAndState[this];

        if (state == EnemyBehaviorTree.NodeState.RUNNING)
            return new Result(true);

        if (state == EnemyBehaviorTree.NodeState.COMPUTING)
        {
            Node chosen = ChooseByRandom(leafArrayAndChance);

            tree.NodeAndState[this] = EnemyBehaviorTree.NodeState.WAITING;
            tree.NodeAndState[chosen] = EnemyBehaviorTree.NodeState.IN_QUEUE;

            foreach (var item in leafArrayAndChance)
            {
                if (item.Key != chosen)
                    tree.NodeAndState[item.Key] = EnemyBehaviorTree.NodeState.IGNORE;
            }
        }

        return new Result(true);
    }

    public bool IsConditional()
    {
        return true;
    }

    public List<Node> Children()
    {
        return leafArrayAndChance.Keys.ToList();
    }

    private static System.Random rand = new System.Random();

    public static Node ChooseByRandom(Dictionary<Node, float> set)
    {
        var r = rand.NextDouble();
        foreach (var item in set)
        {
            if (r < item.Value)
                return item.Key;
            r -= item.Value;
        }
        throw new InvalidOperationException("Probabilities must add up to 1.");
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{
    public class Selector : Node
    {
        private Func<BehaviorTree, Result> conditionFunction;
        private Node leafIfTrue;
        private Node leafIfFalse;

        public Selector(Func<BehaviorTree, Result> conditionFunction, Node leafIfTrue, Node leafIfFalse)
        {
            this.conditionFunction = conditionFunction;
            this.leafIfTrue = leafIfTrue;
            this.leafIfFalse = leafIfFalse;
        }

        public Result Execute(BehaviorTree tree)
        {
            var state = tree.NodeAndState[this];

            if (state == BehaviorTree.NodeState.RUNNING)
                return new Result(true);

            Result outcome = conditionFunction(tree);

            if (state == BehaviorTree.NodeState.RUNNING)
                return new Result(true);

            if (outcome.BooleanResult)
            {
                tree.NodeAndState[leafIfTrue] = BehaviorTree.NodeState.IN_QUEUE;
                tree.NodeAndState[leafIfFalse] = BehaviorTree.NodeState.IGNORE;
            }
            else
            {
                tree.NodeAndState[leafIfTrue] = BehaviorTree.NodeState.IGNORE;
                tree.NodeAndState[leafIfFalse] = BehaviorTree.NodeState.IN_QUEUE;
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
}

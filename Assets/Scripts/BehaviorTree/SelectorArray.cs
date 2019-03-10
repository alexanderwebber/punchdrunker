﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BehaviorTree
{
    public class SelectorArray : Node
    {
        private Func<BehaviorTree, Result> conditionFunction;
        private Node[] leafArray;

        public SelectorArray(Func<BehaviorTree, Result> conditionFunction, Node[] leafArray)
        {
            this.conditionFunction = conditionFunction;
            this.leafArray = leafArray;
        }

        public Result Execute(BehaviorTree tree)
        {
            var state = tree.NodeAndState[this];

            if (state == BehaviorTree.NodeState.RUNNING)
                return new Result(true);

            int resultInt = conditionFunction(tree).IntegerResult;

            if (state == BehaviorTree.NodeState.RUNNING)
                return new Result(true);

            for (var i = 0; i < leafArray.Count(); i++)
            {
                if (i == resultInt)
                    tree.NodeAndState[leafArray[i]] = BehaviorTree.NodeState.IN_QUEUE;
                else
                    tree.NodeAndState[leafArray[i]] = BehaviorTree.NodeState.IGNORE;
            }

            return new Result(resultInt);
        }

        public bool IsConditional()
        {
            return true;
        }

        public List<Node> Children()
        {
            return leafArray.ToList();
        }
    }
}


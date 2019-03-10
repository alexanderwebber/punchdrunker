using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BehaviorTree
{
    public class Sequencer : Node
    {
        private Node[] leafArray;

        public Sequencer(Node[] leafArray)
        {
            this.leafArray = leafArray;
        }

        public Result Execute(BehaviorTree tree)
        {
            tree.NodeAndState[this] = BehaviorTree.NodeState.WAITING;
            tree.NodeAndState[leafArray[0]] = BehaviorTree.NodeState.IN_QUEUE;
            return new Result(true);
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
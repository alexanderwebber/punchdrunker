﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{
    public class Leaf : Node
    {
        private readonly Func<BehaviorTree, Result> action;
        
        public Leaf(Func<BehaviorTree, Result> action)
        {
            this.action = action;
        }

        public Result Execute(BehaviorTree tree)
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
}

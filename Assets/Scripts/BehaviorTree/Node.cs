using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface Node
{
    Result Execute(EnemyBehaviorTree tree);
    bool IsConditional();
    List<Node> Children();
}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//https://hub.packtpub.com/building-your-own-basic-behavior-tree-tutorial/

public enum NodeStates
{
    FAILURE,
    SUCCESS,
    RUNNING
}

[System.Serializable]
public abstract class Node
{
    public string name;

    public delegate NodeStates returnNode();

    protected NodeStates currentNodeState;

    public NodeStates NodeState
    {
        get { return currentNodeState; }
    }

    public Node() { }

    public Node(string nodeName)
    {
        name = nodeName;
    }

    public abstract NodeStates Evaluate();
}

public class Selector : Node
{
    protected List<Node> node_list = new List<Node>();

    public Selector(string name, List<Node> nodes)
    {
        node_list = nodes;
    }

    public override NodeStates Evaluate()
    {
        foreach (Node node in node_list)
        {
            switch (node.Evaluate())
            {
                case NodeStates.FAILURE:
                    continue;
                case NodeStates.SUCCESS:
                    currentNodeState = NodeStates.SUCCESS;
                    return currentNodeState;
                case NodeStates.RUNNING:
                    currentNodeState = NodeStates.RUNNING;
                    return currentNodeState;
                default:
                    continue;
            }
        }
        currentNodeState = NodeStates.FAILURE;
        return currentNodeState;
    }
}

// Decorator type repeater node for behavior tree written for enemy moves
// with turn counts...not sure if needed, recheck later
public class Repeater : Node
{
    protected Node child;

    public Repeater(Node node)
    {
        child = node;
    }

    public override NodeStates Evaluate()
    { 
        NodeStates ret = child.NodeState;
        if (ret != NodeStates.RUNNING)
        {
            child = null;
        }
        return NodeStates.SUCCESS;
    }
}

/* Leaves of tree (enemy actions)
 * WIP Need to figure out how to implement/transfer EnemyObject actions into Leaf Nodes
so that they can be swapped depending on enemy type and don't need to create 12 different
leaves.

public class EnemySkipTurn : Node
{
    
}

public class EnemyMove1 : Node
{
    public override Evaluate()
    {
        EnemyObject en = current
        return NodeStates.SUCCESS
    }
}

public class EnemyMove2 : Node
{
    public override Evaluate()
    {
        EnemyObject en = current
        return NodeStates.SUCCESS
    }
}

public class EnemyMove3 : Node
{
    public override Evaluate()
    {
        EnemyObject en = current
        return NodeStates.SUCCESS
    }
}

public class EnemyMove4 : Node
{
    public override Evaluate()
    {
        EnemyObject en = current
        return NodeStates.SUCCESS
    }
}
*/

public class Behavior : MonoBehaviour
{
    Node behaviorTree;

    // Start is called before the first frame update
    void Start()
    {
        //behaviorTree = createBehaviorTree();    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /* WIP need context to connect branches
    Node createBehaviorTrees()
    {
        List<Node> Moveset1 = <new EnemyMove1(), new EnemyMove2()>
        List<Node> Moveset2 = <new EnemyMove1(), new EnemyMove2(), new EnemyMove3()>
        List<Node> Moveset3 = <new EnemyMove1(), new EnemyMove2(), new EnemyMove3(), new EnemyMove4()>

        Selector endMoveset = new Selector("endMoveset", Moveset3);
        Selector middleMoveset = new Selector("middleMoveset", Moveset2);
        Selector startMoveset = new Selector("startMoveset", Moveset1)    
        
    }
    */
 }

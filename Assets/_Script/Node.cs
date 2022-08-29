using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public enum NodeStates { Working, Done, Failed }

    public BTree Tree { get; set; }

    public Node(BTree t)
    {
        Tree = t;
    }
    public virtual NodeStates Run()     //using type NodeStates
    {
        return NodeStates.Failed;   //we need to inherit from node, so we want to make sure we overriden execute 
    }
}
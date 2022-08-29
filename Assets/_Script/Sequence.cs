using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence : Composite
{
    int currentNode = 0;
    public Sequence(BTree tree, Node[] children) : base(tree, children)
    {
    }

    public override NodeStates Run()
    {
        if (currentNode < children.Count)
        {
            NodeStates result = children[currentNode].Run();

            if (result == NodeStates.Working)
                return NodeStates.Working;
            else if (result == NodeStates.Failed)
            {
                currentNode = 0;
                return NodeStates.Failed;
            } 
            else   
            {
                currentNode++;
                if (currentNode < children.Count)   //Cant tell if my work is done until i reach this branch since i reached my count
                    return NodeStates.Working;
                else
                {
                    currentNode = 0;
                    return NodeStates.Done;
                }
            }
        }
        return NodeStates.Done;
    }
}




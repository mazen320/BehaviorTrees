using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecoratorRepeater : Decorator
{
    public DecoratorRepeater(BTree tree, Node child) : base(tree, child)// this calls the right constructor of the decorator class
    {

    }

    public override NodeStates Run()
    {
        Debug.Log("Decorator child return:" + Child.Run());
        return NodeStates.Working;
    }
}

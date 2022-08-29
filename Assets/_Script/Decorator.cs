using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decorator : Node
{
    protected Node Child { get; set; }  //repeater will be using this, this could be public too

    public Decorator(BTree tree, Node child) : base (tree)
    {
        Child = child;
    }
}

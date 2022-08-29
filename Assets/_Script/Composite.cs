using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Composite : Node
{
    public List<Node> children { get; set; }

    public Composite(BTree tree, Node[] nodes) : base(tree)
    {
        children = new List<Node>(nodes);
    }

}

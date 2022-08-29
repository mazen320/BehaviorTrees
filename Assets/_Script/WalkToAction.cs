using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkToAction : Node
{
    public Vector3 destination;
    protected float movesSpeed = 5f;

    public WalkToAction(BTree t) : base(t)
    {
        destination = new Vector3(0, 5, 0);
    }

    public bool GoToNextCheck()
    {
        bool reached = false;
        object o;
        reached = Tree.memory.TryGetValue("World", out o);

        if(reached)
        {
            Rect bounds = (Rect)o;
            destination.y += 0.01f;
        }
        return reached;
    }

    public override NodeStates Run()
    {
        //if arrived, return success
        if (Tree.gameObject.transform.position == destination)
        {
            if(!GoToNextCheck())
            return NodeStates.Failed;
        else
            return NodeStates.Done;
        }
        else  //incase we didnt go there, so we go there
        {
            Tree.gameObject.transform.position = Vector3.MoveTowards(Tree.gameObject.transform.position, destination, Time.deltaTime * movesSpeed);
            return NodeStates.Working;
        }

    }
}

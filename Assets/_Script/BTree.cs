using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTree : MonoBehaviour
{
    protected Node node;

    bool ActionBegan;
    private Coroutine Action;

    public Dictionary<string, object> memory { get; set; }  //holding memory

    public Node Node { get { return node; } }   //since it's get only, it reads only

    // Start is called before the first frame update
    void Start()
    {
        memory = new Dictionary<string, object>();
        memory.Add("World", new Rect(0, 0, 10, 10));

        ActionBegan = false;

        node = new DecoratorRepeater(this, new Sequence(this, new Node[] { new WalkToAction(this) }));  //so we can access this from the other nodes
        //node = new Sequence(this, new Node[] { new WalkToAction(this), new WalkToActionTwo(this) });
    }

    // Update is called once per frame
    void Update()
    {
        if(!ActionBegan)
        {
            Action = StartCoroutine(RunAction());
            ActionBegan = true;
        }
    }

    IEnumerator RunAction()
    {
        Node.NodeStates result = Node.Run();
        while(result == Node.NodeStates.Working)
        {
            Debug.Log("Result =" + result);
            yield return null;
            result = Node.Run();
        }
        Debug.Log("Action finished:" + result);
    }
}

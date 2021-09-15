using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New AI Type", menuName ="AI Type")]
public class AIType : ScriptableObject
{
    public Node rootNode;
    public Node.State treeState = Node.State.Running;
    
    public Node.State Update()
    {
        if(rootNode.state == Node.State.Running)
        {
            treeState = rootNode.Update();
        }
        return treeState;
    }
}

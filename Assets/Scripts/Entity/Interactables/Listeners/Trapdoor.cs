using Assets.Scripts.Grid;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trapdoor : Listener
{
    [SerializeField] private bool on;
    public void Execute(Attack interactingAttack, Vector3 origin)
    {
        //TODO: write check for stuff like powerglove/destruction
        //throw new System.NotImplementedException();
    }

    public void ChangeState(bool state)
    {
        on = state;
        Debug.Log("Trapdoor at " + transform.position + " updating");
        grid.UpdatePassability(transform.position);
    }

    public override void Execute()
    {
        throw new System.NotImplementedException();
    }
}

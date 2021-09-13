using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toggleable : Interactable
{
    [SerializeField] private bool on;
    [SerializeField] private bool locked;

    [SerializeField] private Transform fill;
    public override void Execute()
    {
        if(!locked)
            on = !on;

        fill.GetComponent<BoxCollider>().enabled = on;
        fill.GetComponent<MeshRenderer>().enabled = on;
    }

    public override void Execute(Attack interactingAttack, Vector3 origin)
    {
        //TODO: write check for stuff like powerglove/destruction
        //throw new System.NotImplementedException();
    }

    public void ChangeState(bool state)
    {
        this.on = state;
        fill.GetComponent<BoxCollider>().enabled = state;
        fill.GetComponent<MeshRenderer>().enabled = state;
    }
}

using Assets.Scripts.Grid;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Listener
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
        grid.UpdatePassability(transform.position + transform.rotation * Vector3.forward * 0.5f);
        grid.UpdatePassability(transform.position + transform.rotation * Vector3.back * 0.5f);
    }

    public override void Execute()
    {
        throw new System.NotImplementedException();
    }
}

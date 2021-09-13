using Assets.Scripts.Grid;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Toggleable
{
    public override void Execute(Attack interactingAttack, Vector3 origin)
    {
        //TODO: write check for stuff like powerglove/destruction
        //throw new System.NotImplementedException();
    }

    public override void ChangeState(bool state)
    {
        base.ChangeState(state);
        grid.UpdatePassability(transform.position + transform.rotation * Vector3.forward * 0.5f);
        grid.UpdatePassability(transform.position + transform.rotation * Vector3.back * 0.5f);
    }
}

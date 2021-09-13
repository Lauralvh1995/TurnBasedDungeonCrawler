﻿using Assets.Scripts.Grid;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trapdoor : Toggleable
{    public override void Execute(Attack interactingAttack, Vector3 origin)
    {
        //TODO: write check for stuff like powerglove/destruction
        //throw new System.NotImplementedException();
    }

    public override void ChangeState(bool state)
    {
        base.ChangeState(state);
        Debug.Log("Trapdoor at " + transform.position + " updating");
        grid.UpdatePassability(transform.position);
    }
}

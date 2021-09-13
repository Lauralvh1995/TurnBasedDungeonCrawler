using Assets.Scripts.Grid;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trapdoor : Toggleable
{
    private void OnEnable()
    {
        grid = FindObjectOfType<GridController>();
    }

    public override void Execute()
    {
        if (!locked)
            ChangeState(!on);
    }


    public override void Execute(Attack interactingAttack, Vector3 origin)
    {
        //TODO: write check for stuff like powerglove/destruction
        //throw new System.NotImplementedException();
    }

    public override void ChangeState(bool state)
    {
        base.ChangeState(state);
        grid.UpdatePassability(transform.position);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ledge : Listener
{
    [SerializeField] Entity entity;
    public override void Execute()
    {
        //make entity fly
        entity.SetFlying(true);
        //move over edge
        entity.GetComponent<EntityActions>().MoveForward();
        //turn off flying
        entity.SetFlying(false);
    }
}

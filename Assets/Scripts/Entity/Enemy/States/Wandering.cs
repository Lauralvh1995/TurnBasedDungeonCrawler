using Assets.Scripts.Entity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Wandering : State
{

    [SerializeField] private State OnNoticePlayer;

    public override void ExecuteState()
    {
        //make random move
    }
}

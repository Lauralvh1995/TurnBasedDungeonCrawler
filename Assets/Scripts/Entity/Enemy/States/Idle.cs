using Assets.Scripts.Entity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Idle : State
{
    [SerializeField] private State OnNoticePlayer;


    public override void ExecuteState()
    {
        //do nothing special, just wait
        brain.Wait();
        CheckTransitions();
    }
}

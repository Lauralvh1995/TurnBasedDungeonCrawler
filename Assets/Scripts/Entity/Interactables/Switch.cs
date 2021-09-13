using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : Interactable
{
    [SerializeField] private bool on;
    [SerializeField] private bool locked;

    [SerializeField] private List<Toggleable> listeners;

    public override void Execute()
    {
        if (!locked)
        {
            on = !on;
            foreach(Toggleable t in listeners)
            {
                t.ChangeState(on);
            }
        }
    }

    public override void Execute(Attack interactingAttack, Vector3 origin)
    {
        //Think about remotely triggerable lever logic and stuff.
        //throw new System.NotImplementedException();
    }
}

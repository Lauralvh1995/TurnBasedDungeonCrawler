using Assets.Scripts.Grid;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Toggleable : Interactable
{
    [SerializeField] protected bool on;
    [SerializeField] protected bool locked;

    [SerializeField] protected Transform fill;
    [SerializeField] protected GridController grid;

    private void OnEnable()
    {
        grid = FindObjectOfType<GridController>();
    }

    public override void Execute()
    {
        if (!locked)
            ChangeState(!on);
    }

    public void Execute(bool eventTriggeredMe)
    {
        if(eventTriggeredMe)
        {
            ChangeState(!on);
            locked = true;
        }
    }

    public override void Execute(Attack interactingAttack, Vector3 origin)
    {
        //TODO: write check for stuff like powerglove/destruction
        //throw new System.NotImplementedException();
    }

    public void Lock(bool state)
    {
        locked = state;
    }

    public virtual void ChangeState(bool state)
    {
        this.on = state;
        fill.GetComponent<BoxCollider>().enabled = state;
        fill.GetComponent<MeshRenderer>().enabled = state;
    }
}

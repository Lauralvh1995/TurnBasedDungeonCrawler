using Assets.Scripts.Grid;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toggleable : Interactable
{
    [SerializeField] private bool on;
    [SerializeField] private bool locked;

    [SerializeField] private Transform fill;
    [SerializeField] private GridController grid;

    private void Awake()
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

    public void ChangeState(bool state)
    {
        this.on = state;
        fill.GetComponent<BoxCollider>().enabled = state;
        fill.GetComponent<MeshRenderer>().enabled = state;
        grid.UpdatePassability(transform.position + transform.rotation * Vector3.forward * 0.5f);
        grid.UpdatePassability(transform.position + transform.rotation * Vector3.back * 0.5f);
    }
}

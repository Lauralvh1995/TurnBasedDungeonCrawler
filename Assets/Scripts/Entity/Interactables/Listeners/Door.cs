using Assets.Scripts.Grid;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Listener
{
    [SerializeField] private bool on;
    [SerializeField] private Transform fill;
    public void ChangeState(bool state)
    {
        on = state;
        fill.gameObject.SetActive(on);
        GridController.Instance.UpdatePassability(transform.position + transform.rotation * Vector3.forward * 0.5f);
        GridController.Instance.UpdatePassability(transform.position + transform.rotation * Vector3.back * 0.5f);
    }

    public override void Execute()
    {
        bool check = false;
        if (conditions.Count > 0)
        {
            foreach (Condition c in conditions)
            {
                check = c.Check();
            }
        }
        else
        {
            check = true;
        }
        if (check)
        {
            ChangeState(!on);
        }
    }
}

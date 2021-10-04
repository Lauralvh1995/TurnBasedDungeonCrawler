using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : Condition
{
    [SerializeField] private bool locked;
    public override bool Check()
    {
        return locked;
    }

    public void Unlock()
    {
        locked = false;
    }
}

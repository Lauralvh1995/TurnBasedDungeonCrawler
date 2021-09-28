using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TempTileObject : MonoBehaviour
{
    [SerializeField] protected Condition disappearCondition;
    [SerializeField] protected Listener[] listeners;

    [SerializeField] protected bool triggered;
    // Update is called once per frame
    private void OnEnable()
    {
        //add yourself as listener to listeners
    }
    void OnTurnTick()
    {
        if (disappearCondition.Check())
        {
            triggered = true;
        }
        if (triggered)
        {
            Die(true);
        }
    }

    protected virtual void Die( bool set)
    {
        //remove yourself as listener from listeners
        Destroy(this);
    }
}

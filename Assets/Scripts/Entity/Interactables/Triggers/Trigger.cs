using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Trigger : MonoBehaviour, ICanInteract
{
    [SerializeField] protected List<Attack> requiredAttacks;
    [SerializeField] protected List<Listener> listeners;
    public virtual void Execute()
    {
        Debug.Log("Triggered at " + transform.position);
        foreach (Listener l in listeners)
        {
            l.Execute();
        }
    }
    public abstract void Execute(Attack attack, Vector3 origin);
}

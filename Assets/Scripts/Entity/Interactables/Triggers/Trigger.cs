using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Trigger : MonoBehaviour, ICanInteract
{
    [SerializeField] protected List<Listener> listeners;
    public virtual void Execute()
    {
        foreach (Listener l in listeners)
        {
            l.Execute();
        }
    }
    public abstract void Execute(Attack attack, Vector3 origin);
}

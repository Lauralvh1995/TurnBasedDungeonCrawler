using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public abstract class Trigger : MonoBehaviour, ICanInteract
{
    [SerializeField] protected List<Attack> requiredAttacks;
    [SerializeField] protected List<Listener> listeners;
    [SerializeField] protected GameObject graphicAnchor;
    [SerializeField] protected string interactionName;
    public virtual void Execute()
    {
        Debug.Log("Triggered at " + transform.position);
        foreach (Listener l in listeners)
        {
            l.Execute();
        }
    }
    public Vector3 GetGraphicAnchor()
    {
        return graphicAnchor.transform.position;
    }
    public string GetInteractionName()
    {
        return interactionName;
    }
    public abstract void Execute(Attack attack, Vector3 origin);
}

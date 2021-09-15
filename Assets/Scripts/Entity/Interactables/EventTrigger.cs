using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class EventTrigger : MonoBehaviour
{
    [SerializeField] private bool triggered;

    [SerializeField] private List<Interactable> listeners;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject);
        if (other.gameObject.GetComponent<Player>() && !triggered)
        {
            triggered = true;
            foreach (Interactable listener in listeners)
            {
                if(listener is Toggleable)
                {
                    Toggleable t = listener as Toggleable;
                    t.Execute(true);
                }
            }
        }
    }
}

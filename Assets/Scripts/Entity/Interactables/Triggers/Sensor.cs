using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Sensor : MonoBehaviour
{
    [SerializeField] private bool triggered;

    [SerializeField] private List<Listener> listeners;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject);
        if (other.gameObject.GetComponent<Player>() && !triggered)
        {
            triggered = true;
            foreach (Listener listener in listeners)
            {
                if(listener.GetComponent<Door>() != null)
                {
                    listener.Execute();
                }
            }
        }
    }
}

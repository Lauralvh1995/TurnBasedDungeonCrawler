using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Listener : MonoBehaviour
{
    [SerializeField] private List<Interactable> interactables;
    public void Execute()
    {
        foreach(Interactable i in interactables)
        {
            i.Execute();
        }
    }
}

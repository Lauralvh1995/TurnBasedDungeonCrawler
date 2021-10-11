using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TextPopUp : Listener
{
    [SerializeField] private ShowTextEvent showTextEvent;
    [SerializeField] private string textToShow;
    public override void Execute()
    {
        showTextEvent.Invoke(textToShow);
    }
}

[Serializable]
public class ShowTextEvent : UnityEvent<string>
{

}

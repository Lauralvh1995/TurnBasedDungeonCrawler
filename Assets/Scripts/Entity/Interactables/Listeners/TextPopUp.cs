using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
namespace Assets.Scripts.Entity
{
    public class TextPopUp : Listener
    {
        [SerializeField] private ShowTextEvent showTextEvent;
        [SerializeField] private string textToShow;
        [SerializeField] private float timeToStay;
        public override void Execute()
        {
            showTextEvent.Invoke(textToShow, timeToStay);
        }
    }
}
[Serializable]
public class ShowTextEvent : UnityEvent<string, float>
{

}

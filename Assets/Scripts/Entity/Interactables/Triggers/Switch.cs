using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Assets.Scripts.Entity
{
    public class Switch : Trigger
    {
        [SerializeField] private bool on;
        public override void Execute()
        {
            on = !on;
            base.Execute();
        }

        public override void Execute(Attack attack, Vector3 origin)
        {
            //Think about remotely triggerable lever logic and stuff.
            //throw new System.NotImplementedException();
        }
    }
}
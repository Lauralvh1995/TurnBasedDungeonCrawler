using Assets.Scripts.Entity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Entity
{
    public class SomethingStandsOnMe : Condition
    {
        [SerializeField]
        LayerMask entityMask;
        public override bool Check()
        {
            return Physics.OverlapSphere(transform.position, 0.2f, entityMask).Length > 0;
        }
    }
}

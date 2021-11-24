using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Entity
{
    public abstract class AttackProperty : ScriptableObject
    {
        public abstract void ExecuteAttackProperty(Vector3 location);
    }
}

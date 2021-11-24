using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Entity
{
    [CreateAssetMenu(fileName = "Knockback Property", menuName = "Attacks/Attack Properties/Knockback")]
    public class KnockbackProperty : AttackProperty
    {
        [SerializeField] int range;
        public override void ExecuteAttackProperty(Vector3 location)
        {
            //Check for amount of open tiles, with floor, are within range, in the direction you're facing
            //Move target as far as possible
        }
    }
}
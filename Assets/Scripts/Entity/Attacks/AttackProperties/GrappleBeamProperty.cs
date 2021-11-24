using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Entity
{
    [CreateAssetMenu(fileName = "Grapple Beam Property", menuName = "Attacks/Attack Properties/Grapple Beam")]
    public class GrappleBeamProperty : AttackProperty
    {
        public override void ExecuteAttackProperty(Vector3 location)
        {
            //check for grappleable thing
            //calculate path for it to travel
            //pull it!
        }
    }
}
using Assets.Scripts.Grid;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Entity
{
    [CreateAssetMenu(fileName = "New Melee Attack", menuName = "Melee Attack")]
    public class MeleeAttack : Attack
    {
        [SerializeField, Range(1, 5)] private int damage;
        [SerializeField, Range(1, 3)] private int size;
        [SerializeField] private TargetingMode mode;
        public override void Execute(Transform origin)
        {
            Debug.Log("Performed " + attackName);

            HashSet<Collider> hits = new HashSet<Collider>();
            Vector3 nextRayOrigin = origin.position;
            switch (mode)
            {
                case TargetingMode.Front:
                    for (int i = 0; i < size; i++)
                    {
                        RaycastHit raycastHit;
                        Physics.Raycast(new Ray(nextRayOrigin, origin.rotation * Vector3.forward), out raycastHit, 1f);
                        nextRayOrigin = origin.position + (origin.rotation * Vector3.forward * i);
                        //if target found, add to targets
                        if (raycastHit.collider != null)
                        {
                            hits.Add(raycastHit.collider);
                        }
                    }
                    break;
                case TargetingMode.Wide:
                    //TODO: draw perpendicular line in front of you of a given size
                    break;
                case TargetingMode.Area:
                    Collider[] colliders = Physics.OverlapSphere(nextRayOrigin, size);
                    foreach (Collider c in colliders)
                    {
                        if (Mathf.RoundToInt(Vector3.Distance(c.transform.position, nextRayOrigin)) > size)
                        {
                            if (c.transform.position.y == nextRayOrigin.y && c.transform.position != origin.position)
                                hits.Add(c);
                        }
                    }
                    break;
            }
            //check all tiles in range if there is a target there
            //if target found, add to targets
            //check size for targets
            //modes: front =  size in line in front of you
            //       wide =   size in line 1 in front, then perpendicular to you
            //       area =   size in circle (manhattan) around you
            //if target is entity, apply damage
            //if attack has knockback, check if entity is heavy
            //if entity is not heavy, knock entity back
            //if target is interactable, check if it triggers
            foreach (Collider c in hits)
            {
                property?.ExecuteAttackProperty(origin.position);
                c.GetComponent<Trigger>()?.Execute(this, origin.position);
                c.GetComponent<Entity>()?.TakeDamage(damage);
            }
        }
    }
    public enum TargetingMode
    {
        Front,
        Wide,
        Area
    }
}
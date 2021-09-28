using Assets.Scripts.Grid;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Ranged Attack", menuName = "Ranged Attack")]
public class RangeAttack : Attack
{
    [SerializeField, Range(2, 8)] private int range;
    [SerializeField, Range(1, 3)] private int radius;
    [SerializeField, Range(1, 5)] private int damage;
    [SerializeField] private bool piercing;
    [SerializeField] private BeamProperty property;
    public override void Execute(Transform origin)
    {
        Debug.Log("Performed " + attackName);
        //check all tiles in range if there is a target there
        HashSet<Collider> hits = new HashSet<Collider>();
        Vector3 nextRayOrigin = origin.position;
        for (int i = 0; i < range + 1; i++)
        {
            RaycastHit raycastHit;
            Physics.Raycast(new Ray(nextRayOrigin, origin.rotation * Vector3.forward), out raycastHit, 1f);
            nextRayOrigin = origin.position + (origin.rotation * Vector3.forward * i);
            property?.ExecuteBeamEffect(nextRayOrigin);
            //if target found, add to targets
            if (raycastHit.collider != null)
            {
                hits.Add(raycastHit.collider);
                //if piercing, keep going
                if (!piercing)
                {
                    break;
                }
            }
        }
        //check radius for targets (manhattan distance)
        if(radius > 1)
        {
            Collider[] colliders = Physics.OverlapSphere(nextRayOrigin, radius);
            foreach(Collider c in colliders)
            {
                if(Mathf.FloorToInt(Vector3.Distance(c.transform.position, nextRayOrigin)) > radius)
                {
                    if(c.transform.position.y == nextRayOrigin.y)
                        hits.Add(c);
                }
            }
        }
        //if target is entity, apply damage
        //if target is interactable, check if it triggers
        foreach (Collider c in hits)
        {
            c.GetComponent<Entity>()?.TakeDamage(damage);
            c.GetComponent<Trigger>()?.Execute(this, origin.position);
        }
    }
}

using Assets.Scripts.Entity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawPlayer : StateChangeCondition
{
    [SerializeField] int visionRange;

    private void Start()
    {
        visionRange = GetComponentInParent<Enemy>().GetEnemyStats().GetVisionRange();
    }

    public override bool ConditionMet()
    {
        Debug.DrawRay(transform.position, transform.forward, Color.red, 5);
        Ray ray = new Ray(transform.position, transform.forward);
        Physics.Raycast(ray, out RaycastHit hitInfo, visionRange);
        bool conditionMet = hitInfo.collider?.gameObject.tag == "Player";
        return conditionMet;
    }
}

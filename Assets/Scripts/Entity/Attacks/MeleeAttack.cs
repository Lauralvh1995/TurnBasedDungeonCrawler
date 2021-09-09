using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Melee Attack", menuName ="Melee Attack")]
public class MeleeAttack : Attack
{
    [SerializeField, Range(1, 5)] private int damage;
    [SerializeField, Range(1, 3)] private int size;
    [SerializeField] private bool knockback;
    [SerializeField] private TargetingMode mode;
    public override void Execute()
    {
        Debug.Log("Performed " + GetAttackName());

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
    }
}
public enum TargetingMode
{
    Front,
    Wide,
    Area
}

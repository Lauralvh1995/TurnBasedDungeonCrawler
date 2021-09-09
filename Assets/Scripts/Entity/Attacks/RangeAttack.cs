using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Ranged Attack", menuName = "Ranged Attack")]
public class RangeAttack : Attack
{
    [SerializeField, Range(2, 5)] private int range;
    [SerializeField, Range(1, 3)] private int radius;
    [SerializeField, Range(1, 5)] private int damage;
    [SerializeField] private bool piercing;
    public override void Execute()
    {
        Debug.Log("Performed " + GetAttackName());

        //check all tiles in range if there is a target there
        //if target found, add to targets
        //if piercing, keep going
        //check radius for targets (manhattan distance)
        //if target is entity, apply damage
        //if target is interactable, check if it triggers
    }
}

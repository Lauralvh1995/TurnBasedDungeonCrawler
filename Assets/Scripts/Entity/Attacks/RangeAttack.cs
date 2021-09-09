using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Ranged Attack", menuName = "Ranged Attack")]
public class RangeAttack : Attack
{
    [SerializeField, Range(2, 5)] private int range;
    [SerializeField, Range(1, 3)] private int radius;
    [SerializeField, Range(1, 5)] private int damage;
    public override void Execute()
    {
        throw new System.NotImplementedException();
    }
}

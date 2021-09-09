using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Melee Attack", menuName ="Melee Attack")]
public class MeleeAttack : Attack
{

    [SerializeField, Range(1, 5)] private int damage;
    [SerializeField, Range(1, 3)] private int size;
    [SerializeField] private TargetingMode mode;
    public override void Execute()
    {
        throw new System.NotImplementedException();
    }
}
public enum TargetingMode
{
    Front,
    Wide,
    Area
}

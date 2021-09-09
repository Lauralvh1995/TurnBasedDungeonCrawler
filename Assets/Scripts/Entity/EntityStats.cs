using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Entity", menuName = "Entity")]
public class EntityStats : ScriptableObject
{
    [SerializeField] private int maxHP;
    [SerializeField] private bool flying;

    [SerializeField] Attack primaryAttack;
    [SerializeField] Attack secondaryAttack;
    [SerializeField] AIType aiType;

    public int GetMaxHP()
    {
        return maxHP != 0 ? maxHP : 10;
    }
    public bool GetFlying()
    {
        return flying;
    }
    public Attack GetPrimaryAttack()
    {
        return primaryAttack;
    }
    public Attack GetSecondaryAttack()
    {
        return secondaryAttack;
    }
}

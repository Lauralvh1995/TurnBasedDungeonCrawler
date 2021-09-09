using Assets.Scripts.Grid;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    [SerializeField] EntityStats enemyType;

    private void Awake()
    {
        health = enemyType.GetMaxHP();
    }

    public override void ExecuteInteraction()
    {
        // enemies do not interact
    }

    public override void ExecutePrimaryAttack()
    {
        enemyType.GetPrimaryAttack().Execute(transform);
    }

    public override void ExecuteSecondaryAttack()
    {
        enemyType.GetSecondaryAttack().Execute(transform);
    }

    public override bool IsFlying()
    {
        return enemyType.GetFlying();
    }
    public override bool IsHeavy()
    {
        return enemyType.GetHeavy();
    }

    public override void SetFlying(bool value)
    {
        throw new System.NotImplementedException();
    }
}

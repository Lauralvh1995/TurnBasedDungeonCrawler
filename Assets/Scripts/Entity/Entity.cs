using Assets.Scripts.Grid;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    [SerializeField] protected int health;

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log(GetName() + " took " + damage + ". Health remaining: " + health);
        if(health <= 0)
        {
            Die();
        }
    }

    protected abstract string GetName();

    public void KnockBack(Transform culprit)
    {
        if (!IsHeavy())
        {
            bool originallyFlying = IsFlying();
            SetFlying(true);
            //TODO: check which direction you should fly, prioritizing the culprit's front and back


            SetFlying(originallyFlying);
        }
    }

    public abstract void ExecutePrimaryAttack();

    public abstract void ExecuteSecondaryAttack();

    public abstract void ExecuteInteraction();

    public abstract void SetFlying(bool value);

    public abstract bool IsFlying();
    public abstract bool IsHeavy();
    public abstract void Die();
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    [SerializeField] protected int health;

    public abstract void ExecutePrimaryAttack();

    public abstract void ExecuteSecondaryAttack();

    public abstract void ExecuteInteraction();

    public abstract bool IsFlying();
    public abstract bool IsHeavy();
}

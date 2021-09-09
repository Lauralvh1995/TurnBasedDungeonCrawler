using Assets.Scripts.Grid;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    [SerializeField] private int maxHealth;
    [SerializeField] private bool flying;
    [SerializeField] private bool heavy;

    [SerializeField] MeleeAttack primaryAttack;
    [SerializeField] RangeAttack secondaryAttack;

    [SerializeField] Interactable target;
    [SerializeField] List<Interactable> interactables;

    public override void ExecuteInteraction()
    {
        target.Execute();
    }

    public override void ExecutePrimaryAttack()
    {
        primaryAttack?.Execute(transform.position);
    }

    public override void ExecuteSecondaryAttack()
    {
        secondaryAttack?.Execute(transform.position);
    }

    public override bool IsFlying()
    {
        return flying;
    }
    public override bool IsHeavy()
    {
        return heavy;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    [SerializeField] private int maxHealth;

    [SerializeField] MeleeAttack primaryAttack;
    [SerializeField] RangeAttack secondaryAttack;

    [SerializeField] Interactable target;
    [SerializeField] List<Interactable> interactables;

    public override void ExecuteInteraction()
    {
        throw new System.NotImplementedException();
    }

    public override void ExecutePrimaryAttack()
    {
        throw new System.NotImplementedException();
    }

    public override void ExecuteSecondaryAttack()
    {
        throw new System.NotImplementedException();
    }

    public override bool IsFlying()
    {
        throw new System.NotImplementedException();
    }
}

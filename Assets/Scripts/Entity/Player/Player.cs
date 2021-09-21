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
    [SerializeField] private int currentTargetIndex = 0;
    [SerializeField] List<Interactable> interactables;
    [SerializeField] LayerMask interactableMask;

    [SerializeField] private bool inMapUI;

    public override void ExecuteInteraction()
    {
        target?.Execute();
    }
    public override void ExecutePrimaryAttack()
    {
        primaryAttack?.Execute(transform);
    }
    public override void ExecuteSecondaryAttack()
    {
        secondaryAttack?.Execute(transform);
    }
    public override bool IsFlying()
    {
        return flying;
    }
    public override bool IsHeavy()
    {
        return heavy;
    }
    public void SetInMap(bool status)
    {
        inMapUI = status;
    }
    public bool IsInMap()
    {
        return inMapUI;
    }
    public override void SetFlying(bool value)
    {
        flying = value;
    }
    public override void Die()
    {
        base.Die();
        //Debug.Log("You died :(");
    }

    protected override string GetName()
    {
        return "You";
    }

    public override void UpdateInteractables()
    {
        target = null;
        interactables.Clear();
        RaycastHit[] hits = Physics.BoxCastAll(transform.position, Vector3.one * 0.25f, transform.forward, Quaternion.identity, 1f, interactableMask);

        if (hits.Length > 0) {
            foreach (RaycastHit hit in hits)
            {
                interactables.Add(hit.collider.GetComponent<Interactable>());
            } }
        if (interactables.Count > 0)
        {
            ChangeTarget(0);
        }
    }

    public void ChangeTarget(int index)
    {
        target = interactables[index];
    }
}

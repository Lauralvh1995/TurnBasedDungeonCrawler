﻿using Assets.Scripts.Entity;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
namespace Assets.Scripts.Entity
{
    public class Player : Entity
    {
        [SerializeField] private int maxHealth;
        [SerializeField] private bool flying;
        [SerializeField] private bool heavy;

        [SerializeField] MeleeAttack primaryAttack;
        [SerializeField] RangeAttack secondaryAttack;
        [SerializeField] List<MeleeAttack> possibleMeleeAttacks;
        [SerializeField] List<RangeAttack> possibleRangeAttacks;

        [SerializeField] Trigger target;
        [SerializeField] private int currentTargetIndex = 0;
        [SerializeField] List<Trigger> interactables;
        [SerializeField] LayerMask interactableMask;

        [SerializeField] private bool inMapUI;

        [SerializeField] private SlottedMeleeAttackEvent slottedMelee;
        [SerializeField] private SlottedRangedAttackEvent slottedRange;
        [SerializeField] private ChangedInteractableEvent changedInteractable;
        [SerializeField] private ClearedInteractablesEvent clearedInteractables;
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
            Respawn();
        }

        protected override string GetName()
        {
            return "You";
        }

        public override void UpdateInteractables()
        {
            target = null;
            interactables.Clear();
            clearedInteractables.Invoke();
            RaycastHit[] hits = Physics.BoxCastAll(transform.position, Vector3.one * 0.25f, transform.forward, Quaternion.identity, 1f, interactableMask);

            if (hits.Length > 0)
            {
                foreach (RaycastHit hit in hits)
                {
                    interactables.Add(hit.collider.GetComponent<Trigger>());
                }
            }
            if (interactables.Count > 0)
            {
                ChangeTarget(0);

            }
        }

        public void AddMeleeAttack(MeleeAttack attack)
        {
            possibleMeleeAttacks.Add(attack);
            SlotMeleeAttack(attack);
        }

        public void AddRangeAttack(RangeAttack attack)
        {
            possibleRangeAttacks.Add(attack);
            SlotRangeAttack(attack);
        }

        public void SlotMeleeAttack(MeleeAttack attack)
        {
            primaryAttack = attack;
            slottedMelee.Invoke(attack);
        }

        public void SlotRangeAttack(RangeAttack attack)
        {
            secondaryAttack = attack;
            slottedRange.Invoke(attack);
        }

        public void ChangeTarget(int index)
        {
            target = interactables[index];
            if (target is ItemPickup)
            {
                ItemPickup t = target as ItemPickup;
                if (!t.alreadyTriggered)
                {
                    changedInteractable.Invoke(Camera.main.WorldToScreenPoint(target.GetGraphicAnchor()), target.GetInteractionName());
                }
            }
            else
            {
                changedInteractable.Invoke(Camera.main.WorldToScreenPoint(target.GetGraphicAnchor()), target.GetInteractionName());
            }
        }

        public void CycleTargetIndexUp()
        {
            currentTargetIndex++;
            if (currentTargetIndex >= interactables.Count)
            {
                currentTargetIndex = 0;
            }
            ChangeTarget(currentTargetIndex);
        }
        public void CycleTargetIndexDown()
        {
            currentTargetIndex--;
            if (currentTargetIndex < 0)
            {
                currentTargetIndex = interactables.Count - 1;
            }
            ChangeTarget(currentTargetIndex);
        }

        public override void Respawn()
        {
            base.Respawn();
            health = maxHealth;
        }
    }
}
[Serializable]
public class SlottedMeleeAttackEvent : UnityEvent<MeleeAttack>
{

}
[Serializable]
public class SlottedRangedAttackEvent : UnityEvent<RangeAttack>
{

}
[Serializable]
public class ChangedInteractableEvent : UnityEvent<Vector2, string>
{

}
[Serializable]
public class ClearedInteractablesEvent : UnityEvent
{

}
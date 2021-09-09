using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private int maxHealth;

    [SerializeField] bool flying;

    [SerializeField] PrimaryAttack primaryAttack;
    [SerializeField] SecondaryAttack secondaryAttack;

    [SerializeField] Interactable target;
    [SerializeField] List<Interactable> interactables;

    public void ExecutePrimaryAttack()
    {
        throw new NotImplementedException();
    }

    public void ExecuteSecondaryAttack()
    {
        throw new NotImplementedException();
    }

    public void ExecuteInteraction()
    {
        throw new NotImplementedException();
    }

    public bool IsFlying()
    {
        return flying;
    }
}

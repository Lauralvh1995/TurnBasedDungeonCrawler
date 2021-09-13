using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    [SerializeField] protected List<Attack> requiredAttacks;
    public abstract void Execute();
    public abstract void Execute(Attack interactingAttack, Vector3 origin);
}

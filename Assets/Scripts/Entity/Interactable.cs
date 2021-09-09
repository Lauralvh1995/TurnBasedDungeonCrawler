using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    [SerializeField] protected Attack requiredAttack;
    public abstract void Execute();
    public abstract void Execute(Attack interactingAttack, Vector3 origin);
}

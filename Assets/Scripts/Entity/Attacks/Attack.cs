using Assets.Scripts.Grid;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Attack : ScriptableObject
{
    [SerializeField] protected string attackName;
    [SerializeField] protected Sprite iconSprite;
    [SerializeField] protected AttackProperty property;
    public string GetAttackName() {
        return attackName;
    }

    public Sprite GetSprite()
    {
        return iconSprite;
    }
    
    public abstract void Execute(Transform origin);
}

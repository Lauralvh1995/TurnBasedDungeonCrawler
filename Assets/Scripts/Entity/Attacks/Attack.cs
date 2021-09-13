﻿using Assets.Scripts.Grid;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Attack : ScriptableObject
{
    [SerializeField] protected string attackName;
    public string GetAttackName() {
        return attackName;
    }
    
    public abstract void Execute(Transform origin);
}
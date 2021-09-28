﻿using Assets.Scripts.Grid;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Listener : MonoBehaviour
{
    [SerializeField] protected List<Condition> conditions;
    public abstract void Execute();
}

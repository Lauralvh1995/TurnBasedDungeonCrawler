using Assets.Scripts.Grid;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Listener : MonoBehaviour
{
    [SerializeField] protected List<Condition> conditions;
    [SerializeField] protected GridController grid;
    private void Awake()
    {
        grid = FindObjectOfType<GridController>();
    }
    public abstract void Execute();
}

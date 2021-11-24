using Assets.Scripts.Grid;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Assets.Scripts.Entity
{
    public abstract class Attack : ScriptableObject
    {
        [SerializeField] protected string attackName;
        [SerializeField] protected Sprite iconSprite;
        [SerializeField] protected AttackProperty property;
        [SerializeField, Range(1, 8)] protected int range;
        public string GetAttackName()
        {
            return attackName;
        }

        public int GetAttackRange()
        {
            return range;
        }

        public Sprite GetSprite()
        {
            return iconSprite;
        }

        public abstract void Execute(Transform origin);
    }
}
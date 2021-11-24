
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Entity
{
    [CreateAssetMenu(fileName = "New Entity", menuName = "Entity")]
    public class EnemyStats : ScriptableObject
    {
        [SerializeField] private string enemyName;
        [SerializeField] private int maxHP;
        [SerializeField] private bool flying;
        [SerializeField] private bool heavy;
        [SerializeField] private bool stationary = false;

        [SerializeField] private int chaseRange;

        [SerializeField] Attack primaryAttack;
        [SerializeField] Attack secondaryAttack;
        [SerializeField] AIType aiType;

        public string GetName()
        {
            return enemyName;
        }

        public int GetMaxHP()
        {
            return maxHP != 0 ? maxHP : 10;
        }
        public bool IsFlying()
        {
            return flying;
        }

        public void SetFlying(bool value)
        {
            flying = value;
        }
        public bool IsHeavy()
        {
            return heavy;
        }
        public bool IsStationary()
        {
            return stationary;
        }
        public Attack GetPrimaryAttack()
        {
            return primaryAttack;
        }
        public Attack GetSecondaryAttack()
        {
            return secondaryAttack;
        }
        public int GetChaseRange()
        {
            return chaseRange;
        }
        public AIAction GetActionFromAI(Vector3 ownPos, Vector3 targetPos)
        {
            if (Vector3.Distance(ownPos, targetPos) <= primaryAttack?.GetAttackRange())
            {
                return aiType.GetAIAction(ActionType.PrimaryAttack);
            }
            else if (Vector3.Distance(ownPos, targetPos) <= secondaryAttack?.GetAttackRange())
            {
                return aiType.GetAIAction(ActionType.SecondaryAttack);
            }
            else if (Vector3.Distance(ownPos, targetPos) <= chaseRange)
            {
                return aiType.GetAIAction(ActionType.Chase);
            }
            else
            {
                return aiType.GetAIAction(ActionType.Other);
            }
        }

    }
}
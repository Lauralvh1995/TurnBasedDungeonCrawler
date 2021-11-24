using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Entity
{
    [CreateAssetMenu(fileName = "New AI Type", menuName = "AI Type")]
    public class AIType : ScriptableObject
    {
        [SerializeField] AIAction primaryAttackAction;
        [SerializeField] AIAction secondaryAttackAction;
        [SerializeField] AIAction chaseAction;
        [SerializeField] AIAction otherAction;
        public AIAction GetAIAction(ActionType actionType)
        {
            switch (actionType)
            {
                case ActionType.PrimaryAttack:
                    return primaryAttackAction;
                case ActionType.SecondaryAttack:
                    return secondaryAttackAction;
                case ActionType.Chase:
                    return chaseAction;
                default:
                    return otherAction;
            }
        }
    }
    public enum ActionType
    {
        PrimaryAttack,
        SecondaryAttack,
        Chase,
        Other
    }
}

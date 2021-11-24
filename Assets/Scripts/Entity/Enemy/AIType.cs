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
        //ideas: list of possible actions
        //condition -> action
        // is player in range of primary attack -> do primary attack
        // is player in range of secondary attack -> do secondary attack
        // is player in range of chaseRange -> move towards it
        // none of the above met -> do other action action

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

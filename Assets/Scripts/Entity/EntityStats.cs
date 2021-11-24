
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Entity
{
    [CreateAssetMenu(fileName = "New Entity", menuName = "Entity")]
    public class EntityStats : ScriptableObject
    {
        [SerializeField] private string enemyName;
        [SerializeField] private int maxHP;
        [SerializeField] private bool flying;
        [SerializeField] private bool heavy;

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
        public bool GetFlying()
        {
            return flying;
        }

        public void SetFlying(bool value)
        {
            flying = value;
        }
        public bool GetHeavy()
        {
            return heavy;
        }
        public Attack GetPrimaryAttack()
        {
            return primaryAttack;
        }
        public Attack GetSecondaryAttack()
        {
            return secondaryAttack;
        }
    }
}
using Assets.Scripts.Grid;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Entity
{
    public class Enemy : Entity
    {
        [SerializeField] EntityStats enemyType;
        [SerializeField] bool hadTurn = false;

        private void Awake()
        {
            health = enemyType.GetMaxHP();
        }
        public void TakeAction()
        {
            //TODO: write action logic
        }

        public bool TookTurn()
        {
            return hadTurn;
        }

        public override void ExecuteInteraction()
        {
            // enemies do not interact
        }

        public override void ExecutePrimaryAttack()
        {
            enemyType.GetPrimaryAttack().Execute(transform);
        }

        public override void ExecuteSecondaryAttack()
        {
            enemyType.GetSecondaryAttack().Execute(transform);
        }

        public override bool IsFlying()
        {
            return enemyType.GetFlying();
        }
        public override bool IsHeavy()
        {
            return enemyType.GetHeavy();
        }

        public override void SetFlying(bool value)
        {
            enemyType.SetFlying(value);
        }
        public override void Die()
        {
            base.Die();
            Vector3 pos = transform.position;
            GetComponent<BoxCollider>().enabled = false;
            GridController.Instance.UpdatePassability(pos);
            //remove all listeners from the turn manager
            //TurnManager.Instance.onStartPlayerTurn.RemoveListener(/*everything belonging to me*/);
            gameObject.SetActive(false);
            //Debug.Log(enemyType.GetName() + " died");
        }

        protected override string GetName()
        {
            return enemyType.GetName();
        }

        public override void UpdateInteractables()
        {
            //Enemies don't use interactables for now
        }
    }
}
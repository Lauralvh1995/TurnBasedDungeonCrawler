using Assets.Scripts.Grid;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Entity
{
    [RequireComponent(typeof(EnemyBrain), typeof(EntityActions))]
    public class Enemy : Entity
    {
        [SerializeField] EnemyStats enemyStats;
        [SerializeField] bool hadTurn = false;
        [SerializeField] Player player;
        [SerializeField] EnemyBrain brain;

        private void Awake()
        {
            health = enemyStats.GetMaxHP();
            brain = GetComponent<EnemyBrain>();
            player = FindObjectOfType<Player>();
        }

        public EnemyStats GetEnemyStats()
        {
            return enemyStats;
        }

        public void StartNewTurn()
        {
            hadTurn = false;
        }
        public void TakeAction()
        {
            if (hadTurn)
            {
                return;
            }
            //Do something TODO: hook up to brain
            hadTurn = true;
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
            enemyStats.GetPrimaryAttack().Execute(transform);
        }

        public override void ExecuteSecondaryAttack()
        {
            enemyStats.GetSecondaryAttack().Execute(transform);
        }

        public override bool IsFlying()
        {
            return enemyStats.IsFlying();
        }
        public override bool IsHeavy()
        {
            return enemyStats.IsHeavy();
        }

        public override void SetFlying(bool value)
        {
            enemyStats.SetFlying(value);
        }
        public void FaceTarget()
        {
            //TODO: write logic to turn around until this is facing the player
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
            return enemyStats.GetName();
        }

        public override void UpdateInteractables()
        {
            //Enemies don't use interactables for now
        }
    }
}
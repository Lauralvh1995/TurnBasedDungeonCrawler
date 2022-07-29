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
        private void OnEnable()
        {
            player.playerDied.AddListener(Respawn);
            TurnManager.Instance.onStartEnvironmentTurn.AddListener(StartNewTurn);
        }
        private void OnDisable()
        {
            player.playerDied.RemoveListener(Respawn);
            TurnManager.Instance.onStartEnvironmentTurn.RemoveListener(StartNewTurn);
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
            brain.Execute();
            hadTurn = true;
        }

        public bool TookTurn()
        {
            return hadTurn;
        }

        public override void ExecuteInteraction()
        {
            // enemies do not interact yet
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
        public override void Die()
        {
            base.Die();
            Vector3 pos = transform.position;
            GetComponent<BoxCollider>().enabled = false;
            brain.enabled = false;
            gameObject.SetActive(false);
            GridController.Instance.UpdatePassability(pos);
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

        public override void Respawn()
        {
            base.Respawn();
            brain.enabled = true;
            health = enemyStats.GetMaxHP();
        }
    }
}
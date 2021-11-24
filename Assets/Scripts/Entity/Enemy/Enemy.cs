using Assets.Scripts.Grid;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Entity
{
    public class Enemy : Entity
    {
        [SerializeField] EnemyStats enemyType;
        [SerializeField] bool hadTurn = false;
        [SerializeField] Player player;

        private void Awake()
        {
            health = enemyType.GetMaxHP();
            player = FindObjectOfType<Player>();
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
            AIAction toExecute = enemyType.GetActionFromAI(transform.position, player.transform.position);
            //Debug.Log(toExecute.name);
            switch (toExecute.name)
            {
                case "PrimaryAttack":
                    FaceTarget();
                    actions.Attack();
                    break;
                case "SecondaryAttack":
                    FaceTarget();
                    actions.AlternateAttack();
                    break;
                case "MoveTowardsPlayer":
                    //do pathfinding logic and then correct move
                    break;
                case "MoveAwayFromPlayer":
                    //Check direction where player is, then do a move away
                    break;
                case "MoveRandomly":
                    //choose a random direction then move there
                    break;
                default:
                    actions.Wait();
                    break;
            }
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
            enemyType.GetPrimaryAttack().Execute(transform);
        }

        public override void ExecuteSecondaryAttack()
        {
            enemyType.GetSecondaryAttack().Execute(transform);
        }

        public override bool IsFlying()
        {
            return enemyType.IsFlying();
        }
        public override bool IsHeavy()
        {
            return enemyType.IsHeavy();
        }

        public override void SetFlying(bool value)
        {
            enemyType.SetFlying(value);
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
            return enemyType.GetName();
        }

        public override void UpdateInteractables()
        {
            //Enemies don't use interactables for now
        }
    }
}
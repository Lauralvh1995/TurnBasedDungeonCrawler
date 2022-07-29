using Assets.Scripts.Grid;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Entity
{
    [RequireComponent(typeof(EntityActions))]
    public abstract class Entity : MonoBehaviour
    {
        [SerializeField] protected int health;
        [SerializeField] protected Transform spawnPoint;
        [SerializeField] protected EntityActions actions;

        public void CheckFloor()
        {
            actions.CheckFloor();
        }
        public void TakeDamage(int damage)
        {
            health -= damage;
            Debug.Log(GetName() + " took " + damage + ". Health remaining: " + health);
            if (health <= 0)
            {
                Die();
            }
        }
        protected abstract string GetName();

        public abstract void UpdateInteractables();

        public abstract void ExecutePrimaryAttack();

        public abstract void ExecuteSecondaryAttack();

        public abstract void ExecuteInteraction();

        public abstract void SetFlying(bool value);

        public abstract bool IsFlying();
        public abstract bool IsHeavy();
        public virtual void Die()
        {
            Debug.Log(GetName() + " died :(");
        }

        public virtual void Respawn()
        {
            GridController.Instance.UpdatePassability(transform.position);
            GetComponent<BoxCollider>().enabled = false;
            transform.position = spawnPoint.position;
            transform.rotation = spawnPoint.rotation;
            GetComponent<BoxCollider>().enabled = true;
            GridController.Instance.UpdatePassability(transform.position);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Assets.Scripts.Entity
{
    public abstract class State : MonoBehaviour
    {
        protected EnemyBrain brain;
        public EnemyBrain Brain => brain;

        protected EntityActions actions;
        public EntityActions Actions => actions;

        protected StateTransition[] transitions;
        private void Awake()
        {
            transitions = GetComponentsInChildren<StateTransition>();
        }

        private void Start()
        {
            gameObject.SetActive(false);
        }

        public void EnterState(EnemyBrain brain, EntityActions actions)
        {
            this.brain = brain;
            this.actions = actions;
            gameObject.SetActive(true);
        }

        public abstract void ExecuteState();

        public void ExitState()
        {
            gameObject.SetActive(false);
        }
    }
}
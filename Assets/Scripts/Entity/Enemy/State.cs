using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Assets.Scripts.Entity
{
    public abstract class State : MonoBehaviour
    {
        protected EnemyBrain brain;
        public EnemyBrain Brain => brain;

        [SerializeField] protected StateTransition[] transitions;
        private void Awake()
        {
            transitions = GetComponentsInChildren<StateTransition>();
            gameObject.SetActive(false);
        }

        private void Start()
        {

        }

        public void CheckTransitions()
        {
            foreach(StateTransition t in transitions)
            {
                t.TransitionIfConditionsMet();
            }
        }

        public virtual void EnterState(EnemyBrain brain)
        {
            this.brain = brain;
            gameObject.SetActive(true);
        }

        public abstract void ExecuteState();

        public void ExitState()
        {
            gameObject.SetActive(false);
        }
    }
}
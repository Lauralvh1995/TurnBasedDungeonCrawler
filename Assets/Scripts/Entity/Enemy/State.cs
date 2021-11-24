using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Assets.Scripts.Entity
{
    public class State : MonoBehaviour
    {
        private EnemyBrain brain;
        public EnemyBrain Brain => brain;

        private EntityActions actions;
        public EntityActions Actions => actions;

        

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

        public void ExecuteState()
        {
            //do stuffs
        }

        public void ExitState()
        {
            gameObject.SetActive(false);
        }
    }
}
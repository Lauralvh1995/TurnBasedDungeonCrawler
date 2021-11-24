using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Assets.Scripts.Entity
{
    public class EnemyBrain : MonoBehaviour
    {
        public State Current;
        public State DefaultState;

        public List<State> States;

        private EntityActions actions;

        private void Start()
        {
            actions = GetComponent<EntityActions>();
            SetState(DefaultState);
        }

        public void Execute()
        {
            Current.ExecuteState();
        }

        public void SetState(State state)
        {
            if (Current != null)
            {
                Current.ExitState();
            }
            Current = state;
            Current.EnterState(this, actions);
        }
    }
}

using Assets.Scripts.Grid;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Assets.Scripts.Entity
{
    [RequireComponent(typeof(MoveSelector), typeof(Enemy))]
    public class EnemyBrain : MonoBehaviour
    {
        [SerializeField] MoveSelector selector;
        [SerializeField] Player player;
        [SerializeField] Enemy enemy;

        public State Current;
        public State DefaultState;

        public List<State> States;
        //public Pathfinder pathfinder;

        private void Start()
        {
            player = FindObjectOfType<Player>();
            selector = GetComponent<MoveSelector>();
            enemy = GetComponent<Enemy>();
            SetState(DefaultState);
        }

        public void Execute()
        {
            if(gameObject.activeSelf)
                Current.ExecuteState();
        }

        public void SetState(State state)
        {
            if (Current != null)
            {
                Current.ExitState();
            }
            Current = state;
            Current.EnterState(this);
        }

        public void Attack(Vector3 target)
        {
            selector.Attack(target);
        }

        public void AlternateAttack(Vector3 target)
        {
            selector.AlternateAttack(target);
        }

        public void Move(Vector3 target)
        {
            selector.Move(target);
        }

        public void Wait()
        {
            selector.Wait();
        }

        public Player GetPlayer()
        {
            return player;
        }

        public EnemyStats GetEnemyStats()
        {
            return enemy.GetEnemyStats();
        }

        public bool IsFlying()
        {
            return enemy.IsFlying();
        }

        private void OnDisable()
        {
            foreach(State state in States)
            {
                state.enabled = false;
            }
        }
    }
}

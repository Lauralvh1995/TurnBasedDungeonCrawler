using Assets.Scripts.Entity;
using Assets.Scripts.Grid;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Entity
{
    [RequireComponent(typeof(EntityActions), typeof(EnemyBrain))]
    public class MoveSelector : MonoBehaviour
    {

        EnemyBrain brain;
        EntityActions entityActions;


        [SerializeField]List<SequenceMove> moveSequence;

        bool flying;
        bool waiting;

        private void Awake()
        {
            brain = GetComponent<EnemyBrain>();
            entityActions = GetComponent<EntityActions>();
            flying = brain.GetComponent<Enemy>().IsFlying();
        }
        public void Attack(Vector3 target)
        {
            moveSequence = new List<SequenceMove>();
            Direction direction = CheckDirection(target);
            switch (direction)
            {
                case Direction.LEFT:
                    moveSequence.Add(new SequenceMove("Turn Left", entityActions.TurnLeft));
                    break;
                case Direction.RIGHT:
                    moveSequence.Add(new SequenceMove("Turn Right", entityActions.TurnRight));
                    break;
                case Direction.BACK:
                    moveSequence.Add(new SequenceMove("Turn Right", entityActions.TurnRight));
                    moveSequence.Add(new SequenceMove("Turn Right", entityActions.TurnRight));
                    break;
            }
            moveSequence.Add(new SequenceMove("Attack", entityActions.Attack));
            StartCoroutine("ExecuteMoveSequence");
        }

        public void AlternateAttack(Vector3 target)
        {
            moveSequence = new List<SequenceMove>();
            Direction direction = CheckDirection(target);
            switch (direction)
            {
                case Direction.LEFT:
                    moveSequence.Add(new SequenceMove("Turn Left", entityActions.TurnLeft));
                    break;
                case Direction.RIGHT:
                    moveSequence.Add(new SequenceMove("Turn Right", entityActions.TurnRight));
                    break;
                case Direction.BACK:
                    moveSequence.Add(new SequenceMove("Turn Right", entityActions.TurnRight));
                    moveSequence.Add(new SequenceMove("Turn Right", entityActions.TurnRight));
                    break;
            }
            moveSequence.Add(new SequenceMove("Alternate Attack", entityActions.AlternateAttack));
            StartCoroutine("ExecuteMoveSequence");
        }

        public void Move(Vector3 target)
        {
            Debug.Log("Actually trying to execute the move toward " + target);
            moveSequence = new List<SequenceMove>();
            Direction direction = CheckDirection(target);
            switch (direction)
            {
                case Direction.LEFT:
                    moveSequence.Add(new SequenceMove("Turn Left", entityActions.TurnLeft));
                    break;
                case Direction.RIGHT:
                    moveSequence.Add(new SequenceMove("Turn Right", entityActions.TurnRight));
                    break;
                case Direction.BACK:
                    moveSequence.Add(new SequenceMove("Turn Right", entityActions.TurnRight));
                    moveSequence.Add(new SequenceMove("Turn Right", entityActions.TurnRight));
                    break;
            }
            moveSequence.Add(new SequenceMove("Alternate Attack", entityActions.MoveForward));
            //movement logic
            if(gameObject.activeSelf)
                StartCoroutine("ExecuteMoveSequence");
        }

        public void Wait()
        {
            entityActions.Wait();
        }

        private Direction CheckDirection(Vector3 target)
        {
            Vector3 perp = Vector3.Cross(transform.forward, (target - transform.position).normalized);
            float dir = Vector3.Dot(perp, transform.up);

            if (dir > 0.0f)
            {
                return Direction.RIGHT;
            }
            else if (dir < 0.0f)
            {
                return Direction.LEFT;
            }
            else
            {
                Vector3 fwdperp = Vector3.Cross(transform.right, (target - transform.position).normalized);
                float fwddir = Vector3.Dot(fwdperp, transform.up);
                if (dir > 0.0f)
                {
                    return Direction.BACK;
                }
                else if (dir < 0.0f)
                {
                    return Direction.FORWARD;
                }
            }
            return Direction.FORWARD;
        }

        private IEnumerator ExecuteMoveSequence()
        {
            foreach (SequenceMove move in moveSequence)
            {
                move.UseMove();
                Debug.Log(move.ToString());
                yield return null;
            }
        }
    }

    public enum Direction
    {
        LEFT,
        RIGHT,
        FORWARD,
        BACK,
        UP,
        DOWN
    }

    [Serializable]
    public class SequenceMove {
        [SerializeField] string moveName;
        Action move;

        public SequenceMove(string name, Action action)
        {
            moveName = name;
            move = action;
        }

        public void UseMove()
        {
            move();
        }
    }

}

using Assets.Scripts.Entity;
using Assets.Scripts.Grid;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Entity
{
    [RequireComponent(typeof(EntityActions))]
    public class MoveSelector : MonoBehaviour
    {
        EntityActions entityActions;
        [SerializeField]List<SequenceMove> moveSequence;

        private void Awake()
        {
            entityActions = GetComponent<EntityActions>();
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
                case Direction.NONE:
                    moveSequence.Add(new SequenceMove("Idle", entityActions.Wait));
                    return;
            }
            moveSequence.Add(new SequenceMove("Move", entityActions.MoveForward));
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
            Debug.DrawLine(transform.position, transform.position+transform.forward, Color.magenta, 1f);
            //checking in which direction the target is, from the unit.
            int dir = Mathf.RoundToInt(Vector3.Dot(transform.forward, (target - transform.position).normalized));
            if(dir > 0)
                return Direction.FORWARD;
            if (dir < 0)
                return Direction.BACK;
            if(dir == 0)
            {
                dir = Mathf.RoundToInt(Vector3.Dot(transform.right, (target - transform.position).normalized));
                if(dir > 0)
                    return Direction.RIGHT;
                if (dir < 0)
                    return Direction.LEFT;
                if(dir == 0)
                {
                    dir = Mathf.RoundToInt(Vector3.Dot(transform.up, (target - transform.position).normalized));
                    if (dir > 0)
                        return Direction.UP;
                    if (dir < 0)
                        return Direction.DOWN;
                }
            }
            return Direction.NONE;
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
        DOWN,
        NONE
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

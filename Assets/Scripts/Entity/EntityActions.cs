using Assets.Scripts.Entity;
using Assets.Scripts.Grid;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Entity
{
    [RequireComponent(typeof(Entity))]
    public class EntityActions : MonoBehaviour
    {
        [SerializeField] private Entity entity;
        [SerializeField] private float turnSpeed = 0.1f;
        [SerializeField] bool lockedInput;
        [SerializeField] TurnState requiredPhase;

        public void Awake()
        {
            entity = GetComponent<Entity>();
        }
        public void CheckFloor()
        {
            if (!GridController.Instance.GetTileFromWorldPosition(transform.position).Floor)
            {
                lockedInput = true;
                if (!entity.IsFlying())
                {
                    StartCoroutine(FallDown());
                }
            }
        }

        public IEnumerator FallDown()
        {
            Vector3 from = transform.position;
            Vector3 to = transform.position + Vector3.down;

            for (float t = 0f; t <= 1; t += Time.deltaTime / turnSpeed)
            {
                transform.position = Vector3.Lerp(from, to, t);
                yield return null;
            }
            transform.position = to;
            GridController.Instance.UpdatePassability(to);
            GridController.Instance.UpdatePassability(from);
            entity.UpdateInteractables();

            lockedInput = false;
            CheckFloor();
        }

        public void LockInput(bool state)
        {
            lockedInput = state;
        }

        public void MoveForward()
        {
            if (!lockedInput && TurnManager.Instance.TurnState == requiredPhase)
            {
                lockedInput = true;
                StartCoroutine(Move(Vector3.forward, turnSpeed));
            }
        }
        public void MoveBackward()
        {
            if (!lockedInput && TurnManager.Instance.TurnState == requiredPhase)
            {
                lockedInput = true;
                StartCoroutine(Move(Vector3.back, turnSpeed));
            }
        }
        public void TurnLeft()
        {
            if (!lockedInput && TurnManager.Instance.TurnState == requiredPhase)
            {
                lockedInput = true;
                StartCoroutine(Rotate(Vector3.up * -90, turnSpeed));
            }
        }
        public void TurnRight()
        {
            if (!lockedInput && TurnManager.Instance.TurnState == requiredPhase)
            {
                lockedInput = true;
                StartCoroutine(Rotate(Vector3.up * 90, turnSpeed));
            }
        }
        public void StrafeLeft()
        {
            if (!lockedInput && TurnManager.Instance.TurnState == requiredPhase)
            {
                lockedInput = true;
                StartCoroutine(Move(Vector3.left, turnSpeed));
            }
        }
        public void StrafeRight()
        {
            if (!lockedInput && TurnManager.Instance.TurnState == requiredPhase)
            {
                lockedInput = true;
                StartCoroutine(Move(Vector3.right, turnSpeed));
            }
        }
        public void Attack()
        {
            if (!lockedInput && TurnManager.Instance.TurnState == requiredPhase)
            {
                if (!EventSystem.current.IsPointerOverGameObject() || entity is Enemy)
                    entity.ExecutePrimaryAttack();
                PassTurn();
            }
        }
        public void AlternateAttack()
        {
            if (!lockedInput && TurnManager.Instance.TurnState == requiredPhase)
            {
                if (!EventSystem.current.IsPointerOverGameObject() || entity is Enemy)
                    entity.ExecuteSecondaryAttack();
                PassTurn();
            }
        }
        public void Wait()
        {
            if (!lockedInput && TurnManager.Instance.TurnState == requiredPhase)
            {
                PassTurn();
            }
        }
        public void Interact()
        {
            if (!lockedInput && TurnManager.Instance.TurnState == requiredPhase)
            {
                entity.ExecuteInteraction();
                PassTurn();
            }
        }

        private IEnumerator Rotate(Vector3 angle, float time)
        {
            var fromAngle = transform.rotation;
            var toAngle = Quaternion.Euler(transform.eulerAngles + angle);
            for (var t = 0f; t <= 1; t += Time.deltaTime / time)
            {
                transform.rotation = Quaternion.Slerp(fromAngle, toAngle, t);
                yield return null;
            }
            transform.rotation = toAngle;
            entity.UpdateInteractables();
            lockedInput = false;
        }

        private IEnumerator Move(Vector3 direction, float time)
        {
            Vector3 from = transform.position;
            Vector3 to = transform.position + transform.rotation * direction;
            if (GridController.Instance.CanMoveThere(from, to, entity.IsFlying()))
            {
                for (float t = 0f; t <= 1; t += Time.deltaTime / time)
                {
                    transform.position = Vector3.Lerp(from, to, t);
                    yield return null;
                }
                transform.position = to;
                GridController.Instance.UpdatePassability(to);
                GridController.Instance.UpdatePassability(from);

                PassTurn();
            }
            lockedInput = false;
        }

        void PassTurn()
        {
            CheckFloor();
            entity.UpdateInteractables();
            TurnManager.Instance.PassTurn();
        }
    }

}
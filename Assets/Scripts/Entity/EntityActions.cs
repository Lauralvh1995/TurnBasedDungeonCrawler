using Assets.Scripts.Grid;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Entity))]
public class EntityActions : MonoBehaviour
{
    [SerializeField] private Entity entity;
    [SerializeField] private float turnSpeed = 0.1f;
    [SerializeField] bool lockedInput;

    public void Awake()
    {
        entity = GetComponent<Entity>();
    }

    public void LockInput(bool state)
    {
        lockedInput = state;
    }

    public void MoveForward() {
        if (!lockedInput)
        {
            lockedInput = true;
            StartCoroutine(Move(Vector3.forward, turnSpeed));
        }
    }
    public void MoveBackward() {
        if (!lockedInput)
        {
            lockedInput = true;
            StartCoroutine(Move(Vector3.back, turnSpeed));
        }
    }
    public void TurnLeft() {
        if (!lockedInput)
        {
            lockedInput = true;
            StartCoroutine(Rotate(Vector3.up * -90, turnSpeed));
        }
    }
    public void TurnRight() {
        if (!lockedInput)
        {
            lockedInput = true;
            StartCoroutine(Rotate(Vector3.up * 90, turnSpeed));
        }
    }
    public void StrafeLeft() {
        if (!lockedInput)
        {
            lockedInput = true;
            StartCoroutine(Move(Vector3.left, turnSpeed));
        }
    }
    public void StrafeRight() {
        if (!lockedInput)
        {
            lockedInput = true;
            StartCoroutine(Move(Vector3.right, turnSpeed));
        }
    }
    public void Attack() 
    {
        if (!lockedInput)
        {
            if (!EventSystem.current.IsPointerOverGameObject() || entity is Enemy)
                entity.ExecutePrimaryAttack();
            TurnManager.Instance.PassTurn();
        }
    }
    public void AlternateAttack()
    {
        if (!lockedInput)
        {
            if (!EventSystem.current.IsPointerOverGameObject() || entity is Enemy)
                entity.ExecuteSecondaryAttack();
            TurnManager.Instance.PassTurn();
        }
    }
    public void Wait() 
    {
        if (!lockedInput)
        {
            TurnManager.Instance.PassTurn();
        }
    }
    public void Interact() 
    {
        if (!lockedInput)
        {
            entity.ExecuteInteraction();
            TurnManager.Instance.PassTurn();
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
            entity.UpdateInteractables();
            TurnManager.Instance.PassTurn();
        }
        lockedInput = false;
    }
}


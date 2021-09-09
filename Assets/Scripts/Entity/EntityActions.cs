using Assets.Scripts.Grid;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Entity))]
public class EntityActions : MonoBehaviour
{
    [SerializeField] private Entity entity;

    [SerializeField] private GridController grid;
    [SerializeField] private float turnSpeed = 0.1f;
    bool lockedInput;

    public void Awake()
    {
        entity = GetComponent<Entity>();
        if(grid == null)
            grid = FindObjectOfType<GridController>();
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
        entity.ExecutePrimaryAttack();
    }
    public void AlternateAttack() 
    {
        entity.ExecuteSecondaryAttack();
    }
    public void Wait() 
    { 
        //Pass turn
    }
    public void Interact() 
    {
        entity.ExecuteInteraction();
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
        lockedInput = false;
    }

    private IEnumerator Move(Vector3 direction, float time)
    {
        Vector3 from = transform.position;
        Vector3 to = transform.position + transform.rotation * direction;
        //TODO: Add flying support
        if (grid.CanMoveThere(from, to, entity.IsFlying()))
        {
            for (float t = 0f; t <= 1; t += Time.deltaTime / time)
            {
                transform.position = Vector3.Lerp(from, to, t);
                yield return null;
            }
            transform.position = to;
            //grid.Regenerate();
        }
        lockedInput = false;
        grid.UpdatePassability(to);
        grid.UpdatePassability(from);
    }
}


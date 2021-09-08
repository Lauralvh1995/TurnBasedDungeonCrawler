using Assets.Scripts.Grid;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActionInput : MonoBehaviour
{
    [SerializeField] private GridController grid;
    [SerializeField] private float turnSpeed = 0.8f;
    bool lockedInput;

    public virtual void Awake()
    {
        if(grid == null)
            grid = FindObjectOfType<GridController>();
    }
    public virtual void MoveForward() {
        if (!lockedInput)
        {
            lockedInput = true;
            StartCoroutine(Move(Vector3.forward, turnSpeed));
        }
    }
    public virtual void MoveBackward() {
        if (!lockedInput)
        {
            lockedInput = true;
            StartCoroutine(Move(Vector3.back, turnSpeed));
        }
    }
    public virtual void TurnLeft() {
        if (!lockedInput)
        {
            lockedInput = true;
            StartCoroutine(Rotate(Vector3.up * -90, turnSpeed));
        }
    }
    public virtual void TurnRight() {
        if (!lockedInput)
        {
            lockedInput = true;
            StartCoroutine(Rotate(Vector3.up * 90, turnSpeed));
        }
    }
    public virtual void StrafeLeft() {
        if (!lockedInput)
        {
            lockedInput = true;
            StartCoroutine(Move(Vector3.left, turnSpeed));
        }
    }
    public virtual void StrafeRight() {
        if (!lockedInput)
        {
            lockedInput = true;
            StartCoroutine(Move(Vector3.right, turnSpeed));
        }
    }
    public virtual void Attack() { }
    public virtual void AlternateAttack() { }
    public virtual void Wait() { }

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
        if (grid.CanMoveThere(from, to, false))
        {
            for (float t = 0f; t <= 1; t += Time.deltaTime / time)
            {
                transform.position = Vector3.Lerp(from, to, t);
                yield return null;
            }
            transform.position = to;
            grid.Regenerate();
        }
        lockedInput = false;
    }
}


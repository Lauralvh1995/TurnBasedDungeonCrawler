using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActionInput : MonoBehaviour
{
    [SerializeField] private float turnSpeed = 0.8f;
    bool lockedInput;
    public virtual void MoveForward() {
        //check if possible to move there with grid
        lockedInput = true;
        StartCoroutine(Move(Vector3.forward, turnSpeed));
        //do move
    }
    public virtual void MoveBackward() {
        //check if possible to move there with grid
        lockedInput = true;
        StartCoroutine(Move(Vector3.back, turnSpeed));
        //do move
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
        //check if possible to move there with grid
        lockedInput = true;
        StartCoroutine(Move(Vector3.left, turnSpeed));
        //do move
    }
    public virtual void StrafeRight() {
        //check if possible to move there with grid
        lockedInput = true;
        StartCoroutine(Move(Vector3.right, turnSpeed));
        //do move
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
        for (float t = 0f; t <= 1; t += Time.deltaTime / time)
        {
            transform.position = Vector3.Lerp(from, to, t);
            yield return null;
        }
        transform.position = to;
        lockedInput = false;
    }
}

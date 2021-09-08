using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActionInput : MonoBehaviour
{
    [SerializeField] private float turnSpeed = 0.8f;
    bool lockedInput;
    public virtual void MoveForward() { }
    public virtual void MoveBackward() { }
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
    public virtual void StrafeLeft() { }
    public virtual void StrafeRight() { }
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
}

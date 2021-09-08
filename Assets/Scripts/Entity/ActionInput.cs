using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActionInput : MonoBehaviour
{
    public virtual void MoveForward() { }
    public virtual void MoveBackward() { }
    public virtual void TurnLeft() { }
    public virtual void TurnRight() { }
    public virtual void StrafeLeft() { }
    public virtual void StrafeRight() { }
    public virtual void Attack() { }
    public virtual void AlternateAttack() { }
    public virtual void Wait() { }
}

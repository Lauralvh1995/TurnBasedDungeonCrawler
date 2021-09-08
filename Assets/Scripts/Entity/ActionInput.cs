using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActionInput : MonoBehaviour
{
    public abstract void MoveForward();
    public abstract void MoveBackward();
    public abstract void TurnLeft();
    public abstract void TurnRight();
    public abstract void StrafeLeft();
    public abstract void StrafeRight();
    public abstract void Attack();
    public abstract void AlternateAttack();
    public abstract void Wait();
    public abstract void Interact();
}

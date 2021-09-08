using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerActionInput : ActionInput
{
    private PlayerInput playerInput;

    private InputAction moveForward;
    private InputAction moveBackward;
    private InputAction turnLeft;
    private InputAction turnRight;
    private InputAction strafeLeft;
    private InputAction strafeRight;
    private InputAction attack;
    private InputAction alternateAttack;
    private InputAction wait;
    private InputAction interact;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();

        moveForward = playerInput.actions["MoveForward"];
        moveBackward = playerInput.actions["MoveBackward"];
        turnLeft = playerInput.actions["TurnLeft"];
        turnRight = playerInput.actions["TurnRight"];
        strafeLeft = playerInput.actions["StrafeLeft"];
        strafeRight = playerInput.actions["StrafeRight"];
        attack = playerInput.actions["Attack"];
        alternateAttack = playerInput.actions["AlternateAttack"];
        wait = playerInput.actions["Wait"];
        interact = playerInput.actions["Interact"];
    }

    private void OnEnable()
    {
        moveForward.performed += _ => MoveForward();
        moveBackward.performed += _ => MoveBackward();
        turnLeft.performed += _ => TurnLeft();
        turnRight.performed += _ => TurnRight();
        strafeLeft.performed += _ => StrafeLeft();
        strafeRight.performed += _ => StrafeRight();
        attack.performed += _ => Attack();
        alternateAttack.performed += _ => AlternateAttack();
        wait.performed += _ => Wait();
        interact.performed += _ => Interact();
    }
    private void OnDisable()
    {
        
    }

    public override void AlternateAttack()
    {
        Debug.Log("Alternate Attack");
    }

    public override void Attack()
    {
        Debug.Log("Attack");
    }

    public override void MoveBackward()
    {
        Debug.Log("Moving backward");
    }

    public override void MoveForward()
    {
        Debug.Log("Moving forward");
    }

    public override void StrafeLeft()
    {
        Debug.Log("Strafing Left");
    }

    public override void StrafeRight()
    {
        Debug.Log("Strafing Right");
    }

    public override void TurnLeft()
    {
        Debug.Log("Turning Left");
    }

    public override void TurnRight()
    {
        Debug.Log("Turning Right");
    }

    public override void Wait()
    {
        Debug.Log("Waiting");
    }

    public override void Interact()
    {
        Debug.Log("Interacting");
    }
}

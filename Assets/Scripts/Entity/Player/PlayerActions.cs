using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[RequireComponent(typeof(EntityActions))]
public class PlayerActions : MonoBehaviour
{
    private Player player;
    private PlayerInput playerInput;
    private EntityActions actions;

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

    [SerializeField] private UnityEvent pauseGame;
    [SerializeField] private UnityEvent openMap;

    public void Awake()
    {
        player = GetComponent<Player>();
        playerInput = GetComponent<PlayerInput>();
        actions = GetComponent<EntityActions>();

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

    //private void OnEnable()
    //{
    //    moveForward.performed += _ => actions.MoveForward();
    //    moveBackward.performed += _ => actions.MoveBackward();
    //    turnLeft.performed += _ => actions.TurnLeft();
    //    turnRight.performed += _ => actions.TurnRight();
    //    strafeLeft.performed += _ => actions.StrafeLeft();
    //    strafeRight.performed += _ => actions.StrafeRight();
    //    attack.performed += _ => actions.Attack();
    //    alternateAttack.performed += _ => actions.AlternateAttack();
    //    wait.performed += _ => actions.Wait();
    //    interact.performed += _ => actions.Interact();
    //}

    public void MoveForward(InputAction.CallbackContext context)
    {
        if (context.performed)
            actions.MoveForward();
    }
    public void MoveBackward(InputAction.CallbackContext context)
    {
        if (context.performed)
            actions.MoveBackward();
    }
    public void TurnLeft(InputAction.CallbackContext context)
    {
        if (context.performed)
            actions.TurnLeft();
    }
    public void TurnRight(InputAction.CallbackContext context)
    {
        if (context.performed)
            actions.TurnRight();
    }
    public void StrafeLeft(InputAction.CallbackContext context)
    {
        if (context.performed)
            actions.StrafeLeft();
    }
    public void StrafeRight(InputAction.CallbackContext context)
    {
        if (context.performed)
            actions.StrafeRight();
    }
    public void Attack(InputAction.CallbackContext context)
    {
        if (context.performed)
            actions.Attack();
    }
    public void AlternateAttack(InputAction.CallbackContext context)
    {
        if (context.performed)
            actions.AlternateAttack();
    }
    public void Wait(InputAction.CallbackContext context)
    {
        if (context.performed)
            actions.Wait();
    }
    public void Interact(InputAction.CallbackContext context)
    {
        if (context.performed)
            actions.Interact();
    }
    public void Pause()
    {
        actions.LockInput(true);
        pauseGame.Invoke();
    }

    public void OpenMenu()
    {
        actions.LockInput(true);
        openMap.Invoke();
    }
}

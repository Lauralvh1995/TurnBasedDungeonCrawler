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

    [SerializeField] private MapCameraController mapCameraController;
    [SerializeField] private PauseMenuController pauseMenuController;

    [SerializeField] private UnityEvent pauseGame;
    [SerializeField] private UnityEvent openMap;
    [SerializeField] private UnityEvent closeMap;

    public void Awake()
    {
        player = GetComponent<Player>();
        playerInput = GetComponent<PlayerInput>();
        actions = GetComponent<EntityActions>();
    }

    public void SwitchInput(string mapName)
    {
        playerInput.actions.Disable();
        playerInput.SwitchCurrentActionMap(mapName);
        Debug.Log(playerInput.currentActionMap);
    }

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
    

    
    public void CycleTargetIndexUp(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            player.CycleTargetIndexUp();
        }
    }
    public void CycleTargetIndexDown(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            player.CycleTargetIndexDown();
        }
    }
    public void OpenMap(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            openMap.Invoke();
            SwitchInput("Map");
        }
    }
    public void MoveMap(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Vector2 direction = context.ReadValue<Vector2>();            
            mapCameraController.MoveMap(new Vector3(direction.x, 0f, direction.y));
        }
    }
    public void ExitMap(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            closeMap.Invoke();
            SwitchInput("Player");
        }
    }
    public void ZoomIn(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            mapCameraController.ZoomIn();
        }
    }
    public void ZoomOut(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            mapCameraController.ZoomOut();
        }
    }
    public void GoUpLevel(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            mapCameraController.GoUpLevel();
        }
    }
    public void GoDownLevel(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            mapCameraController.GoDownLevel();
        }
    }
    public void ResetMap(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            mapCameraController.ResetMap();
        }
    }
    public void Pause(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            pauseGame.Invoke();
            SwitchInput("UI");
        }
    }
    public void Unpause(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            pauseMenuController.Unpause();
        }
    }
}

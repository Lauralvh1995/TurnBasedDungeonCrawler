using Assets.Scripts.Grid;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : Interactable
{
    [SerializeField] private Vector3 localDestination;
    [SerializeField] private Player player;
    [SerializeField] private GridController grid;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
        grid = FindObjectOfType<GridController>();
    }
    public override void Execute()
    {
        Vector3 playerOldPos = player.transform.position;
        player.transform.position = transform.position + transform.rotation * localDestination;
        player.UpdateInteractables();
        grid.UpdatePassability(playerOldPos);
    }

    public override void Execute(Attack interactingAttack, Vector3 origin)
    {
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position + transform.rotation * localDestination, 0.1f);
    }
}

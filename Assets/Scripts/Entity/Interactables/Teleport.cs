using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : Interactable
{
    [SerializeField] private Vector3 localDestination;
    [SerializeField] private Player player;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
    }
    public override void Execute()
    {
        player.transform.position += transform.rotation * localDestination;
        player.UpdateInteractables();
    }

    public override void Execute(Attack interactingAttack, Vector3 origin)
    {
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position + transform.rotation * localDestination, 0.1f);
    }
}

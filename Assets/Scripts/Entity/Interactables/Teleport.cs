using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : Interactable
{
    [SerializeField] private Vector3 destination;
    [SerializeField] private Player player;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
    }
    public override void Execute()
    {
        player.transform.position = destination;
    }

    public override void Execute(Attack interactingAttack, Vector3 origin)
    {
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(destination, 0.1f);
    }
}

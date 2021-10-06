using Assets.Scripts.Grid;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : Listener
{
    [SerializeField] private Vector3 localDestination;
    [SerializeField] private Player player;
    private void Awake()
    {
        player = FindObjectOfType<Player>();
    }
    public override void Execute()
    {
         bool check = false;
        foreach(Condition c in conditions)
        {
            check = c.Check();
        }
        if (check)
        {
            Vector3 playerOldPos = player.transform.position;
            player.transform.position = transform.position + transform.rotation * localDestination;
            player.UpdateInteractables();
            GridController.Instance.UpdatePassability(playerOldPos);
        }
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.DrawSphere(transform.position + transform.rotation * localDestination, 0.1f);
    //}
}

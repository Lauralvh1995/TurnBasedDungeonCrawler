using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : Trigger
{
    [SerializeField] private Attack contents;
    [SerializeField] private Player player;

    [SerializeField] private Transform itemGraphic;
    public override void Execute()
    {
        //add attack to player's list(s)
        //slot it in

        if(contents is MeleeAttack)
        {
            MeleeAttack a = contents as MeleeAttack;
            player.AddMeleeAttack(a);
        }

        if(contents is RangeAttack)
        {
            RangeAttack b = contents as RangeAttack;
            player.AddRangeAttack(b);
        }
        itemGraphic.gameObject.SetActive(false);
    }
    public override void Execute(Attack attack, Vector3 origin)
    {
        //throw new System.NotImplementedException();
    }
}

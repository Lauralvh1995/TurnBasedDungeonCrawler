using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : Trigger
{
    [SerializeField] private Attack contents;
    [SerializeField] private Player player;
    [SerializeField] private bool alreadyTriggered;
    [SerializeField] private Transform itemGraphic;
    public override void Execute()
    {
        //add attack to player's list(s)
        //slot it in
        if (!alreadyTriggered)
        {
            if (contents is MeleeAttack)
            {
                MeleeAttack a = contents as MeleeAttack;
                player.AddMeleeAttack(a);
            }

            if (contents is RangeAttack)
            {
                RangeAttack b = contents as RangeAttack;
                player.AddRangeAttack(b);
            }
            foreach(Listener l in listeners)
            {
                l.Execute();
            }
            itemGraphic.gameObject.SetActive(false);
            alreadyTriggered = true;
        }
    }
    public override void Execute(Attack attack, Vector3 origin)
    {
        //throw new System.NotImplementedException();
    }
}

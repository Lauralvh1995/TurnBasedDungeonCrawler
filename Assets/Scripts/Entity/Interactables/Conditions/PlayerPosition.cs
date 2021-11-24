using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Assets.Scripts.Entity
{
    public class PlayerPosition : Condition
    {
        [SerializeField] Player player;
        private void Awake()
        {
            player = FindObjectOfType<Player>();
        }
        public override bool Check()
        {
            return Vector3.Distance(transform.position, player.transform.position) < 0.1f;
        }
    }
}

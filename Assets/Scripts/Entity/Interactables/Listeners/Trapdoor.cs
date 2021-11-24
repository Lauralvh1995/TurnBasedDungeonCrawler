using Assets.Scripts.Grid;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Assets.Scripts.Entity
{
    public class Trapdoor : Listener
    {
        [SerializeField] private bool on;
        [SerializeField] private Transform fill;

        public void ChangeState(bool state)
        {
            on = state;
            fill.gameObject.SetActive(on);
            Debug.Log("Trapdoor at " + transform.position + " updating");
            GridController.Instance.UpdatePassability(transform.position);
        }

        public override void Execute()
        {
            bool check = false;
            foreach (Condition c in conditions)
            {
                check = c.Check();
            }
            if (check)
            {
                ChangeState(!on);
            }
        }
    }
}

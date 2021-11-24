using Assets.Scripts.Grid;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Assets.Scripts.Entity
{
    public class IceTile : TempTileObject
    {
        [SerializeField] Transform graphic;
        [SerializeField] Material brokenMat;
        int waitCount = 0;
        private void OnEnable()
        {
            listeners = FindObjectsOfType<Valve>();
            foreach (Listener l in listeners)
            {
                if (l is Valve)
                {
                    Valve v = l as Valve;
                    v.waterLevelChanged.AddListener(Die);
                }
            }
            TurnManager.Instance.onIceTick.AddListener(OnTurnTick);
        }

        public override void OnTurnTick()
        {
            if (disappearCondition.Check())
            {
                triggered = true;
                graphic.GetComponent<Renderer>().material = brokenMat;
            }

            if (triggered)
            {
                waitCount++;
                if (waitCount > 1)
                    Die(true);
            }
        }

        protected void Die(bool set)
        {
            foreach (Listener l in listeners)
            {
                if (l is Valve)
                {
                    Valve v = l as Valve;
                    v.waterLevelChanged.RemoveListener(Die);
                }
            }
            TurnManager.Instance.onIceTick.RemoveListener(OnTurnTick);
            Vector3 pos = transform.position;
            graphic.GetComponent<BoxCollider>().enabled = false;
            GridController.Instance.UpdatePassability(pos);
            GridController.Instance.UpdatePassability(pos + Vector3.down);

            Destroy(gameObject);
        }
    }
}
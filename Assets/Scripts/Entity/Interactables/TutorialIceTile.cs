using Assets.Scripts.Grid;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Assets.Scripts.Entity
{
    public class TutorialIceTile : TempTileObject
    {
        [SerializeField] Transform graphic;
        [SerializeField] Material brokenMat;
        int waitCount = 0;
        private void Start()
        {
            listeners = FindObjectsOfType<Valve>();
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
            TurnManager.Instance.onStartEnvironmentTurn.RemoveListener(OnTurnTick);
            Vector3 pos = transform.position;
            graphic.GetComponent<BoxCollider>().enabled = false;
            GridController.Instance.UpdatePassability(pos);
            GridController.Instance.UpdatePassability(pos + Vector3.down);

            Destroy(gameObject);
        }
    }
}

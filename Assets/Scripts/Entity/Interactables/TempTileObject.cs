using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Assets.Scripts.Entity
{
    public abstract class TempTileObject : MonoBehaviour
    {
        [SerializeField] protected Condition disappearCondition;
        [SerializeField] protected Listener[] listeners;

        [SerializeField] protected bool triggered;
        // Update is called once per frame
        private void OnEnable()
        {
            //add yourself as listener to listeners
        }
        public virtual void OnTurnTick()
        {
            if (disappearCondition.Check())
            {
                triggered = true;
            }
            if (triggered)
            {
                Die();
            }
        }

        protected virtual void Die()
        {
            //remove yourself as listener from listeners
            Destroy(this);
        }
    }
}
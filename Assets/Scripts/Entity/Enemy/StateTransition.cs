using Assets.Scripts.Entity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateTransition : MonoBehaviour
{
    
    public State transitionTo;

    [SerializeField] private StateChangeCondition[] conditions;
    private EnemyBrain brain;
    private void Awake()
    {
        brain = GetComponentInParent<EnemyBrain>();
        if (brain == null) Debug.LogError("Brain not found", this);
        conditions = GetComponents<StateChangeCondition>();
    }

    public void TransitionIfConditionsMet()
    {
        if (conditions == null) 
        { 
            Debug.LogError("No conditions", this);
            return;
        }

        bool pass = false;
        foreach(StateChangeCondition condition in conditions)
        {
            if (condition.ConditionMet())
                pass = true;
            else
                pass = false;
        }
        if (pass)
        {
            brain.SetState(transitionTo);
        }
    }
}
[RequireComponent(typeof(StateTransition))]
public abstract class StateChangeCondition : MonoBehaviour
{
    public abstract bool ConditionMet();
}

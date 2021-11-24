using Assets.Scripts.Entity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(State))]
public class Idle : MonoBehaviour
{
    private State state;
    private EntityActions actions;

    [SerializeField] private State OnNoticePlayer;

    private void Awake()
    {
        state = GetComponent<State>();
        actions = state.Actions;
    }

    public void Execute()
    {
        //do nothing special, just wait
        actions.Wait();
    }
}

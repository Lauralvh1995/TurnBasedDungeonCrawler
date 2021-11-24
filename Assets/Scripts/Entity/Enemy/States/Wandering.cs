using Assets.Scripts.Entity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(State))]
public class Wandering : MonoBehaviour
{
    private State state;
    private EntityActions actions;

    [SerializeField] private State OnNoticePlayer;

    private void Awake()
    {
        state = GetComponent<State>();
    }
    public void Execute()
    {
        //make random move
    }
}

using Assets.Scripts.Entity;
using Assets.Scripts.Grid;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TurnManager : MonoBehaviour
{
    public static TurnManager Instance { get; private set; }
    public TurnState TurnState;
    public OnTurnEvent onStartPlayerTurn;
    public OnTurnEvent onStartEnvironmentTurn;
    public OnTurnEvent onIceTick;

    public List<Enemy> enemies;

    private void Awake()
    {
        Instance = this;
        TurnState = TurnState.Player;
    }
    private void Start()
    {
        Enemy[] enemyArray = FindObjectsOfType<Enemy>();
        foreach(Enemy e in enemyArray)
        {
            enemies.Add(e);
        }
    }
    public bool IsPlayerTurn()
    {
        return TurnState == TurnState.Player;
    }

    public void PassTurn()
    {
        switch (TurnState)
        {
            case TurnState.Player:
                TurnState = TurnState.Environment;
                foreach(Enemy e in enemies)
                {
                    e.StartNewTurn();
                }
                onStartEnvironmentTurn.Invoke();
                onIceTick.Invoke();
                break;
            case TurnState.Environment:
                //check if all enemies passed their turn, then 
                bool allEnemiesDone = true;
                foreach(Enemy e in enemies)
                {
                    if (e.TookTurn())
                    {
                        allEnemiesDone = true;
                    }
                    else
                    {
                        allEnemiesDone = false;
                    }
                }
                if (allEnemiesDone)
                {
                    TurnState = TurnState.Player;
                    onStartPlayerTurn.Invoke();
                }
                break;
        }
    }

    public void ProcessEnemies()
    {
        if(enemies.Count <= 0)
        {
            PassTurn();
        }
        foreach(Enemy e in enemies)
        {
            e.CheckFloor();
            e.TakeAction();
        }
        PassTurn();
    }
}

public enum TurnState
{
    Player,
    Environment
}

[Serializable]
public class OnTurnEvent : UnityEvent
{

}

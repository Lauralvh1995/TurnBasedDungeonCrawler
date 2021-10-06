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

    public List<Enemy> enemies;

    private void Awake()
    {
        Instance = this;
        TurnState = TurnState.Player;
        
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
                onStartEnvironmentTurn.Invoke();
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

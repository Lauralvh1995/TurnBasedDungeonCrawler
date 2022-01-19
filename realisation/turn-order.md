# Turn Order

The game is turn based, so there needs to be a way to track whose turn it is. The player can only act on their turn, then the environment will take theirs.

```
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
                onIceTick.Invoke();
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
```

![](<../.gitbook/assets/image (5) (1).png>)

The game communicates between parts via the EventSystem.&#x20;

Handling the ice tiles is done separately, to make sure the ice is broken before the entities start their turn.

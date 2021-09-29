using Assets.Scripts.Grid;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Ice Beam Property", menuName ="Attacks/Attack Properties/Ice Beam")]
public class IceBeamProperty : AttackProperty
{
    [SerializeField] Transform iceTilePrefab;
    public override void ExecuteAttackProperty(Vector3 location)
    {
        Debug.Log("Executing Beam Effect");
        Tile currentTile = GridController.Instance.GetTileFromWorldPosition(location);
        Debug.Log("Checking " + currentTile?.ToString());
        if (currentTile?.GetFlooded() == false)
        {
            Debug.Log(currentTile.ToString() + " is not flooded");
            if (currentTile?.Floor == false)
            {
                Debug.Log(currentTile.ToString() + " has no floor");
                Tile iceTile = GridController.Instance.GetTileFromWorldPosition(location + Vector3.down);
                if (iceTile?.Ceiling == false)
                {
                    Debug.Log(iceTile.ToString() + " has no ceiling");
                    if (iceTile?.GetFlooded() == true)
                    {
                        Debug.Log(iceTile.ToString() + " is flooded");
                        Debug.Log("Spawning ice on top of " + iceTile.ToString());
                        Instantiate(iceTilePrefab, location, Quaternion.identity);
                        GridController.Instance.UpdatePassability(location);
                        GridController.Instance.UpdatePassability(location + Vector3.down);
                    }
                }
            }
        }
    }
}

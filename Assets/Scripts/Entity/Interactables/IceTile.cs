using Assets.Scripts.Grid;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceTile : TempTileObject
{
    [SerializeField] Transform graphic;
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
    }

    protected override void Die(bool set)
    {
        foreach (Listener l in listeners)
        {
            if (l is Valve)
            {
                Valve v = l as Valve;
                v.waterLevelChanged.RemoveListener(Die);
            }
        }
        Vector3 pos = transform.position;
        graphic.GetComponent<BoxCollider>().enabled = false;
        GridController.Instance.UpdatePassability(pos);
        GridController.Instance.UpdatePassability(pos + Vector3.down);

        Destroy(gameObject);
    }
}

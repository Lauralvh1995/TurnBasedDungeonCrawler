using Assets.Scripts.Grid;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Entity
{
    [CreateAssetMenu(fileName = "Ice Beam Property", menuName = "Attacks/Attack Properties/Ice Beam")]
    public class IceBeamProperty : AttackProperty
    {
        [SerializeField] LayerMask water;[SerializeField] LayerMask ground; int waterMask;[SerializeField] Transform iceTilePrefab; public override void ExecuteAttackProperty(Vector3 location)
        {
            waterMask = water | ground;
            Debug.Log("Executing Beam Effect");
            Tile currentTile = GridController.Instance.GetTileFromWorldPosition(location);
            Debug.Log("Checking " + currentTile?.ToString());
            RaycastHit raycastHit;
            Ray ray = new Ray(location, Vector3.down);
            Physics.Raycast(ray, out raycastHit, 1f, waterMask);
            Debug.DrawRay(location, Vector3.down, Color.cyan, 0.5f);
            Debug.Log("hit " + raycastHit.collider?.name);
            if (raycastHit.collider?.GetComponent<WaterLevel>())
            {
                Instantiate(iceTilePrefab, location, Quaternion.identity);
                GridController.Instance.UpdatePassability(location);
                GridController.Instance.UpdatePassability(location + Vector3.down);
            }
        }
    }
}

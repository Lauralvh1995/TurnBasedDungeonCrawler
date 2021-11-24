using Assets.Scripts.Entity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapCameraController : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Vector3 offset;

    private void Update()
    {
        transform.position = player.transform.position + offset;
    }


}

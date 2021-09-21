using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCameraController : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Vector3 offset;

    void ResetMap()
    {
        transform.position = player.transform.position + offset;
    }

    private void Update()
    {
        
    }
}

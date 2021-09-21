using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCameraController : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Vector3 offset;
    private void OnEnable()
    {
        ResetMap();
    }
    public void ResetMap()
    {
        transform.position = player.transform.position + offset;
    }

    public void GoUp()
    {
        transform.position += Vector3.up;
    }

    public void GoDown()
    {
        transform.position += Vector3.down;
    }
}

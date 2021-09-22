using Assets.Scripts.Grid;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MapCameraController : MonoBehaviour
{
    [SerializeField] private float defaultZoom = 10f;
    [SerializeField] private GridController grid;
    [SerializeField] private Player player;
    [SerializeField] private Vector3 offset;
    [SerializeField] private Camera mapCamera;
    private void OnEnable()
    {
        grid = FindObjectOfType<GridController>();
        mapCamera = GetComponent<Camera>();
        ResetMap();
    }
    public void ResetMap()
    {
        transform.position = player.transform.position + offset;
        mapCamera.orthographicSize = defaultZoom;
    }

    public void GoUpLevel()
    {
        transform.position += Vector3.up;
    }

    public void GoDownLevel()
    {
        transform.position += Vector3.down;
    }

    public void GoLeft()
    {
        transform.position += Vector3.left;
    }
    public void GoRight()
    {
        transform.position += Vector3.right;
    }
    public void GoUp()
    {
        transform.position += Vector3.forward;
    }
    public void GoDown()
    {
        transform.position += Vector3.back;
    }

    public void ZoomIn()
    {
        mapCamera.orthographicSize--;
    }
    public void ZoomOut()
    {
        mapCamera.orthographicSize++;
    }
}

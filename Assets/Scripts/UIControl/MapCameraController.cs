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
    [SerializeField] private RectTransform mapImage;
    private void OnEnable()
    {
        grid = FindObjectOfType<GridController>();
        mapCamera = GetComponent<Camera>();
        ResetMap();
    }
    public void ResetMap()
    {
        mapImage.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, mapImage.rect.height);
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

    public void MoveMap(Vector3 direction)
    {
        transform.position += direction;
    }

    public void ZoomIn()
    {
        mapCamera.orthographicSize--;
        if(mapCamera.orthographicSize <= 0)
        {
            mapCamera.orthographicSize = 1;
        }
    }
    public void ZoomOut()
    {
        mapCamera.orthographicSize++;
        if(mapCamera.orthographicSize > 25)
        {
            mapCamera.orthographicSize = 25;
        }
    }
}

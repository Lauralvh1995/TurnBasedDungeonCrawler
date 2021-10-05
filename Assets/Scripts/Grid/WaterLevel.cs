using Assets.Scripts.Grid;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WaterLevel : MonoBehaviour
{
    [SerializeField] private int currentLevel;
    [SerializeField] Transform waterLevelVisual;
    [SerializeField] Vector3 lowerBound;
    [SerializeField] Vector3 upperBound;

    [SerializeField] private float waterChangeSpeed = 0.3f;

    public void ChangeLevel(bool state)
    {
        if (state)
        {
            currentLevel++;
            StartCoroutine(ChangeWaterLevel(Vector3.up));
        }
        else
        {
            currentLevel--;
            StartCoroutine(ChangeWaterLevel(Vector3.down));
        }
    }

    IEnumerator ChangeWaterLevel(Vector3 dir)
    {
        Vector3 from = waterLevelVisual.position;
        Vector3 to = waterLevelVisual.position + dir;
        
        for (float t = 0f; t <= 1; t += Time.deltaTime / waterChangeSpeed)
        {
            waterLevelVisual.position = Vector3.Lerp(from, to, t);
            yield return null;
        }
        GridController.Instance.ChangeWaterLevel(currentLevel, lowerBound, upperBound);
    }

    public int GetCurrentLevel()
    {
        return currentLevel;
    }

    public Vector3 GetLowerBound()
    {
        return lowerBound;
    }
    public Vector3 GetUpperBound()
    {
        return upperBound;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        //main corners
        Gizmos.DrawSphere(lowerBound, 0.5f);
        Gizmos.DrawSphere(upperBound, 0.5f);

        //lower corners
        Gizmos.DrawSphere(new Vector3(lowerBound.x, lowerBound.y, upperBound.z), 0.5f);
        Gizmos.DrawSphere(new Vector3(upperBound.x, lowerBound.y, lowerBound.z), 0.5f);
        Gizmos.DrawSphere(new Vector3(upperBound.x, lowerBound.y, upperBound.z), 0.5f);

        //upper corners
        Gizmos.DrawSphere(new Vector3(lowerBound.x, upperBound.y, upperBound.z), 0.5f);
        Gizmos.DrawSphere(new Vector3(upperBound.x, upperBound.y, lowerBound.z), 0.5f);
        Gizmos.DrawSphere(new Vector3(lowerBound.x, upperBound.y, lowerBound.z), 0.5f);
    }
}



using Assets.Scripts.Grid;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GridController))]
public class GridEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        GridController controller = (GridController)target;

        if (GUILayout.Button("Regenerate Grid"))
        {
            controller.Regenerate();
        }
    }
}

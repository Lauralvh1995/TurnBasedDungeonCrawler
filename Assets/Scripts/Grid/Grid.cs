using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Grid
{
    [Serializable]
    public class Grid<TGridObject> where TGridObject : IGridObject
    {
        private int width;
        private int length;
        private int height;
        private Vector3 origin;
        private TGridObject[,,] gridArray;

        public Grid(int width, int length, int height, Vector3 origin)
        {
            this.width = width;
            this.length = length;
            this.height = height;
            this.origin = origin;

            gridArray = new TGridObject[width, length, height];
        }

        public TGridObject[,,] GetGridArray()
        {
            return gridArray;
        }
        public Vector3 GetWorldPosition(int x, int y, int z)
        {
            return new Vector3(x, y, z) + origin;
        }

        public TGridObject GetFromWorldPosition(Vector3 pos)
        {
            Vector3 newPos = pos - origin;
            int x = Mathf.RoundToInt(newPos.x);
            int y = Mathf.RoundToInt(newPos.y);
            int z = Mathf.RoundToInt(newPos.z);

            if (x < width && x >= 0 && y < length && y >= 0 && z < height && z >= 0)
            { 
                return gridArray[x, y, z]; 
            }
            else
            {
                return default;
            }
        }
    }
}

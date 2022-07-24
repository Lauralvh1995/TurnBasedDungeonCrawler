using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Grid
{
    [Serializable]
    public class ObjectGrid<Tile>
    {
        private int width;
        private int length;
        private int height;
        private float cellSize;
        private Vector3 origin;
        private Tile[,,] gridArray;

        public int Width { get => width; set => width = value; }
        public int Length { get => length; set => length = value; }
        public int Height { get => height; set => height = value; }

        public ObjectGrid(int width, int length, int height, Vector3 origin, float cellSize)
        {
            this.width = width;
            this.length = length;
            this.height = height;
            this.origin = origin;
            this.cellSize = cellSize;

            gridArray = new Tile[width, length, height];
        }

        public Tile[,,] GetGridArray()
        {
            return gridArray;
        }
        public Vector3 GetWorldPosition(int x, int y, int z)
        {
            return new Vector3(x, y, z)*cellSize + origin;
        }

        public Tile GetFromWorldPosition(Vector3 pos)
        {
            Vector3 newPos = pos - origin;
            int x = Mathf.RoundToInt(newPos.x/cellSize);
            int y = Mathf.RoundToInt(newPos.y/cellSize);
            int z = Mathf.RoundToInt(newPos.z/cellSize);

            if (x < width && x >= 0 && y < length && y >= 0 && z < height && z >= 0)
            { 
                return gridArray[x, y, z]; 
            }
            else
            {
                return default;
            }
        }

        public int GetWidth()
        {
            return width;
        }
    }
}

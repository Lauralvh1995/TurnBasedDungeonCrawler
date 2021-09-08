using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Grid
{
    public class Tile : IGridObject
    {
        private readonly Grid<Tile> tileGrid;
        private int x, y, z;

        [SerializeField] private bool occupied;

        [SerializeField] private bool leftWall;
        [SerializeField] private bool rightWall;
        [SerializeField] private bool frontWall;
        [SerializeField] private bool backWall;
        [SerializeField] private bool floor;
        [SerializeField] private bool ceiling;

        HashSet<Tile> neighbours;

        void AddNeighbour(Tile t)
        {
            neighbours.Add(t);
        }
        void RemoveNeighbour(Tile t)
        {
            if (neighbours.Contains(t))
                neighbours.Remove(t);
        }
        public HashSet<Tile> GetNeighbours()
        {
            foreach(Tile t in neighbours)
            {
                Debug.Log(t.ToString());
            }
            return neighbours;
        }

        public Tile(Grid<Tile> grid)
        {
            neighbours = new HashSet<Tile>();
            tileGrid = grid;
        }

        public void SetCoords(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public bool LeftWall { get => leftWall; set => leftWall = value; }
        public bool RightWall { get => rightWall; set => rightWall = value; }
        public bool FrontWall { get => frontWall; set => frontWall = value; }
        public bool BackWall { get => backWall; set => backWall = value; }
        public bool Floor { get => floor; set => floor = value; }
        public bool Ceiling { get => ceiling; set => ceiling = value; }
        public bool Occupied { get => occupied; set => occupied = value; }
        public int X
        {
            get => x; set
            {
                x = value;
                //Debug.Log(x);
            }
        }
        public int Y
        {
            get => y; set
            {
                y = value;
                //Debug.Log(y);
            }
        }
        public int Z
        {
            get => z; set
            {
                z = value;
                //Debug.Log(z);
            }
        }

        public void CheckOccupation(Vector3 pos, LayerMask groundMask, LayerMask entityMask)
        {
            if(Physics.OverlapSphere(pos + Vector3.left*0.45f, 0.1f, groundMask).Length > 0)
            {
                leftWall = true;
                RemoveNeighbour(tileGrid.GetFromWorldPosition(pos + Vector3.left));
            }
            else
            {
                AddNeighbour(tileGrid.GetFromWorldPosition(pos + Vector3.left));
            }
            if (Physics.OverlapSphere(pos + Vector3.right * 0.45f, 0.1f, groundMask).Length > 0)
            {
                rightWall = true;
                RemoveNeighbour(tileGrid.GetFromWorldPosition(pos + Vector3.right));
            }
            else
            {
                AddNeighbour(tileGrid.GetFromWorldPosition(pos + Vector3.right));
            }
            if (Physics.OverlapSphere(pos + Vector3.forward * 0.45f, 0.1f, groundMask).Length > 0)
            {
                frontWall = true;
                RemoveNeighbour(tileGrid.GetFromWorldPosition(pos + Vector3.forward));
            }
            else
            {
                AddNeighbour(tileGrid.GetFromWorldPosition(pos + Vector3.forward));
            }
            if (Physics.OverlapSphere(pos + Vector3.back * 0.45f, 0.1f, groundMask).Length > 0)
            {
                backWall = true;
                RemoveNeighbour(tileGrid.GetFromWorldPosition(pos + Vector3.back));
            }
            else
            {
                AddNeighbour(tileGrid.GetFromWorldPosition(pos + Vector3.back));
            }
            if (Physics.OverlapSphere(pos + Vector3.up * 0.45f, 0.1f, groundMask).Length > 0)
            {
                ceiling = true;
                RemoveNeighbour(tileGrid.GetFromWorldPosition(pos + Vector3.up));
            }
            else
            {
                AddNeighbour(tileGrid.GetFromWorldPosition(pos + Vector3.up));
            }
            if (Physics.OverlapSphere(pos + Vector3.down * 0.45f, 0.1f, groundMask).Length > 0)
            {
                floor = true;
                RemoveNeighbour(tileGrid.GetFromWorldPosition(pos + Vector3.down));
            }
            else
            {
                AddNeighbour(tileGrid.GetFromWorldPosition(pos + Vector3.down));
            }

            if (Physics.OverlapSphere(pos, 0.2f, entityMask).Length > 0)
            {
                occupied = true;
            }
            else
            {
                occupied = false;
            }
        }


        public void DrawOccupationGizmos(Vector3 pos)
        {
            if (leftWall)
            {
                Gizmos.color = Color.red;
            }
            else
            {
                Gizmos.color = Color.green;
            }
            Gizmos.DrawWireCube(pos + Vector3.left * .5f + new Vector3(0.05f, 0, 0f), new Vector3(0.1f, 1f, 1f));
            if (rightWall)
            {
                Gizmos.color = Color.red;
            }
            else
            {
                Gizmos.color = Color.green;
            }
            Gizmos.DrawWireCube(pos + Vector3.right * .5f - new Vector3(0.05f, 0, 0f), new Vector3(0.1f, 1f, 1f));
            if (backWall)
            {
                Gizmos.color = Color.red;
            }
            else
            {
                Gizmos.color = Color.green;
            }
            Gizmos.DrawWireCube(pos + Vector3.back * .5f + new Vector3(0, 0, 0.05f), new Vector3(1f, 1f, .1f));
            if (frontWall)
            {
                Gizmos.color = Color.red;
            }
            else
            {
                Gizmos.color = Color.green;
            }
            Gizmos.DrawWireCube(pos + Vector3.forward * .5f - new Vector3(0, 0, 0.05f), new Vector3(1f, 1f, .1f));
            if (floor)
            {
                Gizmos.color = Color.green;
            }
            else
            {
                Gizmos.color = Color.red;
            }
            Gizmos.DrawWireCube(pos + (Vector3.down * .5f) + new Vector3(0, 0.05f, 0), new Vector3(1f, .1f, 1f));
            if (ceiling)
            {
                Gizmos.color = Color.red;
            }
            else
            {
                Gizmos.color = Color.green;
            }
            Gizmos.DrawWireCube(pos + (Vector3.up * .5f) - new Vector3(0, 0.05f, 0) , new Vector3(1f, .1f, 1f));

            if (occupied)
            {
                Gizmos.color = Color.magenta;
            }
            else
            {
                Gizmos.color = Color.cyan;
            }
            Gizmos.DrawWireCube(pos, new Vector3(0.3f, 0.3f, 0.3f));

            
        }
        public override string ToString()
        {
            return "Tile: {" + x +","+ y + "," + z + "}";
        }
    }
}

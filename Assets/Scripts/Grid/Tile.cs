using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Grid
{
    [Serializable]
    public class Tile
    {
        private readonly ObjectGrid<Tile> tileGrid;
        private int x, y, z;
        private int gcost;
        private int hcost;
        private int fcost;
        private int hazardRating;
        private Tile cameFrom;
        private Vector3 worldPos;

        [SerializeField] private bool occupied;

        [SerializeField] private bool leftWall;
        [SerializeField] private bool rightWall;
        [SerializeField] private bool frontWall;
        [SerializeField] private bool backWall;
        [SerializeField] private bool floor;
        [SerializeField] private bool ceiling;

        HashSet<Tile> neighbours;

        Color passableColor = new Color(0f, 0.5f, 0f, 0.5f);
        Color impassableColor = new Color(0.5f, 0f, 0f, 0.5f);
        Color occupiedColor = new Color(0.5f, 0f, 0.5f, 0.5f);
        Color inoccupiedColor = new Color(0f, 0.5f, 0.5f, 0.5f);


        void AddNeighbour(Tile t)
        {
            if(t != null)
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

        public Tile(ObjectGrid<Tile> grid)
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

        public void SetWorldPosition(Vector3 pos)
        {
            worldPos = pos;
        }

        public Vector3 GetWorldPosition()
        {
            return worldPos;
        }

        public bool LeftWall { get => leftWall; set => leftWall = value; }
        public bool RightWall { get => rightWall; set => rightWall = value; }
        public bool FrontWall { get => frontWall; set => frontWall = value; }
        public bool BackWall { get => backWall; set => backWall = value; }
        public bool Floor { get => floor; set => floor = value; }
        public bool Ceiling { get => ceiling; set => ceiling = value; }
        public bool Occupied { get => occupied; set => occupied = value; }

        public int GCost { get => gcost; set => gcost = value; }
        public int FCost { get => fcost; set => fcost = value; }
        public int HCost { get => hcost; set => hcost = value; }
        public int HazardRating { get => hazardRating; set => hazardRating = value; }
        public Tile CameFrom { get => cameFrom; set => cameFrom = value; }
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
            if(Physics.CheckSphere(pos + Vector3.left*0.45f, 0.2f, groundMask))
            {
                leftWall = true;
                RemoveNeighbour(tileGrid.GetFromWorldPosition(pos + Vector3.left));
            }
            else
            {
                leftWall = false;
                Tile neighbour = tileGrid.GetFromWorldPosition(pos + Vector3.left);
                if(neighbour!= null)
                    AddNeighbour(neighbour);
            }
            if (Physics.CheckSphere(pos + Vector3.right * 0.45f, 0.2f, groundMask))
            {
                rightWall = true;
                RemoveNeighbour(tileGrid.GetFromWorldPosition(pos + Vector3.right));
            }
            else
            {
                rightWall = false;
                Tile neighbour = tileGrid.GetFromWorldPosition(pos + Vector3.right);
                if (neighbour != null)
                    AddNeighbour(neighbour);
            }
            if (Physics.CheckSphere(pos + Vector3.forward * 0.45f, 0.2f, groundMask))
            {
                frontWall = true;
                RemoveNeighbour(tileGrid.GetFromWorldPosition(pos + Vector3.forward));
            }
            else
            {
                frontWall = true;
                Tile neighbour = tileGrid.GetFromWorldPosition(pos + Vector3.forward);
                if (neighbour != null)
                    AddNeighbour(neighbour);
            }
            if (Physics.CheckSphere(pos + Vector3.back * 0.45f, 0.2f, groundMask))
            {
                backWall = true;
                RemoveNeighbour(tileGrid.GetFromWorldPosition(pos + Vector3.back));
            }
            else
            {
                backWall = false;
                Tile neighbour = tileGrid.GetFromWorldPosition(pos + Vector3.back);
                if (neighbour != null)
                    AddNeighbour(neighbour);
            }
            if (Physics.CheckSphere(pos + Vector3.up * 0.45f, 0.2f, groundMask))
            {
                ceiling = true;
                RemoveNeighbour(tileGrid.GetFromWorldPosition(pos + Vector3.up));
            }
            else
            {
                ceiling = false;
                Tile neighbour = tileGrid.GetFromWorldPosition(pos + Vector3.up);
                if (neighbour != null)
                    AddNeighbour(neighbour);
            }
            if (Physics.CheckSphere(pos + Vector3.down * 0.45f, 0.2f, groundMask))
            {
                floor = true;
                RemoveNeighbour(tileGrid.GetFromWorldPosition(pos + Vector3.down));
            }
            else
            {
                floor = false;
                Tile neighbour = tileGrid.GetFromWorldPosition(pos + Vector3.down);
                if (neighbour != null)
                    AddNeighbour(neighbour);
            }

            if (Physics.CheckSphere(pos, 0.3f, entityMask))
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
                Gizmos.color = impassableColor;
            }
            else
            {
                Gizmos.color = passableColor;
            }
            //Gizmos.DrawWireCube(pos + Vector3.left * .5f + new Vector3(0.05f, 0, 0f), new Vector3(0.1f, 1f, 1f));
            if (rightWall)
            {
                Gizmos.color = impassableColor;
            }
            else
            {
                Gizmos.color = passableColor;
            }
            //Gizmos.DrawWireCube(pos + Vector3.right * .5f - new Vector3(0.05f, 0, 0f), new Vector3(0.1f, 1f, 1f));
            if (backWall)
            {
                Gizmos.color = impassableColor;
            }
            else
            {
                Gizmos.color = passableColor;
            }
            //Gizmos.DrawWireCube(pos + Vector3.back * .5f + new Vector3(0, 0, 0.05f), new Vector3(1f, 1f, .1f));
            if (frontWall)
            {
                Gizmos.color = impassableColor;
            }
            else
            {
                Gizmos.color = passableColor;
            }
            //Gizmos.DrawWireCube(pos + Vector3.forward * .5f - new Vector3(0, 0, 0.05f), new Vector3(1f, 1f, .1f));
            if (floor)
            {
                Gizmos.color = passableColor;
            }
            else
            {
                Gizmos.color = impassableColor;
            }
            Gizmos.DrawWireCube(pos + (Vector3.down * .45f) + new Vector3(0, 0.05f, 0), new Vector3(1f, .1f, 1f));
            if (ceiling)
            {
                Gizmos.color = impassableColor;
            }
            else
            {
                Gizmos.color = passableColor;
            }
            //Gizmos.DrawWireCube(pos + (Vector3.up * .5f) - new Vector3(0, 0.05f, 0) , new Vector3(1f, .1f, 1f));

            if (occupied)
            {
                Gizmos.color = occupiedColor;
            }
            else
            {
                Gizmos.color = inoccupiedColor;
            }
            Gizmos.DrawCube(pos, new Vector3(0.3f, 0.3f, 0.3f));

            
        }
        public override string ToString()
        {
            return "Tile: {" + X +","+ Y + "," + Z + "}";
        }
    }
}

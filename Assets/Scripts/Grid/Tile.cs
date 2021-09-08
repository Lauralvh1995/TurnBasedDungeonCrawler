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
        [SerializeField] private bool occupied;

        [SerializeField] private bool leftWall;
        [SerializeField] private bool rightWall;
        [SerializeField] private bool frontWall;
        [SerializeField] private bool backWall;
        [SerializeField] private bool floor;
        [SerializeField] private bool ceiling;

        public Tile()
        {

        }

        public Tile(bool leftWall, bool rightWall, bool frontWall, bool backWall, bool floor, bool ceiling)
        {
            this.leftWall = leftWall;
            this.rightWall = rightWall;
            this.frontWall = frontWall;
            this.backWall = backWall;
            this.floor = floor;
            this.ceiling = ceiling;
        }

        public bool LeftWall { get => leftWall; set => leftWall = value; }
        public bool RightWall { get => rightWall; set => rightWall = value; }
        public bool FrontWall { get => frontWall; set => frontWall = value; }
        public bool BackWall { get => backWall; set => backWall = value; }
        public bool Floor { get => floor; set => floor = value; }
        public bool Ceiling { get => ceiling; set => ceiling = value; }
        public bool Occupied { get => occupied; set => occupied = value; }

        public void CheckOccupation(Vector3 pos, LayerMask groundMask, LayerMask entityMask)
        {
            if(Physics.OverlapSphere(pos + Vector3.left*0.45f, 0.1f, groundMask).Length > 0)
            {
                leftWall = true;
            }
            if (Physics.OverlapSphere(pos + Vector3.right * 0.45f, 0.1f, groundMask).Length > 0)
            {
                rightWall = true;
            }
            if (Physics.OverlapSphere(pos + Vector3.forward * 0.45f, 0.1f, groundMask).Length > 0)
            {
                frontWall = true;
            }
            if (Physics.OverlapSphere(pos + Vector3.back * 0.45f, 0.1f, groundMask).Length > 0)
            {
                backWall = true;
            }
            if (Physics.OverlapSphere(pos + Vector3.up * 0.45f, 0.1f, groundMask).Length > 0)
            {
                ceiling = true;
            }
            if (Physics.OverlapSphere(pos + Vector3.down * 0.45f, 0.1f, groundMask).Length > 0)
            {
                floor = true;
            }

            if (Physics.OverlapSphere(pos, 0.3f, entityMask).Length > 0)
            {
                occupied = true;
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
            return "front blocked: " + frontWall 
                + ", back blocked: " + backWall 
                + ", left blocked: " + leftWall 
                + ", right blocked: " + rightWall 
                + ", has floor: " + floor 
                + ", has ceiling: " + ceiling;
        }
    }
}

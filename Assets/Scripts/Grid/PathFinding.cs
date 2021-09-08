using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Grid
{
    public class PathFinding
    {


        Grid<NavigationTile> navigationGrid;

        public PathFinding(int width, int length, int height)
        {
            navigationGrid = new Grid<NavigationTile>(width * 3, height * 3, length * 3, -Vector3.one * (1f / 3f), 1f / 3f);
        }
    }
}

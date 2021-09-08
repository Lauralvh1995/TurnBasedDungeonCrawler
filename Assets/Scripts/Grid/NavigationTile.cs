using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Grid
{
    public class NavigationTile : IGridObject
    {
        Grid<NavigationTile> grid;
        int x, y, z;

        private bool passable;
        private bool air;

        int gCost;
        int fCost;
        int hCost;

        NavigationTile previousTile;
        public NavigationTile(Grid<NavigationTile> grid, int x, int y, int z)
        {
            this.grid = grid;
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public override string ToString()
        {
            return "Node: {" + x + "," + y + "," + z + "}";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace YazılımSınama_ODEV1.Entities
{
    public class PathNode
    {
        public int X { get; set; }
        public int Y { get; set; }

        public int GCost { get; set; }
        public int HCost { get; set; }
        public int FCost { get; set; }
        public bool IsBlock { get; set; }

        public PathNode CameFrom { get; set; } 


        public PathNode( int x, int y)
        {
            this.IsBlock = false;
            this.X = x;
            this.Y = y;
        }

        public void CalculateFCost()
        {
            FCost = GCost + HCost;
        }
    }
}

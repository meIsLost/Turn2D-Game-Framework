using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turn2D_Game_Framework
{
    public class Position
    {
        public int x { get; set; }
        public int y { get; set; }


        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;

        }

        public double DistanceTo(Creature creature)
        {
            int dx = x - creature.position.x;
            int dy = y - creature.position.y;
            return Math.Sqrt(dx * dx + dy * dy);
        }
    }
}

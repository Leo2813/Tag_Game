using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tag_Game
{
    class LogicGame
    {
        int size;
        Map map;
        Coord space;
        public int moves { get; private set; }
        public LogicGame(int size)
        {
            this.size = size;
            map = new Map(size);
        }
        public void Start(int seed = 0)
        {
            int digit = 0;
            foreach (Coord xy in new Coord().YeildCoord(size))
                map.Set(xy, ++digit);
            space = new Coord(size);
            if (seed > 0)
                Mix(seed);
            moves = 0;
        }
        void Mix(int seed)
        {
            Random random = new Random(seed);
            for (int j = 0; j < seed; j++)
                PressAt(random.Next(size), random.Next(size));
        }
        public int PressAt(int x, int y)
        {
            return PressAt(new Coord(x, y));
        }
        int PressAt(Coord xy)
        {
            if (space.Equals(xy))
                return 0;
            if (xy.x != space.x && xy.y != space.y)
                return 0;
            int steps = Math.Abs(xy.x - space.x) + Math.Abs(xy.y - space.y);
            while (xy.x != space.x)
                Swap(Math.Sign(xy.x - space.x), 0);
            while (xy.y != space.y)
                Swap(0, Math.Sign(xy.y - space.y));
            moves += steps;
            return steps;
        }
        void Swap(int sx, int sy)
        {
            Coord next = space.Add(sx, sy);
            map.Copy(next, space);
            space = next;
        }
        public int GetDigetAt(int x, int y)
        {
            return GetDigetAt(new Coord(x, y));
        }
        int GetDigetAt(Coord xy)
        {
            if (space.Equals(xy))
                return 0;
            return map.Get(xy);
        }
        public bool CheckWin()
        {
            if (!space.Equals(new Coord(size)))
                return false;
            int digits = 0;
            foreach (Coord xy in new Coord().YeildCoord(size))
                if (map.Get(xy) != ++digits)
                    return space.Equals(xy);
            return true;
        }
    }
}

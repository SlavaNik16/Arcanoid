using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcanoid
{
    internal class Ball
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int speedX { get; set; }
        public int speedY { get; set; }
        public int delta { get; set; }
    }
}

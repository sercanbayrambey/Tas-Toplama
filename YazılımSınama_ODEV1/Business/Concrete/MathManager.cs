using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace YazılımSınama_ODEV1.Business.Concrete
{
    public static class MathManager
    {
        public static int FindDistanceBetweenTwoPoint(Point point1, Point point2)
        {
            var result = (int)Math.Sqrt((Math.Pow((point2.X - point1.X), 2) + (Math.Pow((point2.Y - point1.Y), 2))));
            return result ;
        }
    }
}

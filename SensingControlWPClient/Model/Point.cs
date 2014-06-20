using System;

namespace SensingControlWPClient.Model
{
    public class Point
    {
        public DateTime X { get; set; }
        public double Y { get; set; }

        public Point(DateTime x, double y){
            X = x;
            Y = y;
        }
    }
}

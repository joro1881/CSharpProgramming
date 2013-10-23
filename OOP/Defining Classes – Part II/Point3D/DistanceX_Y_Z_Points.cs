//Write a static class with a static method 
//to calculate the distance between two points in the 3D space.


using System;

    public static class DistanceX_Y_Z_Points
    {
        //static method 
        public static double CalculateDistance(Point3D first, Point3D second)
        {
            double distance = 0.0;
            distance = Math.Sqrt(Math.Pow(first.PointX - second.PointX, 2) + Math.Pow(first.PointY - second.PointY, 2));
            return distance;
        }
    }


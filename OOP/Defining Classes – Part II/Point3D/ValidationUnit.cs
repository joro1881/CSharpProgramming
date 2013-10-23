using System;
using System.Collections.Generic;
 
    public class ValidationUnit
    {
        public static void Main()
        {
            //testing point3D class
            Point3D point = new Point3D(1,1,2);
            Point3D pointSecond = new Point3D(5,6,3);
            Console.WriteLine(point);
            Console.WriteLine(Point3D.startCoordinate);
            double result = DistanceX_Y_Z_Points.CalculateDistance(point, Point3D.startCoordinate);
            Console.WriteLine("\nDistance between point one and the center of the coordinate system:\n{0}", result);

            //testing Path class
            Path road = new Path();
            road.InsertPoint(point);
            road.InsertPoint(pointSecond);

            //path storage class
            PathStorage.Save(road);
            List<Path> repository = new List<Path>();
            repository = PathStorage.Load();
            Console.WriteLine("\nPath saved in Storage:\n");
            foreach (var path in repository)
            {
                foreach (var item in path.sequenceOfPoints)
                {
                    Console.WriteLine(item);
                }
            }
        }
    } 

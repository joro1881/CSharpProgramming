//Create a class Path to hold a sequence
//of points in the 3D space. 


using System; 
using System.Collections.Generic;
 
     public class Path
    {
         //field
         public readonly List<Point3D> sequenceOfPoints = new List<Point3D>();

         //methods
         public void InsertPoint(Point3D point)
         {
             this.sequenceOfPoints.Add(point);
         }

         public void RemoveAllPoints()
         {
             this.sequenceOfPoints.Clear();
         }
    } 

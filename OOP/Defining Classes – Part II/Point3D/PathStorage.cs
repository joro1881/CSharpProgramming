//Create a static class PathStorage with static 
//methods to save and load paths from
//a text file. Use a file format of your choice.
using System;
using System.Collections.Generic;
using System.IO;

public static class PathStorage
{
    //methods
    public static void Save(Path storage)
    {
        StreamWriter writer = new StreamWriter(@"../../PathArhive.txt");
        using(writer)
        {
            foreach (var item in storage.sequenceOfPoints)
            {
                writer.WriteLine(item);
                writer.WriteLine("-");
	        }
        }
    }

    public static List<Path> Load()
    {
        Path loadPath = new Path();
        List<Path> pathLoaded = new List<Path>();
        StreamReader read = new StreamReader(@"../../PathArhive.txt");
        using (read)
        {
            string line = read.ReadLine();
            while (line != null)
            {
                if (line != "-")
                {
                    Point3D point = new Point3D();
                    string exact = line.Replace("Points X:Y:Z:  ", string.Empty).Trim();
                    string[] points = exact.Split(',');
                    point.PointX = int.Parse(points[0]);
                    point.PointY = int.Parse(points[1]);
                    point.PointZ = int.Parse(points[2]);
                    loadPath.InsertPoint(point);
                }
                else
                {
                    pathLoaded.Add(loadPath);
                    loadPath = new Path();
                }
                line = read.ReadLine();
            }
        }
        return pathLoaded;
    }
}
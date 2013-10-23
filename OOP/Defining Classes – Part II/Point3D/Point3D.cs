//Create a structure Point3D to hold
//a 3D-coordinate {X, Y, Z} in the 
//Euclidian 3D space. Implement the 
//ToString() to enable printing a 3D point.

//Add a private static read-only field
//to hold the start of the coordinate 
//system – the point O{0, 0, 0}. 
//Add a static property to return the point O.

using System;

public struct Point3D
{
    //static field :D :) 
    public static readonly Point3D startCoordinate = new Point3D(0,0,0); 

    //constructor
    public Point3D(int pX, int pY, int pZ)
        : this()
    {
        this.PointX = pX;
        this.PointY = pY;
        this.PointZ = pZ;
    }

    //properties
    public int PointX { get; set; }
    public int PointY { get; set; }
    public int PointZ { get; set; }

    //method
    public override string ToString()
    {
        return string.Format("Points X:Y:Z:  {0},{1},{2}", this.PointX, this.PointY, this.PointZ);
    }


}


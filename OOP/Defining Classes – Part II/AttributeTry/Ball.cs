using System;


[VersionAttribute(1.2)]

public class Ball
{
    public Ball(int size, int weight)
    {
        this.Size = size;
        this.Weight = weight;
    }

    public int Size { get; set; }
    public int Weight { get; set; }
}

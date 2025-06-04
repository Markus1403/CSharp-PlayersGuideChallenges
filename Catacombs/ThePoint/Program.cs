
Console.Title = "The Point";
Console.Clear();

Point a = new Point(2, 3);
Point b = new Point(-4, 0);
Console.WriteLine($"({a.X}, {a.Y})");
Console.WriteLine($"({b.X}, {b.Y})");


public class Point
{
    public float X {get;}
    public float Y {get;} 

    public Point(float x, float y)
    {
        X = x;
        Y = y;

    }

    public Point() : this(0, 0) {}
}

// Are your X and Y properties immutable?
// yes, since there are no way to change them. 
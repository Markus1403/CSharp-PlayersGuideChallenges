Console.Title = "The Color";
Console.Clear();

// ---- Main ----
Color chosenColor = new Color(50, 10, 200);
Color thisColor = Color.Yellow;
Console.WriteLine($"R = {chosenColor.R} G = {chosenColor.G} B = {chosenColor.B}");
Console.WriteLine($"R = {thisColor.R} G = {thisColor.G} B = {thisColor.B}");

// ---- Classes ----
public class Color
{
    public int R {get;}
    public int G {get;}
    public int B {get;}

    public Color(int r, int g, int b)
    {
        R = r;
        G = g;
        B = b;
    }

    public static Color White {get;} = new Color(255, 255, 255);
    public static Color Black {get;} = new Color(0, 0, 0);
    public static Color Red {get;} = new Color(255, 0, 0);
    public static Color Orange {get;} = new Color(255, 165, 0);
    public static Color Yellow {get;} = new Color(255, 255, 0);
    public static Color Green {get;} = new Color(0, 128, 0);
    public static Color Blue {get;} = new Color(0, 0, 255);
    public static Color Purple {get;} = new Color(128, 0, 128);

}
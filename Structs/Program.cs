Coordinates a = new Coordinates(3,3);
Coordinates b = new Coordinates(2,3);
Coordinates c = new Coordinates(5,5);
Console.WriteLine(Coordinates.AreAdjecent(a,b));
Console.WriteLine(Coordinates.AreAdjecent(b,c));
Console.WriteLine(Coordinates.AreAdjecent(a,c));



public struct Coordinates {
    private readonly int Row;
    private readonly int Column;

    public Coordinates(int row, int col) {
        Row = row;
        Column = col;
    }

    public static bool AreAdjecent(Coordinates other, Coordinates current) {
        int rowDiff = Math.Abs(current.Row - other.Row);
        int colDiff = Math.Abs(current.Column - other.Column);
    return (rowDiff == 1 && colDiff == 0) || (rowDiff == 0 && colDiff == 1);
    }
}
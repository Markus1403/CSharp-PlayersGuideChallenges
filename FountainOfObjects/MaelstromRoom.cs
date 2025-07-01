namespace FountainOfObjects;

public class MaelstromRoom : Room {
    public int Row { get; set; } = 0;
    public int Col { get; set; } = 0;
    public override string Description => "You entered a room with a Maelstrom, you are swept into another room";
    public override ConsoleColor Color => ConsoleColor.DarkRed;
}



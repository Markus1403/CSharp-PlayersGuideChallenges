namespace FountainOfObjects;

public class World {
    public Room[,] Grid { get; }
    public FountainRoom FountainRoom {get;}
    public MaelstromRoom MaelstromRoom {get;}

    public World() {
        Grid = new Room[4, 4];

        for (int row = 0; row < 4; row++)
            for (int col = 0; col < 4; col++)
                Grid[row, col] = new EmptyRoom();

        Grid[0, 0] = new StartingRoom();

        FountainRoom = new FountainRoom();
        Grid[3, 3] = FountainRoom;

        Grid[3,1] = new PitRoom();

        MaelstromRoom = new MaelstromRoom();
        MaelstromRoom.Row = 1;
        MaelstromRoom.Col = 2;
        Grid[1,2] = MaelstromRoom;

        Grid[0,3] = new AmarokRoom();
    }

    public Room GetRoomAt(int row, int col) {
        return Grid[row, col];
    } 

    public bool IsRoomTypeAdjacent<T>(int row, int col) where T : Room
    {
        int[,] directions = new int[,] {
            { -1,  0 }, { -1,  1 }, {  0,  1 }, {  1,  1 },
            {  1,  0 }, {  1, -1 }, {  0, -1 }, { -1, -1 }
        };

        for (int i = 0; i < directions.GetLength(0); i++)
        {
            int newRow = row + directions[i, 0];
            int newCol = col + directions[i, 1];

            if (newRow >= 0 && newRow < Grid.GetLength(0) &&
                newCol >= 0 && newCol < Grid.GetLength(1))
            {
                if (Grid[newRow, newCol] is T)
                    return true;
            }
        }
        return false;
    }
}



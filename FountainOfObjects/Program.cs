class Program {
    static void Main(string[] args) {
        Console.Title = "The Fountain of Objects";
        Game game = new Game();
        game.GameRunning();
    }
}


// Game loop
public class Game {
    private World world;
    private Player player;

    public Game(){
        world = new World();
        player = new Player();  
    }

    public void GameRunning () {
        Console.Clear();
        string[] introLines = new[] {
            "You enter the Caverns of Objects, a maze of rooms filled",
            "with dangerous pits, in search of the Fountain of Objects.",
            "",
            "Light is visible only in the entrance; no other light is",
            "seen anywhere in the caverns.",
            "",
            "You must navigate the caverns with your other senses.",
            "",
            "Find the Fountain of Objects, activate it, and return to",
            "the entrance.",
            "",
            "Look out for pits. You feel a breeze if a pit is in an",
            "adjacent room. If you enter a room with a pit, you will die.",
            "",
            "Maelstroms are violent forces of sentient wind. Entering",
            "a room with one could transport you to another location.",
            "You will hear their growling and groaning in nearby rooms.",
            "",
            "Amaroks roam the caverns. Encountering one is certain death,",
            "but you can smell their rotten stench in nearby rooms.",
            "",
            "You carry a bow and a quiver of arrows. Use them to shoot",
            "monsters, but beware: your supply is limited."
        };

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(new string('=', 60));
        foreach (var line in introLines)
            Console.WriteLine(line.PadLeft((60 + line.Length) / 2));
        Console.WriteLine(new string('=', 60));
        Console.ResetColor();
        Console.WriteLine();

        while (!IsGameWon() && !IsGameLost()) {
            Console.WriteLine("---------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"You are in the room at (Row={player.Row}, Col={player.Col})");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Total Arrows: {player.Arrows}");
            Console.ResetColor();

            Room currentRoom = world.GetRoomAt(player.Row, player.Col);
            Console.ForegroundColor = currentRoom.Color;
            Console.WriteLine(currentRoom.Description);
            Console.ResetColor();

            if (world.IsRoomTypeAdjacent<PitRoom>(player.Row, player.Col)) {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("You feel a draft. There is a pit in a nearby room.");
                Console.ResetColor();
            }

            if (world.IsRoomTypeAdjacent<MaelstromRoom>(player.Row, player.Col)) {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("You hear the growling and groaning of a maelstrom nearby");
                Console.ResetColor();
            }

            if (world.IsRoomTypeAdjacent<AmarokRoom>(player.Row, player.Col)) {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("You can smell the rotten stench of an amarok in a nearby room");
                Console.ResetColor();
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("What do you want to do? ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            string? input = Console.ReadLine();
            if (input != null) {
                if (input.Equals("help")) {
                Console.ForegroundColor = ConsoleColor.Green;
                player.Help();
                Console.WriteLine("\nPress Enter to return to the game...");
                Console.ReadLine();
                Console.Clear();
                Console.ResetColor();
                continue; // Skip the rest of the loop and show the room again
                }
                if (input.StartsWith("move")) {
                    player.Move(input, world);
                }
                else if (input.StartsWith("shoot")) {
                    Console.ForegroundColor = ConsoleColor.Red;
                    player.Shoot(input, world);
                    Console.ResetColor();
                }
                else {
                    player.Action(input, world);
                }
                Room roomAfterMove = world.GetRoomAt(player.Row, player.Col);
                    if (roomAfterMove is MaelstromRoom) {
                        Console.ForegroundColor = roomAfterMove.Color;
                        Console.WriteLine(roomAfterMove.Description);
                        Console.ResetColor();

                        // Move player
                        int newRow = ((player.Row - 1) % 4 + 4) % 4;
                        int newCol = ((player.Col + 2) % 4 + 4) % 4;
                        player.SetPosition(newRow, newCol);

                        // Move Maelstrom
                        int oldMaelstromRow = world.MaelstromRoom.Row;
                        int oldMaelstromCol = world.MaelstromRoom.Col;
                        int newMaelstromRow = ((oldMaelstromRow + 1) % 4 + 4) % 4;
                        int newMaelstromCol = ((oldMaelstromCol - 2) % 4 + 4) % 4;

                        world.Grid[oldMaelstromRow, oldMaelstromCol] = new EmptyRoom();
                        world.MaelstromRoom.Row = newMaelstromRow;
                        world.MaelstromRoom.Col = newMaelstromCol;
                        world.Grid[newMaelstromRow, newMaelstromCol] = world.MaelstromRoom;
                }
            }
            Console.ResetColor();
            
            


        }
    }

    public bool IsGameWon() {
        Room currentRoom = world.GetRoomAt(player.Row, player.Col);
            if (currentRoom is StartingRoom  && world.FountainRoom.IsFountainEnabled == true) { 
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("The Fountain of Objects has been reactivated, and you escaped with your life!");
                Console.WriteLine("You Win!"); 
                return true;
            }
        return false;
    }

    public bool IsGameLost() {
        Room currentRoom = world.GetRoomAt(player.Row, player.Col);
        if (currentRoom is PitRoom || currentRoom is AmarokRoom) { 
                Console.ForegroundColor = currentRoom.Color;
                Console.WriteLine(currentRoom.Description);
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("You Lost!"); 
                return true;
            }
        return false;
    }


    
}

// World (grid of rooms)
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


// Player class 
public class Player {
    public int Row { get; private set; } = 0;
    public int Col { get; private set; } = 0;

    public int Arrows {get; private set;} = 5;

    public void SetPosition(int row, int col ) {
        Row = row;
        Col = col;
    }

    public bool Shoot (string direction, World world) {

        int targetRow = Row; 
        int targetCol = Col; 

        if (Arrows <= 0) {
            Console.WriteLine("You are out of arrows!");
            return false;
        }

        switch (direction) {
            case "shoot north":
                targetRow = Row - 1;
                break;
            
            case "shoot south":
                targetRow = Row + 1;
                break;
            
            case "shoot east": 
                targetCol = Col + 1;
                break;

            case "shoot west":
                targetCol = Col - 1;
                break;

            default:
                return false;
        }

        if (targetRow < 0 || targetRow >= world.Grid.GetLength(0) || 
            targetCol < 0 || targetCol >= world.Grid.GetLength(1)) {
                Console.WriteLine("You shoot into a wall. Nothing happens.");
                Arrows--;
            return true;
        }


        if (world.Grid[targetRow, targetCol] is AmarokRoom || world.Grid[targetRow, targetCol] is MaelstromRoom) {
            Console.WriteLine("You hear a monstrous scream! You hit something!");
            world.Grid[targetRow, targetCol] = new EmptyRoom();
        }
        else {
            Console.WriteLine("Nothing happened. The room must be empty");
        }

        Arrows--;
        return true;

    }
    

    public bool Move (string direction, World world) {
        switch (direction) {
            case "move north":
                if (Row > 0) {
                    Row--;
                    return true;
                } else {
                    Console.WriteLine("You can't move in this direction.");
                    return true;
                }

            case "move south":
                if (Row < 3) {
                    Row++;
                    return true;
                } else {
                    Console.WriteLine("You can't move in this direction.");
                    return true;
                }
            
            case "move east": 
                if (Col < 3) {
                    Col++;
                    return true;
                } else {
                    Console.WriteLine("You can't move in this direction.");
                    return true;
                }

            case "move west":
                if (Col > 0) {
                    Col--;
                    return true;
                } else {
                    Console.WriteLine("You can't move in this direction.");
                    return true;
                }
            default:
                return false;
        }
    }

    public void Action (string action, World world) {
        Room currentRoom = world.GetRoomAt(Row, Col);
        switch (action) {
            case "enable fountain":
                if (currentRoom is FountainRoom fountainRoom)
                {
                    if (fountainRoom.IsFountainEnabled)
                        Console.WriteLine("The fountain is already enabled!");
                    else
                        fountainRoom.EnableFountain();
                }
                else
                    Console.WriteLine("There is no fountain in this room.");
                break;

            case "disable fountain":
                if (currentRoom is FountainRoom fountainRoom2)
                {
                    if (!fountainRoom2.IsFountainEnabled)
                        Console.WriteLine("The fountain is already disabled!");
                    else
                        fountainRoom2.DisableFountain();
                }
                else
                    Console.WriteLine("There is no fountain in this room.");
                break;

            default:
                Console.WriteLine("Invalid Action!");
                break;
        }
    }

    public void Help () {
        Console.WriteLine("The following commands are available:");
        Console.WriteLine("1 - Move");
        Console.WriteLine("2 - Action");
        Console.WriteLine("3 - Shoot");
        Console.Write("What command do you want to learn more about? ");


        int commandNumber = Convert.ToInt32(Console.ReadLine());

        string command = commandNumber switch
        {
            1 => "Move",
            2 => "Action",
            3 => "Shoot",
            _ => "Sorry, that is not possible command"
        };

        string commandDescription = commandNumber switch
    {
        1 => 
@"Move:
  - Use to travel between rooms.
  - Syntax: move north | move south | move east | move west
  - Example: move north",
        2 => 
@"Action:
  - Use to activate or deactivate the fountain (in the fountain room).
  - Syntax: enable fountain | disable fountain
  - Example: enable fountain",
        3 => 
@"Shoot:
  - Use to fire an arrow into an adjacent room.
  - Syntax: shoot north | shoot south | shoot east | shoot west
  - Example: shoot east",
        _ => "Please enter 1, 2, or 3 to learn about a command."
    };

    Console.WriteLine();
    Console.WriteLine(commandDescription);

    }
    
}



// Room Types

public abstract class Room {
    public abstract string Description {get;}
    public virtual ConsoleColor Color => ConsoleColor.White;
}

public class EmptyRoom : Room  {
    public override string Description => "This room is empty and there is nothing to see.";
    public override ConsoleColor Color => ConsoleColor.DarkGray;

}
public class StartingRoom  : Room{
    public override string Description => "You see light coming from the cavern entrance.";
    public override ConsoleColor Color => ConsoleColor.Yellow;

}
public class FountainRoom : Room {
    public bool IsFountainEnabled {get; set;} = false;
    
    public override string Description
    {
        get
        {
            if (IsFountainEnabled == false)
                return "You hear water dripping in this room. The Fountain of Objects is here";
            else
                return "You hear water the rushing waters from the Fountain of Objects. It has been reactivated!.";
        }
    }
    public override ConsoleColor Color => ConsoleColor.DarkCyan;


    public void EnableFountain() {
        IsFountainEnabled = true;
    }

    public void DisableFountain() {
        IsFountainEnabled = false;
    }
}

public class PitRoom : Room {
    public override string Description => "You fell down a pit and died.";
    public override ConsoleColor Color => ConsoleColor.DarkRed;
}   

public class MaelstromRoom : Room {
    public int Row { get; set; } = 0;
    public int Col { get; set; } = 0;
    public override string Description => "You entered a room with a Maelstrom, you are swept into another room";
    public override ConsoleColor Color => ConsoleColor.DarkRed;
}

public class AmarokRoom : Room {
    public override string Description => "You entered a room with an Amarok, before you could even react it ripped you apart";
    public override ConsoleColor Color => ConsoleColor.DarkRed;
}



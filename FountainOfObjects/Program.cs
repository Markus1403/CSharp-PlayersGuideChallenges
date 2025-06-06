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
        Console.WriteLine("\n");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("You enter the caverns containing the Fountain of Objects");
        Console.ResetColor();
        while (!IsGameWon()) {
            Console.WriteLine("---------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"You are in the room at (Row={player.Row}, Col={player.Col})");
            Console.ResetColor();

            Room currentRoom = world.GetRoomAt(player.Row, player.Col);
            Console.ForegroundColor = currentRoom.Color;
            Console.WriteLine(currentRoom.Description);
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("What do you want to do? ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            string? input = Console.ReadLine();
            if (input != null) {
                if (!player.Move(input, world)) {
                    player.Action(input, world);
                }
            }
            Console.ResetColor();
        }
    }

    public bool IsGameWon() {
        // If Room is starting room and Fountain is enabled, return true
        Room currentRoom = world.GetRoomAt(player.Row, player.Col);
            if (currentRoom is StartingRoom  && world.FountainRoom.IsFountainEnabled == true) { 
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("The Fountain of Objects has been reactivated, and you escaped with your life!");
                Console.WriteLine("You Win!"); 
                return true;
            }
        return false;
    }
    
}

// World (grid of rooms)
public class World {
    public Room[,] Grid { get; }
    public FountainRoom FountainRoom {get;}

    public World() {
        Grid = new Room[4, 4];

        for (int row = 0; row < 4; row++)
            for (int col = 0; col < 4; col++)
                Grid[row, col] = new EmptyRoom();

        Grid[0, 0] = new StartingRoom();

        FountainRoom = new FountainRoom();
        Grid[0, 2] = FountainRoom;
    }
    public Room GetRoomAt(int row, int col) {
        return Grid[row, col];
    } 
}


// Player class 
public class Player {
    public int Row { get; private set; } = 0;
    public int Col { get; private set; } = 0;

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
    public bool IsFountainEnabled {get; set;} = false ;
    
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




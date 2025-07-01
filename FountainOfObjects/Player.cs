namespace FountainOfObjects;

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



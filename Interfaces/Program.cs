﻿
Robot robot = new Robot();
Console.Clear();

while (true)
{   
    Console.WriteLine("Give The Robot a Command:");
    string? input = Console.ReadLine();

    if (input == "stop") {
        break;
    }
    IRobotCommand newCommand = input switch
    {
        "on" => new OnCommand(),
        "off" => new OffCommand(),
        "north" => new NorthCommand(),
        "south" => new SouthCommand(),
        "east" => new EastCommand(),
        "west" => new WestCommand(),
    };
    robot.Commands.Add(newCommand);
}

Console.WriteLine();

robot.Run();

public interface IRobotCommand {
    public void Run(Robot robot);
}


public class Robot {
    public int X {get; set;}
    public int Y {get; set;}
    public bool IsPowered {get; set;}
    public List<IRobotCommand> Commands {get;} = new List<IRobotCommand>();
    public void Run() {
        foreach (IRobotCommand? command in Commands) {
            command?.Run(this);
            Console.WriteLine($"[{X} {Y} {IsPowered}]");
        }
    }
}

public class OnCommand : IRobotCommand {
    public void Run(Robot robot) {
        robot.IsPowered = true;
    }
}

public class OffCommand : IRobotCommand {
    public void Run(Robot robot) {
        robot.IsPowered = false;
    }
}

public class NorthCommand :IRobotCommand {
    public void Run(Robot robot) {
        if (robot.IsPowered == true) {
            robot.Y += 1;
        }
    }
}

public class SouthCommand :IRobotCommand {
    public void Run(Robot robot) {
        if (robot.IsPowered == true) {
            robot.Y -= 1;
        }
    }
}

public class WestCommand :IRobotCommand {
    public void Run(Robot robot) {
        if (robot.IsPowered == true) {
            robot.X -= 1;
        }
    }
}

public class EastCommand :IRobotCommand {
    public void Run(Robot robot) {
        if (robot.IsPowered == true) {
            robot.X += 1;
        }
    }
}



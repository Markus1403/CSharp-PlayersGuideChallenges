/*
Pack pack = new Pack(10, 10.0f, 10.0f);
Console.Clear();
while (true) {
    Console.Write("Pack contains: ");
    Console.WriteLine($"{pack}");
    Console.WriteLine($"Pack is currently at {pack.Size}/{pack.Size} items, {pack.CurrentWeight}/{pack.MaxWeight} weight, and {pack.CurrentVolume}/{pack.MaxVolume} volume.");
    Console.WriteLine("What would you like to add to you inventory");
    Console.WriteLine("1 - Arrow");
    Console.WriteLine("2 - Bow");
    Console.WriteLine("3 - Rope");
    Console.WriteLine("4 - Water");
    Console.WriteLine("5 - Food");
    Console.WriteLine("6 - Sword");
    int choice = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("\n");

    InventoryItem newItem = choice switch
    {
        1 => new Arrow(),
        2 => new Bow(),
        3 => new Rope(),
        4 => new Water(),
        5 => new FoodRations(),
        6 => new Sword()
    };
    if (!pack.Add(newItem))
        Console.WriteLine("Could not add this to the pack.");

}



public class InventoryItem {
    public float Weight { get; set; }
    public float Volume { get; set; }

    public InventoryItem(float weight, float volume) {
        Weight = weight;
        Volume = volume;
    }
}


public class Arrow : InventoryItem {
    public Arrow() : base(0.01f, 0.05f) { }

    public override string ToString() => "Arrow";
}


public class Bow : InventoryItem {
    public Bow() : base(1.0f, 4.0f) { }
    public override string ToString() => "Bow";
}


public class Rope : InventoryItem {
    public Rope() : base(1.0f, 1.5f) { }
    public override string ToString() => "Rope";
}

public class Water : InventoryItem {
    public Water() : base(2.0f, 3.0f) { }
    public override string ToString() => "Water";
}

public class FoodRations : InventoryItem {
    public FoodRations() : base(1.0f, 0.5f) { }
    public override string ToString() => "FoodRations";
}

public class Sword : InventoryItem {
    public Sword() : base(5.0f, 3.0f) { }
    public override string ToString() => "Sword";
}



public class Pack {
    public float MaxWeight {get; set;}
    public float MaxVolume {get; set;}
    public int Size; 



    private InventoryItem[] items;

    public Pack(int size, float maxWeight, float maxVolume) {
        MaxWeight = maxWeight;
        MaxVolume = maxVolume;
        Size = size;

        items = new InventoryItem[size];
    }

    public float CurrentWeight {get; set;}
    public float CurrentVolume {get; set;}
    public bool Add(InventoryItem item) {
        for (int i = 0; i < items.Length; i++) {
            if (items[i] == null) {
                if (CurrentWeight + item.Weight <= MaxWeight && CurrentVolume + item.Volume <= MaxVolume) {
                    items[i] = item;
                    CurrentWeight += item.Weight;
                    CurrentVolume += item.Volume;

                    return true;
                }
                return false;
            }
        }
        return false;
    }

    public override string ToString() {
            string result = "";
            foreach (var item in items) {
                if (item != null) {
                    result += $"{item.GetType().Name}, ";
                }
            }
            return result;
    }
}

*/ 

Robot robot = new Robot();
Console.Clear();

for (int index = 0; index < robot.Commands.Length; index++)
{   
    Console.WriteLine("Give The Robot a Command:");
    string? input = Console.ReadLine();
    RobotCommand newCommand = input switch
    {
        "on" => new OnCommand(),
        "off" => new OffCommand(),
        "north" => new NorthCommand(),
        "south" => new SouthCommand(),
        "east" => new EastCommand(),
        "west" => new WestCommand(),
    };
    robot.Commands[index] = newCommand;
}

Console.WriteLine();

robot.Run();
public abstract class RobotCommand {
    public abstract void Run(Robot robot);
}


public class Robot {
    public int X {get; set;}
    public int Y {get; set;}
    public bool IsPowered {get; set;}
    public RobotCommand?[] Commands {get;} = new RobotCommand[3];
    public void Run() {
        foreach (RobotCommand? command in Commands) {
            command?.Run(this);
            Console.WriteLine($"[{X} {Y} {IsPowered}]");
        }
    }
}

public class OnCommand : RobotCommand {
    public override void Run(Robot robot) {
        robot.IsPowered = true;
    }
}

public class OffCommand : RobotCommand {
    public override void Run(Robot robot) {
        robot.IsPowered = false;
    }
}

public class NorthCommand : RobotCommand {
    public override void Run(Robot robot) {
        if (robot.IsPowered == true) {
            robot.Y += 1;
        }
    }
}

public class SouthCommand : RobotCommand {
    public override void Run(Robot robot) {
        if (robot.IsPowered == true) {
            robot.Y -= 1;
        }
    }
}

public class WestCommand : RobotCommand {
    public override void Run(Robot robot) {
        if (robot.IsPowered == true) {
            robot.X -= 1;
        }
    }
}

public class EastCommand : RobotCommand {
    public override void Run(Robot robot) {
        if (robot.IsPowered == true) {
            robot.X += 1;
        }
    }
}



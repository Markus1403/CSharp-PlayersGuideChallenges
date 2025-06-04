Console.Title = "Vin Fletcher's Arrows";
Console.Clear();


// Arrow creation options
Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine("Arrow creation options:");

Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine("Type of Arrowhead:");
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("Steel, Wood, Obsidian");

Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine("\nType of of Fletching:");
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("Plastic, Turkey Feathers, Goose Feathers");

Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine("\nLength of the arrows shaft:");
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("Pick a length between 60 and 100 cm");

Console.ForegroundColor = ConsoleColor.Cyan;
Console.Write("\nPlease choose arrowhead type: ");
string headInput = Console.ReadLine();

Console.Write("Please choose the arrows fletching: " );
string fletchingInput = Console.ReadLine();

Console.Write("Please choose the length of the shaft: ");
float lengthInput = Convert.ToSingle(Console.ReadLine());


// Use switch to map string input to enum values
ArrowHead selectedArrowHead = headInput switch
{
    "Steel" => ArrowHead.Steel,
    "Wood" => ArrowHead.Wood,
    "Obsidian" => ArrowHead.Obsidian,
    _ => throw new ArgumentException("Invalid arrowhead type entered")
};

Fletching selectedFletching = fletchingInput switch
{
    "Plastic" => Fletching.Plastic,
    "Turkey Feathers" => Fletching.TurkeyFeathers,
    "Goose Feathers" => Fletching.GooseFeathers,
    _ => throw new ArgumentException("Invalid fletching entered")
};

// Create a tuple using enumerations   
Arrow newArrow = new Arrow(selectedArrowHead, selectedFletching, lengthInput);

Console.WriteLine($"The cost of the arrow is: {newArrow.GetCost()} gold coins");

class Arrow
{
    public ArrowHead _arrowhead;
    public Fletching _fletching;
    public float _length;

    // Constructor for Arrow
    public Arrow(ArrowHead arrowhead, Fletching fletching, float length)
    {
        if (length < 60 || length > 100) throw new ArgumentException("Invalid length entered");
        _arrowhead = arrowhead;
        _fletching = fletching;
        _length = length;   
    }
    // 
    public float GetCost()
    {
        float arrowheadCost = _arrowhead switch
        {
            ArrowHead.Steel => 10,
            ArrowHead.Wood => 3,
            ArrowHead.Obsidian => 5,
        };
    
        float fletchingCost = _fletching switch
        {
            Fletching.Plastic => 10,
            Fletching.TurkeyFeathers => 5,
            Fletching.GooseFeathers => 3,
        };

        float shaftCost = _length * 0.05f;

        return arrowheadCost + fletchingCost + shaftCost;

    }


}

// -------- Enumerations --------
    public enum ArrowHead {Steel, Wood, Obsidian}
    public enum Fletching {Plastic, TurkeyFeathers, GooseFeathers}

// End of my program


// ------------------ RB's Version ------------------

/* 
Arrow arrow = GetArrow();
Console.WriteLine($"That arrow costs {arrow.GetCost()} gold.");


Arrow GetArrow()
{
    Arrowhead arrowhead = GetArrowheadType();
    Fletching fletching = GetFletchingType();
    float length = GetLength();

    return new Arrow(arrowhead, fletching, length);
}

Arrowhead GetArrowheadType()
{
    Console.Write("Arrowhead type (steel, wood, obsidian): ");
    string input = Console.ReadLine();
    return input switch
    {
        "steel" => Arrowhead.Steel,
        "wood" => Arrowhead.Wood,
        "obsidian" => Arrowhead.Obsidian
    };
}

Fletching GetFletchingType()
{
    Console.Write("Fletching type (plastic, turkey feather, goose feather): ");
    string input = Console.ReadLine();
    return input switch
    {
        "plastic" => Fletching.Plastic,
        "turkey feather" => Fletching.TurkeyFeathers,
        "goose feather" => Fletching.GooseFeathers
    };
}

float GetLength()
{
    float length = 0;

    while(length < 60 || length > 100)
    {
        Console.Write("Arrow length (between 60 and 100): ");
        length = Convert.ToSingle(Console.ReadLine());
    }

    return length;
}

class Arrow
{
    public Arrowhead _arrowhead;
    public Fletching _fletching;
    public float _length;

    public Arrow(Arrowhead arrowhead, Fletching fletching, float length)
    {
        _arrowhead = arrowhead;
        _fletching = fletching;
        _length = length;
    }

    public float GetCost()
    {
        float arrowheadCost = _arrowhead switch
        {
            Arrowhead.Steel => 10,
            Arrowhead.Wood => 3,
            Arrowhead.Obsidian => 5
        };

        float fletchingCost = _fletching switch
        {
            Fletching.Plastic => 10,
            Fletching.TurkeyFeathers => 5,
            Fletching.GooseFeathers => 3
        };

        float shaftCost = 0.05f * _length;

        return arrowheadCost + fletchingCost + shaftCost;
    }
}

enum Arrowhead { Steel, Wood, Obsidian }
enum Fletching { Plastic, TurkeyFeathers, GooseFeathers }


*/ 
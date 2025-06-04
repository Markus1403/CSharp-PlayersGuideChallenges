Console.Title = "Simula's Soup";
Console.Clear();

// Menu 
Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine("Menu:");

Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine("Type of Soup:");
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("Soup, Stew, Gumbo");

Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine("\nMain Ingredient:");
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("Mushrooms, Chicken, Carrots, Potatoes");

Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine("\nSeasoning:");
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("Spicy, Salty, Sweet");

Console.ForegroundColor = ConsoleColor.Cyan;
Console.Write("\nPlease enter the type of soup (Soup, Stew, Gumbo): ");
string soupInput = Console.ReadLine();

Console.Write("Please enter the main ingredient (Mushrooms, Chicken, Carrots, Potatoes): ");
string ingredientInput = Console.ReadLine();

Console.Write("Please enter the seasoning (Spicy, Salty, Sweet): ");
string seasoningInput = Console.ReadLine();

// Use switch to map string input to enum values
TypeOfSoup selectedSoup = soupInput switch
{
    "Soup" => TypeOfSoup.Soup,
    "Stew" => TypeOfSoup.Stew,
    "Gumbo" => TypeOfSoup.Gumbo,
    _ => throw new ArgumentException("Invalid soup type entered")
};

MainIngredient selectedIngredient = ingredientInput switch
{
    "Mushroom" => MainIngredient.Mushroom,
    "Chicken" => MainIngredient.Chicken,
    "Carrots" => MainIngredient.Carrots,
    "Potatoes" => MainIngredient.Potatoes,
    _ => throw new ArgumentException("Invalid ingredient entered")
};

Seasoning selectedSeasoning = seasoningInput switch
{
    "Spicy" => Seasoning.Spicy,
    "Salty" => Seasoning.Salty,
    "Sweet" => Seasoning.Sweet,
    _ => throw new ArgumentException("Invalid seasoning entered")
};

// Create a tuple using enumerations
var soupTuple = (TypeOfSoup: selectedSoup, MainIngredient: selectedIngredient, Seasoning: selectedSeasoning);

// Display the selected soup combination with enumerations
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine($"\nYour soup is: {soupTuple.Seasoning} {soupTuple.MainIngredient} {soupTuple.TypeOfSoup}"); 

// ----- Enumerations ----- 
enum TypeOfSoup { Soup, Stew, Gumbo }
enum MainIngredient { Mushroom, Chicken, Carrots, Potatoes }
enum Seasoning { Spicy, Salty, Sweet }
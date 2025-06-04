
Console.Title = "Hunting the manticore";
Console.Clear();

//Game starting state
int manticoreHealth = 10;
int cityHealth = 15;
int round = 1;

// Player 1 chooses manticore position
Console.ForegroundColor = ConsoleColor.Red;
int manticoreDistance = AskForNumberInRange("Lord Uncoded One, how far away from the city do you want to station the Manticore", 0, 100); 
Console.Clear();

// Game loop
while(manticoreHealth > 0 && cityHealth > 0)
{ 
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("-----------------------------------------------------------");
    ShowStatus(round, cityHealth, manticoreHealth); // Display the Status for the round

    Console.ForegroundColor = ConsoleColor.Yellow;
    int damage = CannonDamage(round); // Display the expected damage from the cannon this round
        Console.WriteLine($"The cannon is expected to deal {damage} damage this round");
    
    Console.ForegroundColor = ConsoleColor.Blue;
    int cannonRange = AskForNumberInRange("Enter the desired cannon range: ", 0, 100); // enter cannon range

    Console.ForegroundColor = ConsoleColor.Magenta;
    OverUnderDirect(manticoreDistance, cannonRange); // Show where cannon round lands

    if (manticoreHealth > 0 ) cityHealth --; // deal 1 damage if manticore is still alive

    if (manticoreDistance == cannonRange) manticoreHealth -= damage; // subtract expected damage from manticore health if direct hit
    
    round ++; // advande to next round
}
// Display Outcome
ShowOutcome(manticoreHealth, cityHealth);

// -------------------------METHODS-------------------------------------

//Method for displaying the status of the round
void ShowStatus(int round, int cityHealth, int manticoreHealth)  
    {
    Console.WriteLine($"STATUS: Round: {round} City: {cityHealth}/15 Manticore: {manticoreHealth}/10");
    }

// Methods for calculation the expected damge from the cannon
int CannonDamage(int roundNumber)
    {
        if (roundNumber % 5 == 0 && roundNumber % 3 == 0) return 10;
        else if (roundNumber % 5 == 0) return 3;
        else if (roundNumber % 3 == 0) return 3;
        else return 1;
    }

//Method for where the cannon round lands
void OverUnderDirect(int manticoreDistance, int cannonRange)
{
    if (manticoreDistance < cannonRange) Console.WriteLine("That round OVERSHOT the target.");
    else if(manticoreDistance > cannonRange) Console.WriteLine("That round FELL SHORT of the target.");
    else Console.WriteLine("That round was a DIRECT HIT");
}

// Method for showing games outcome
void ShowOutcome(int manticoreHealth, int cityHealth)
    {
        Console.Clear();
        if (manticoreHealth <= 0)
        {
            Console.WriteLine("VICTORY! The Manticore has been destroyed, and the city of Consolas has been saved!");
        }
        else if (cityHealth <= 0)
        {
            Console.WriteLine("DEFEAT! The Manticore has destroyed the city, You failed us!");
        }
    }

// Methods for choosing number between 0 and 100
int AskForNumber(string text)
{
    Console.Write(text + " ");
    int number = Convert.ToInt32(Console.ReadLine());
    return number;
}

int AskForNumberInRange(string text, int min, int max)
{
    while (true)
    {
        int number = AskForNumber(text);
        if (number >= min && number <= max)
            return number;
    }

}
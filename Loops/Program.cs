Console.Title = "The Magic Cannon";
/*
//The Prototype
Console.Clear();

while (true)
{
    int pNum;
    
    while (true)
    {
        Console.Write("Pilot, enter a number between 0 and 100: ");
        pNum = Convert.ToInt32(Console.ReadLine());
        if (pNum < 0 || pNum > 100)
        {
            Console.WriteLine("Invalid number. Please guess again.");
            continue;
        }
        break;
    }

    int hNum;

    while(true)
    {
        Console.Write("Hunter, guess the number: ");
        hNum = Convert.ToInt32(Console.ReadLine());
        if (hNum < 0 || hNum > 100)
        {
            Console.WriteLine("Invalid number. Please guess again.");
            continue;
        }
        break;
    }
  
    while (true)
    {
        if (hNum < pNum)
            {
                Console.WriteLine($"{hNum} is too low.");
                Console.Write("What is you next guess? ");
                hNum = Convert.ToInt32(Console.ReadLine());
                continue;
            }
            break;
        } 
    
     while (true)
    {
        if (hNum > pNum)
            {
                Console.WriteLine($"{hNum} is high low.");
                Console.Write("What is you next guess? ");
                hNum = Convert.ToInt32(Console.ReadLine());
                continue;
            }
            break;
        } 

    while (true)
        {
        if (hNum == pNum)
        {
            Console.Clear();
            Console.WriteLine("You guessed the number!");
            break;
        }
        continue;
        }
}

// More clean method!
/*
int number;
Console.Clear();
do
{
Console.Clear();
    Console.Write("Pilot, enter a number between 0 and 100: ");
    number = Convert.ToInt32(Console.ReadLine());
}
while (number < 0 || number > 100);

Console.Clear();

Console.WriteLine("Hunter, guess the number.");

while(true)
{
    Console.Write("What is your next guess? ");
    int guess = Convert.ToInt32(Console.ReadLine());

    if (guess > number) Console.WriteLine($"{guess} is too high.");
    else if (guess < number) Console.WriteLine($"{guess} is too low.");
    else break;
}

Console.WriteLine("You guessed the number!");
*/
Console.Clear();
Console.WriteLine("The Magic Cannon");

// The Magic Cannon
for (int blast = 1; blast <= 100; blast++)
{
    if (blast % 5 == 0 && blast % 3 == 0)
        {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"{blast}: Electric and Fire");
        }
    else if (blast % 3 == 0)
        {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"{blast}: Fire");
        }
    else if (blast % 5 == 0)
        {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"{blast}: Electric");
        }
    else 
        {
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine($"{blast}: Normal");
        }
}
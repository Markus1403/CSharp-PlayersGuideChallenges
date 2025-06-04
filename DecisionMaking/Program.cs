/*
Console.Title = "The Clocktower";

//Reparing the Clocktower
Console.Write("Enter a number: ");

if (num % 2 == 0)
    Console.WriteLine("Tick");
else
    Console.WriteLine("Tock");
Console.Beep();
*/
Console.Title = "The Watchtower";
//The Watchtower 
Console.Write("Enter an x-coordinate: ");
int x = Convert.ToInt32(Console.ReadLine());
Console.Write("Enter an y-coordinate: ");
int y = Convert.ToInt32(Console.ReadLine());

Console.Clear();

if (x < 0 && y > 0)
    Console.WriteLine("The enemy is to the NW");
else if (x == 0 && y > 0)
    Console.WriteLine("The enemy is to the N");
else if (x > 0 && y > 0)
    Console.WriteLine("The enemy is to the NE");
else if (x < 0 && y == 0)
    Console.WriteLine("The enemy is to the W");
else if (x == 0 && y == 0)
    Console.WriteLine("The enemy is here!!!");
else if (x > 0 && y == 0)
    Console.WriteLine("The enemy is to the E");
else if (x < 0 && y < 0)
    Console.WriteLine("The enemy is to the SW");
else if (x == 0 && y < 0)
    Console.WriteLine("The enemy is to the S");
else if (x > 0 && y < 0)
    Console.WriteLine("The enemy is to the SE");



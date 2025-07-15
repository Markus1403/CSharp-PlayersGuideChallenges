Console.Write("Enter your name: ");
string name = Console.ReadLine();

int score = 0;
string filePath = $"{name}.txt";

if (File.Exists(filePath))
{
    string content = File.ReadAllText(filePath);
    int.TryParse(content, out score);
    Console.WriteLine($"Last time your score was: {score}");
}

Console.WriteLine("Press any key (press 'enter' to quit):");

while (true)
{
    var key = Console.ReadKey(true); 
    score++;
    Console.WriteLine($"Current score: {score}");
    if (key.Key == ConsoleKey.Enter)
    {
        File.WriteAllText(filePath, score.ToString());
        break;
    }
}

Console.WriteLine($"\nTotal keypresses: {score}");


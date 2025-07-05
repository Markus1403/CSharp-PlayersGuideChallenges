// NumberCruncher numberCruncher = new NumberCruncher();
// numberCruncher.ValidateNumber();

Random random = new Random();

Console.WriteLine(random.NextDouble(100));
Console.WriteLine(random.NextString("Red", "Green", "Blue"));
Console.WriteLine(random.CoinFlip());
Console.WriteLine(random.CoinFlip(0.25));

public class NumberCruncher {
    public bool ValidateNumber() {
        Console.Write("Enter a valid Number, double or bool: ");
        while (true) {
            string? input = Console.ReadLine();
            if (int.TryParse(input, out int intValue)) {
                Console.WriteLine($"You entered {intValue}.");
                return true;
            }
            else if (double.TryParse(input, out double doubleValue)) {
                Console.WriteLine($"You entered {doubleValue}.");
                return true;
            }
            else if (bool.TryParse(input, out bool boolValue)) {
                Console.WriteLine($"You entered {boolValue}.");
                return true;
            }
            else  { 
                Console.WriteLine("That is not a valid number! Try again.");
                return false;
            }
        }
    }
}

public static class RandomExtensions
    {
        public static double NextDouble(this Random random, double maximum) => random.NextDouble() * maximum;

        public static string NextString(this Random random, params string[] options) => options[random.Next(options.Length)];

        public static bool CoinFlip(this Random random, double probabilityOfHeads = 0.5) => random.NextDouble() < probabilityOfHeads;
    }
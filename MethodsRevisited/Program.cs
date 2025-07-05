NumberCruncher numberCruncher = new NumberCruncher();
numberCruncher.ValidateNumber();

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
Console.Write("Which filter do you want to use? (1=Even, 2=Positive, 3=MultipleOfTen) ");
int choice = Convert.ToInt32(Console.ReadLine());

Sieve sieve = choice switch
{
    1 => new Sieve(IsEven),
    2 => new Sieve(IsPositive),
    3 => new Sieve(IsMultipleOfTen),
};

while (true) {
    Console.Write("Enter a number: ");
    int number = Convert.ToInt32(Console.ReadLine());

    string goodOrEvil = sieve.IsGood(number) ? "good" : "evil";
    Console.WriteLine($"That number is {goodOrEvil}.");
}

bool IsEven(int number) {
    return number % 2 == 0;
}

bool IsPositive(int number) {
    return number > 0;
}

bool IsMultipleOfTen(int number) {
    return number % 10 == 0;
}

public class Sieve
{
    private readonly Func<int, bool> predicate; // Store the delegate

    public Sieve(Func<int, bool> predicate)
    {
        this.predicate = predicate;
    }

    public bool IsGood(int number)
    {
        return predicate(number); // Invoke the delegate
    }

}

// If we wanted to solve with inheritance and polymorphism, we could just create an abstract class,
// that provides IsGood(), and all the derived classes implement their own version of IsGood()
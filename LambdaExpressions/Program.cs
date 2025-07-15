Console.Write("Which filter do you want to use? (1=Even, 2=Positive, 3=MultipleOfTen) ");
int choice = Convert.ToInt32(Console.ReadLine());

Sieve sieve = choice switch
{
    1 => new Sieve(n => n % 2 == 0),
    2 => new Sieve(n => n > 0),
    3 => new Sieve(n => n % 10 == 0),
};

while (true) {
    Console.Write("Enter a number: ");
    int number = Convert.ToInt32(Console.ReadLine());

    string goodOrEvil = sieve.IsGood(number) ? "good" : "evil";
    Console.WriteLine($"That number is {goodOrEvil}.");
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


using System;
using System.Threading;


RecentNumbers recentNumbers = new RecentNumbers { FirstRecent = 0, SecondRecent = 0 };
Thread thread = new Thread(GenerateNumbersLoop);
thread.Start(recentNumbers);

while (true) {
    Console.ReadKey(false);
    
    lock(recentNumbers) {
        if (recentNumbers.FirstRecent == recentNumbers.SecondRecent) {
            Console.WriteLine("You found a repitition!");
        } else {
            Console.WriteLine("That is not a repitition. Try again!");
        }
    }
}

void GenerateNumbersLoop(object? obj) {
    Random random = new Random();
    RecentNumbers recentNumbers = (RecentNumbers)obj!;
    
    while (true) {
        int randomNumber = random.Next(10);

        lock(recentNumbers) {
            recentNumbers.SecondRecent = recentNumbers.FirstRecent;
            recentNumbers.FirstRecent = randomNumber;
        }
        
        Console.WriteLine(randomNumber);
        Thread.Sleep(1000);
    }
}


public class RecentNumbers {
    public int FirstRecent { get; set; }
    public int SecondRecent { get; set; }
}
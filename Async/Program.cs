using System.Threading;
Console.Write("Enter a maximum five letter word: ");
string? inputWord = Console.ReadLine();

DateTime start = DateTime.Now;

if (string.IsNullOrEmpty(inputWord)) {
    Console.WriteLine("Invalid input.");
    return;
}

int result = await RandomlyRecreateAsync(inputWord);
TimeSpan elapsed = DateTime.Now - start;
Console.WriteLine(elapsed);

int RandomlyRecreate(string inputWord) {

    Random random = new Random();
    int attempts = 0;

    while (true) {
        attempts++;
        string generatedWord = "";
        for (int i = 0; i < inputWord.Length; i++) {
            generatedWord += (char)('a' + random.Next(26));
        } 

        if (generatedWord == inputWord)
            break;        
    }
    return attempts;
}

Task<int> RandomlyRecreateAsync(string inputWord) {
    return Task.Run(() => RandomlyRecreate(inputWord));
}

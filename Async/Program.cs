using System.Threading;

while (true) {
    Console.Write("Enter a maximum five letter word: ");
    string? inputWord = Console.ReadLine(); 
    WaitForWord(inputWord);
}

async Task WaitForWord(string inputWord) {
    DateTime start = DateTime.Now;
    int attempts = await RandomlyRecreateAsync(inputWord);
    Console.WriteLine($"The word {inputWord} took {attempts} attempts.");
    TimeSpan elapsed = DateTime.Now - start;
    Console.WriteLine(elapsed);
}

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

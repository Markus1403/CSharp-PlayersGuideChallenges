Random random = new Random();

var answers = new List<int>(); 

int cookie = random.Next(0, 10);

while (true) {
    try {
        int player1Num = AskForNumberInRange("Player 1, enter a number between 0 and 9: ", 0, 10);
        
        if (answers.Contains(player1Num)) {
            Console.WriteLine("That number has already been chosen. Try again.");
            continue;
        }
        else if (player1Num == cookie) {
            throw new Exception();
        }
        else { 
            answers.Add(player1Num); 
        }
        
        while (true) {
            int player2Num = AskForNumberInRange("Player 2, enter a number between 0 and 9: ", 0, 10);
            
            if (answers.Contains(player2Num)) {
                Console.WriteLine("That number has already been chosen. Try again.");
                continue;
            }
            else if (player2Num == cookie) {
                throw new Exception();
            }
            else { 
                answers.Add(player2Num); 
                break; 
            }
        }
    }
    catch (Exception) {
        Console.WriteLine("You ate the oatmeal raisin cookie! You lose!");
        break;
    }
}



// Methods for choosing number between 0 and 100
int AskForNumber(string text)
{
    Console.Write(text + " ");
    int number = Convert.ToInt32(Console.ReadLine());
    return number;
}

int AskForNumberInRange(string text, int min, int max)
{
    while (true)
    {
        int number = AskForNumber(text);
        if (number >= min && number < max)
            return number;
    }

}
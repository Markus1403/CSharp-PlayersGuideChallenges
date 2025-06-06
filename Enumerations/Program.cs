Console.Title = "Simula's Test";
Console.Clear();

ChestState current  = ChestState.Locked;  
while(true)
{       
    Console.Write($"The chest is {current}. What do you want to do? ");
    string input = Console.ReadLine();
    if (current == ChestState.Locked && input == "Unlock") current = ChestState.Closed;
    if (current == ChestState.Closed && input == "Open") current = ChestState.Open;
    if (current == ChestState.Open && input == "Close") current = ChestState.Closed;
    if (current == ChestState.Closed && input == "Lock") current = ChestState.Locked;
   
}


// enum for chest state 
enum ChestState
{Open, Closed, Locked}

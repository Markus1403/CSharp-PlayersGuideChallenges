//The Replicator of D'To 
// My solution not very good could be much much better 
Console.Clear();
/*
int[] array1 = new int[5]; // the first array of length 5
// the five numbers chosen are put in the five places in the array
Console.WriteLine("What five numbers do you want to put in the array?: ");
array1[0] = Convert.ToInt32(Console.ReadLine());
array1[1] = Convert.ToInt32(Console.ReadLine());
array1[2] = Convert.ToInt32(Console.ReadLine());
array1[3] = Convert.ToInt32(Console.ReadLine());
array1[4] = Convert.ToInt32(Console.ReadLine());

int[] array2 = new int[5]; // the second array of length 5

for (int index = 0; index < array1.Length; index++)
{
    array2[index] = array1[index];
}  
    Console.WriteLine("This is the original array: ");
foreach (int index in array1)
{
    Console.WriteLine(index);
}
    Console.WriteLine("This is the duplicate: ");
foreach (int index in array2)
{
    Console.WriteLine(index);
}


// A much better solution 
int[] original = new int[5];

for(int item = 0; item < 5; item++)
{
    Console.Write("Enter a number: ");
    int number = Convert.ToInt32(Console.ReadLine());
    original[item] = number;
}

int[] copy = new int[5];

for (int index = 0; index < 5; index++)
    copy[index] = original[index];

for (int index = 0; index < 5; index++)
    Console.WriteLine($"{original[index]} and {copy[index]}");
*/

//The Laws of Freach
int[] array = [4, 51, -7, 13, -99, 15, -8, 45, 90];

int currentSmallest = int.MaxValue; // Start higher than anything in the array. 
foreach (int num in array)
    {
        if (num < currentSmallest)
            currentSmallest = num;
    }   
Console.WriteLine(currentSmallest);
int total = 0;
foreach (int num in array)
        total += num;
float average = (float)total / array.Length;
Console.WriteLine(average);
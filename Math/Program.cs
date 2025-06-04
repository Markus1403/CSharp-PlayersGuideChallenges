/*
// The Triangle Farmer
Console.WriteLine("What is the base?");
string widthText = Console.ReadLine();
float width = Convert.ToSingle(widthText);

Console.WriteLine("What is the height?");
string heightText = Console.ReadLine();
float height = Convert.ToSingle(heightText);

float area = (width * height) / 2;
Console.WriteLine("The area is " + area);


// The four Sisters and the Duckbear
Console.WriteLine("Input number of eggs gathered today:");
string eggStr = Console.ReadLine();
uint eggs = Convert.ToUInt32(eggStr);

float eggsForSis = eggs / 4;
float eggsForDB = eggs % 4;

Console.WriteLine("The amount of chocolate eggs for each sister is: " + eggsForSis);
Console.WriteLine("The amount of chocolate eggs left for duckbear is: " + eggsForDB);
*/
// Answer this question: What are three total egg counts where the duckbear gets more than each sister does?
// Use the program you created to help you find the answer.
//
// If there is less than four eggs, the sisters will get 0. So a total count of 1, 2, or 3 would each
// give the duckbear more than the sisters. But 6 will give each sister 1 and the duckbear 2, 7 gives
// each sister 1 and the duckbear 3, and 11 gives each sister 2 and the duckbear 3.

// The Dominion of Kings
Console.WriteLine("How many Provinceses do you own?");
int province = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("How many duchies do you own?");
int duchy = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("How many estates do you own?");
int estate = Convert.ToInt32(Console.ReadLine());

int a = 0;
int provinceInc = a + 6 * province;

int b = 0;
int duchyInc = b + 3 * duchy;

int c = 0;
int estateInc = c + 1 * estate;

int pointsTotal = provinceInc + duchyInc + estateInc; // or more simply we could just do total = province * 6 + duchy * 3 + estate * 1

Console.WriteLine("Your point total: " + pointsTotal); 
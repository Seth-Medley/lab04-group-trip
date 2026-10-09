/*
* Name: Seth Medley
* Course: CSCI 1250, Section 001
* Assignment: Lab 04, The Group Trip
* Date: October 9, 2026
* Description: Rebuilds the trip calculator with methods and arrays so it 
* reports on a whole group instead of one person.
*/
const int pizzaSlices = 8;
const double taxRate = 0.18; 

Console.Write("Round trip miles: ");
int milesForTheTrip = Convert.ToInt32(Console.ReadLine());

Console.Write("Miles per gallon: ");
int milesPerGallon = Convert.ToInt32(Console.ReadLine());

Console.Write("Price per gallon: ");
double gasPrice = Convert.ToDouble(Console.ReadLine());

Console.Write("How many pizzas: ");
int pizzaAmt = Convert.ToInt32(Console.ReadLine());

Console.Write("Price per pizza: ");
double pizzaPrice = Convert.ToDouble(Console.ReadLine());
System.Console.WriteLine();

/////////////////////////////////////////////////
// Part 1: The Trip
//////////////////////////////////////////
Console.WriteLine("=== Part 1: The Trip ===");

double fuelCost = FuelCost(milesForTheTrip, milesPerGallon, gasPrice);
double pizzaTotalCost = pizzaAmt * pizzaPrice;
double tripTotal = fuelCost + pizzaTotalCost;

Console.WriteLine($"Fuel cost: {fuelCost.ToString("C")}");
Console.WriteLine($"Pizza cost: {pizzaTotalCost.ToString("C")}");
Console.WriteLine($"Trip total: {tripTotal.ToString("C")}");
System.Console.WriteLine();
/////////////////////////////////////////
// Part 2: The Group
////////////////////
Console.WriteLine("=== Part 2: The Group ===");
string[] names = {"Ada", "Grace", "Alan", "Katherine"};

int peopleGoing = names.Length;
double slicesEach = (pizzaAmt * pizzaSlices) / (double)peopleGoing;
double costPerPerson = tripTotal / peopleGoing;

Console.WriteLine($"People going: {peopleGoing}");
Console.WriteLine($"Slices each: {slicesEach.ToString("F1")}");
Console.WriteLine($"Cost per person: {costPerPerson.ToString("C")}");
System.Console.WriteLine();
///////////////////////////////////////
// Part 3: Who Works How Long
/////////////////////
Console.WriteLine("=== Part 3: Who Works How Long ===");

double totalHours = 0;
double longest = 0;
double totalTakeHomePay = 0;
double[] hoursWorked = {22, 15, 30, 18};
double[] hourlyRates = {13.50, 16.00, 11.20, 14.80};
// Starts at the beggining of the names array and loops through until the end.
for (int i = 0; i < names.Length; i++)
{
    double takeHomePay = TakeHomePay(hoursWorked[i], hourlyRates[i], taxRate);
    double takeHomePerHour = takeHomePay / hoursWorked[i];
    double hoursNeeded = HoursToCover(costPerPerson, takeHomePerHour);

    totalHours += hoursWorked[i];
    totalTakeHomePay += takeHomePay;

    Console.WriteLine($"{names[i]}: takes home {takeHomePay.ToString("C")} for {hoursWorked[i]} hours, {takeHomePerHour.ToString("C")} per hour, must work {hoursNeeded.ToString("F2")} hours");
}
Console.WriteLine($"Total hours worked: {totalHours}");
Console.WriteLine($"Total take home pay: {totalTakeHomePay.ToString("C")}");
Console.WriteLine($"Longest anyone must work: {longest.ToString("F2")}");
System.Console.WriteLine();

///////////////////////////////////////////
/// Summary
/// ///////////////////////////////////////
// Calculates the fuel cost of the entire trip.
static double FuelCost(double miles, double milesPerGallon, double pricePerGallon)
{
    double gallons = miles / milesPerGallon;
    return gallons * pricePerGallon;
}
// Calculates how much the person takes home after taxes are withheld.
static double TakeHomePay(double hours, double hourlyRate, double taxRate)
{
    double grossPay = hours * hourlyRate;
    double taxWithheld = grossPay * taxRate;
    return grossPay - taxWithheld;
}
// Returns how much each person much work in order ot cover their share.
static double HoursToCover(double amountOwed, double takeHomePerHour)
{
    return amountOwed / takeHomePerHour;
}

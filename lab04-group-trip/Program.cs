/*
* Name: Seth Medley
* Course: CSCI 1250, Section 001
* Assignment: Lab 04, The Group Trip
* Date: October 9, 2026
* Description: Rebuilds the trip calculator with methods and arrays so it 
* reports on a whole group instead of one person.
*/
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

static double FuelCost(double miles, double milesPerGallon, double pricePerGallon)
{
    double gallons = miles / milesPerGallon;
    return gallons * pricePerGallon;
}
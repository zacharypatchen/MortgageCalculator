using System;

class MortgageCalculator
{
    static void Main()
    {
        // Input: House cost
        Console.Write("How much does the house cost? ");
        double houseCost = ReadDoubleFromConsole();

        // Input: Down payment percentage
        Console.Write("What percent are you putting down? ");
        double downPaymentPercentage = ReadDoubleFromConsole();

        // Calculate down payment
        double downPayment = (downPaymentPercentage / 100) * houseCost;
        double remainingMortgage = houseCost - downPayment;

        Console.WriteLine($"You are putting down {downPayment:C} leaving {remainingMortgage:C} for the mortgage.");

        // Input: Mortgage duration
        Console.Write("How many years does the mortgage last? ");
        int mortgageYears = ReadIntFromConsole();

        // Input: Interest rate
        Console.Write("What is your interest rate? ");
        double interestRate = ReadDoubleFromConsole();

        // Calculate monthly payment
        int numberOfPayments = mortgageYears * 12;
        double monthlyInterestRate = (interestRate / 100) / 12;
        double monthlyPayment = (remainingMortgage * monthlyInterestRate) / (1 - Math.Pow(1 + monthlyInterestRate, -numberOfPayments));

        Console.WriteLine($"You will make {numberOfPayments} payments of {monthlyPayment:C}");

        // Calculate total payments over the mortgage period
        double totalPayments = monthlyPayment * numberOfPayments;
        Console.WriteLine($"Over {mortgageYears} years, this will be a total of {totalPayments:C}");
    }

    static double ReadDoubleFromConsole()
    {
        double result;
        while (!double.TryParse(Console.ReadLine(), out result))
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }
        return result;
    }

    static int ReadIntFromConsole()
    {
        int result;
        while (!int.TryParse(Console.ReadLine(), out result))
        {
            Console.WriteLine("Invalid input. Please enter a valid integer.");
        }
        return result;
    }
}

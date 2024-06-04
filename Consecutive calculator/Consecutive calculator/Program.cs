using System;

public class Calculator
{
    private double currentValue;
    private string lastOperator;

    public Calculator()
    {
        currentValue = 0;
        lastOperator = "";
    }

    private void PerformCalculation(double number)
    {
        switch (lastOperator)
        {
            case "+":
                currentValue += number;
                break;
            case "-":
                currentValue -= number;
                break;
            case "*":
                currentValue *= number;
                break;
            case "/":
                if (number != 0)
                {
                    currentValue /= number;
                }
                else
                {
                    Console.WriteLine("Cannot divide by zero");
                }
                break;
            default:
                currentValue = number;
                break;
        }
        Console.WriteLine($"Current value: {currentValue}");
    }

    private bool IsOperator(string input)
    {
        return input == "+" || input == "-" || input == "*" || input == "/";
    }

    public void Start()
    {
        while (true)
        {
            Console.WriteLine("Enter an operation (number or operator):");
            string input = Console.ReadLine();
            if (double.TryParse(input, out double number))
            {
                PerformCalculation(number);
            }
            else if (IsOperator(input))
            {
                lastOperator = input;
            }
            else if (input.Equals("exit", StringComparison.OrdinalIgnoreCase))
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid input");
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Calculator calculator = new Calculator();
        calculator.Start();
    }
}

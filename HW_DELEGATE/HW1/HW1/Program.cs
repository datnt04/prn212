using System;

namespace HW1;

// Event delegates for different operations
public delegate void CalculationEventHandler(string operation, double operand1, double operand2, double result);
public delegate void ErrorEventHandler(string operation, string errorMessage);

public class EventCalculator
{
    // Declare events for calculation operations
    public event CalculationEventHandler OperationPerformed;
    public event ErrorEventHandler ErrorOccurred;

    public double Add(double a, double b)
    {
        double result = a + b;
        OnOperationPerformed("Add", a, b, result);
        return result;
    }

    public double Subtract(double a, double b)
    {
        double result = a - b;
        OnOperationPerformed("Subtract", a, b, result);
        return result;
    }

    public double Multiply(double a, double b)
    {
        double result = a * b;
        OnOperationPerformed("Multiply", a, b, result);
        return result;
    }

    public double Divide(double a, double b)
    {
        if (b == 0)
        {
            OnErrorOccurred("Divide", "Division by zero is not allowed");
            return 0;
        }
        double result = a / b;
        OnOperationPerformed("Divide", a, b, result);
        return result;
    }

    protected virtual void OnOperationPerformed(string operation, double operand1, double operand2, double result)
    {
        OperationPerformed?.Invoke(operation, operand1, operand2, result);
    }

    protected virtual void OnErrorOccurred(string operation, string errorMessage)
    {
        ErrorOccurred?.Invoke(operation, errorMessage);
    }
}

public class CalculationLogger
{
    public void OnOperationPerformed(string operation, double operand1, double operand2, double result)
    {
        Console.WriteLine($"Operation: {operation}({operand1}, {operand2}) = {result}");
    }

    public void OnErrorOccurred(string operation, string errorMessage)
    {
        Console.WriteLine($"Error in {operation}: {errorMessage}");
    }
}

public class CalculationAuditor
{
    private int _operationCount = 0;

    public void OnOperationPerformed(string operation, double operand1, double operand2, double result)
    {
        _operationCount++;
    }

    public void DisplayStatistics()
    {
        Console.WriteLine($"\nTotal operations performed: {_operationCount}");
    }
}

public class ErrorHandler
{
    public void OnErrorOccurred(string operation, string errorMessage)
    {
        Console.WriteLine($"*** ERROR ALERT *** {operation} failed: {errorMessage}");
    }
}

public class HW1_EventCalculator
{
    public static void Main(string[] args)
    {
        Console.WriteLine("=== HOMEWORK 1: EVENT CALCULATOR ===");
        Console.WriteLine("Instructions:");
        Console.WriteLine("1. Implement the EventCalculator class with events for each operation");
        Console.WriteLine("2. Implement subscriber classes: CalculationLogger, CalculationAuditor, ErrorHandler");
        Console.WriteLine("3. Subscribe to events and test all operations including error cases");
        Console.WriteLine();

        EventCalculator calculator = new EventCalculator();
        CalculationLogger logger = new CalculationLogger();
        CalculationAuditor auditor = new CalculationAuditor();
        ErrorHandler errorHandler = new ErrorHandler();

        // Subscribe to events
        calculator.OperationPerformed += logger.OnOperationPerformed;
        calculator.OperationPerformed += auditor.OnOperationPerformed;
        calculator.ErrorOccurred += logger.OnErrorOccurred;
        calculator.ErrorOccurred += errorHandler.OnErrorOccurred;

        // Test operations
        calculator.Add(10, 5);
        calculator.Subtract(10, 3);
        calculator.Multiply(4, 7);
        calculator.Divide(15, 3);
        calculator.Divide(10, 0); // Should trigger error

        // Display statistics
        auditor.DisplayStatistics();

        Console.ReadKey();
    }
}
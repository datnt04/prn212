namespace bai1
// A simple calculator app that takes commands from the command line
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to .NET Core Calculator!");
            Console.WriteLine("Available operations: add, subtract, multiply, divide");
            Console.WriteLine("Example usage: add 5 3");
            Console.WriteLine("Type 'exit' to quit");

            bool running = true;
            while (running)
            {
                Console.Write("> ");
                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                    continue;

                string[] parts = input.Trim().Split(' ');

                if (parts[0].ToLower() == "exit")
                {
                    running = false;
                    continue;
                }

                if (parts.Length != 3)
                {
                    Console.WriteLine("Invalid input format. Please use: operation number1 number2");
                    continue;
                }

                string operation = parts[0].ToLower();
                if (double.TryParse(parts[1], out double num1) && double.TryParse(parts[2], out double num2))
                {
                    switch (operation)
                    {
                        case "add":
                            Console.WriteLine($"{num1} + {num2} = {num1 + num2}");
                            break;
                        case "subtract":
                            Console.WriteLine($"{num1} - {num2} = {num1 - num2}");
                            break;
                        case "multiply":
                            Console.WriteLine($"{num1} * {num2} = {num1 * num2}");
                            break;
                        case "divide":
                            if (num2 != 0)
                                Console.WriteLine($"{num1} / {num2} = {num1 / num2}");
                            else
                                Console.WriteLine("Error: Division by zero is not allowed.");
                            break;
                        default:
                            Console.WriteLine("Unknown operation. Please use: add, subtract, multiply, divide");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid numbers. Please enter valid numeric values.");
                }

                // TODO: Implement subtract, multiply, divide operations
            }
        }
    }
}

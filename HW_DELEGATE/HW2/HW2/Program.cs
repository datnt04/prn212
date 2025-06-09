using System;
using System.Collections.Generic;
using System.Text;

namespace DelegatesLinQ.Homework
{
    // Delegate types for processing pipeline
    public delegate string DataProcessor(string input);
    public delegate void ProcessingEventHandler(string stage, string input, string output);

    public class DataProcessingPipeline
    {
        // Declare events for monitoring the processing
        public event ProcessingEventHandler ProcessingStageCompleted;

        // Individual processing methods
        public static string RemoveSpaces(string input)
        {
            string output = input.Replace(" ", "");
            return output;
        }

        public static string ToUpperCase(string input)
        {
            string output = input.ToUpper();
            return output;
        }

        public static string AddTimestamp(string input)
        {
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string output = $"{timestamp}: {input}";
            return output;
        }

        public static string ReverseString(string input)
        {
            char[] charArray = input.ToCharArray();
            Array.Reverse(charArray);
            string output = new string(charArray);
            return output;
        }

        public static string EncodeBase64(string input)
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            string output = Convert.ToBase64String(inputBytes);
            return output;
        }

        public static string ValidateInput(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException("Input cannot be null or empty");
            }
            return input;
        }

        // Method to process data through the pipeline
        public string ProcessData(string input, DataProcessor pipeline)
        {
            try
            {
                string currentInput = input;
                foreach (DataProcessor processor in pipeline.GetInvocationList())
                {
                    string stageName = processor.Method.Name;
                    string output = processor(currentInput);
                    OnProcessingStageCompleted(stageName, currentInput, output);
                    currentInput = output;
                }
                return currentInput;
            }
            catch (Exception ex)
            {
                OnProcessingStageCompleted("Error", input, ex.Message);
                throw;
            }
        }

        // Method to raise processing events
        protected virtual void OnProcessingStageCompleted(string stage, string input, string output)
        {
            ProcessingStageCompleted?.Invoke(stage, input, output);
        }
    }

    // Logger class to monitor processing
    public class ProcessingLogger
    {
        public void OnProcessingStageCompleted(string stage, string input, string output)
        {
            Console.WriteLine($"Stage: {stage}");
            Console.WriteLine($"  Input: {input}");
            Console.WriteLine($"  Output: {output}");
            Console.WriteLine();
        }
    }

    // Performance monitor class
    public class PerformanceMonitor
    {
        private Dictionary<string, int> _stageCounts = new Dictionary<string, int>();
        private Dictionary<string, double> _stageTimes = new Dictionary<string, double>();
        private DateTime _startTime;

        public void OnProcessingStageCompleted(string stage, string input, string output)
        {
            if (!_stageCounts.ContainsKey(stage))
            {
                _stageCounts[stage] = 0;
                _stageTimes[stage] = 0;
            }
            _stageCounts[stage]++;
            // Simulate timing (in a real scenario, you'd use Stopwatch)
            _stageTimes[stage] += new Random().NextDouble() * 100; // Random time for demo
        }

        public void DisplayStatistics()
        {
            Console.WriteLine("\n=== Processing Statistics ===");
            foreach (var stage in _stageCounts)
            {
                Console.WriteLine($"Stage: {stage.Key}");
                Console.WriteLine($"  Executions: {stage.Value}");
                Console.WriteLine($"  Total Time: {(_stageTimes[stage.Key]):F2} ms");
            }
        }
    }

    public class DelegateChain
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("=== HOMEWORK 2: CUSTOM DELEGATE CHAIN ===");
            Console.WriteLine("Instructions:");
            Console.WriteLine("1. Implement the DataProcessingPipeline class");
            Console.WriteLine("2. Implement all processing methods (RemoveSpaces, ToUpperCase, etc.)");
            Console.WriteLine("3. Create a multicast delegate chain for processing");
            Console.WriteLine("4. Add logging and monitoring capabilities");
            Console.WriteLine("5. Demonstrate adding/removing processors from the chain");
            Console.WriteLine();

            DataProcessingPipeline pipeline = new DataProcessingPipeline();
            ProcessingLogger logger = new ProcessingLogger();
            PerformanceMonitor monitor = new PerformanceMonitor();

            // Subscribe to events
            pipeline.ProcessingStageCompleted += logger.OnProcessingStageCompleted;
            pipeline.ProcessingStageCompleted += monitor.OnProcessingStageCompleted;

            // Create processing chain
            DataProcessor processingChain = DataProcessingPipeline.ValidateInput;
            processingChain += DataProcessingPipeline.RemoveSpaces;
            processingChain += DataProcessingPipeline.ToUpperCase;
            processingChain += DataProcessingPipeline.AddTimestamp;

            // Test the pipeline
            string testInput = "Hello World from C#";
            Console.WriteLine($"Input: {testInput}");
            string result = pipeline.ProcessData(testInput, processingChain);
            Console.WriteLine($"Output: {result}");
            Console.WriteLine();

            // Demonstrate adding more processors
            processingChain += DataProcessingPipeline.ReverseString;
            processingChain += DataProcessingPipeline.EncodeBase64;

            // Test again with extended pipeline
            result = pipeline.ProcessData("Extended Pipeline Test", processingChain);
            Console.WriteLine($"Extended Output: {result}");
            Console.WriteLine();

            // Demonstrate removing a processor
            processingChain -= DataProcessingPipeline.ReverseString;
            result = pipeline.ProcessData("Without Reverse", processingChain);
            Console.WriteLine($"Modified Output: {result}");
            Console.WriteLine();

            // Display performance statistics
            monitor.DisplayStatistics();

            // Error handling test
            try
            {
                result = pipeline.ProcessData(null, processingChain); // Should handle null input
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error handled: {ex.Message}");
            }

            Console.ReadKey();
        }
    }
}

using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace bai2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("File Analyzer - .NET Core");
            Console.WriteLine("This tool analyzes text files and provides statistics.");

            if (args.Length == 0)
            {
                Console.WriteLine("Please provide a file path as a command-line argument.");
                Console.WriteLine("Example: dotnet run myfile.txt");
                return;
            }

            string filePath = args[0];

            if (!File.Exists(filePath))
            {
                Console.WriteLine($"Error: File '{filePath}' does not exist.");
                return;
            }

            try
            {
                Console.WriteLine($"Analyzing file: {filePath}");

                // Đọc nội dung tệp
                string content = File.ReadAllText(filePath);

                // 1. Đếm số dòng
                int lineCount = File.ReadAllLines(filePath).Length;
                Console.WriteLine($"Number of lines: {lineCount}");

                // 2. Đếm số từ
                string[] words = Regex.Matches(content, @"\b\w+\b")
                                      .Cast<Match>()
                                      .Select(m => m.Value.ToLower())
                                      .ToArray();
                Console.WriteLine($"Number of words: {words.Length}");

                // 3. Đếm số ký tự
                int charCountWithSpaces = content.Length;
                int charCountWithoutSpaces = content.Count(c => !char.IsWhiteSpace(c));
                Console.WriteLine($"Characters (with spaces): {charCountWithSpaces}");
                Console.WriteLine($"Characters (no spaces): {charCountWithoutSpaces}");

                // 4. Đếm số câu (giả sử câu kết thúc bằng . ! ?)
                int sentenceCount = Regex.Matches(content, @"[\.!?]+").Count;
                Console.WriteLine($"Number of sentences: {sentenceCount}");

                // 5. Tìm từ phổ biến nhất
                var mostCommonWords = words
                    .GroupBy(w => w)
                    .OrderByDescending(g => g.Count())
                    .Take(5); // top 5

                Console.WriteLine("Most common words:");
                foreach (var word in mostCommonWords)
                {
                    Console.WriteLine($"  {word.Key}: {word.Count()} times");
                }

                // 6. Độ dài trung bình của từ
                double avgWordLength = words.Length > 0
                    ? words.Average(w => w.Length)
                    : 0;
                Console.WriteLine($"Average word length: {avgWordLength:F2}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during file analysis: {ex.Message}");
            }
        }
    }
}

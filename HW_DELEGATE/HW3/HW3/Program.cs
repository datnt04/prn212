using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace HW3;

public class Student
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public int Age { get; set; }
    public required string Major { get; set; }
    public double GPA { get; set; }
    public List<Course> Courses { get; set; } = new List<Course>();
    public DateTime EnrollmentDate { get; set; }
    public required string Email { get; set; }
    public required Address Address { get; set; }
}

public class Course
{
    public required string Code { get; set; }
    public required string Name { get; set; }
    public int Credits { get; set; }
    public double Grade { get; set; }
    public required string Semester { get; set; }
    public required string Instructor { get; set; }
}

public class Address
{
    public required string Street { get; set; }
    public required string City { get; set; }
    public required string State { get; set; }
    public required string ZipCode { get; set; }
}

public class StudentStatistics
{
    public double MeanGPA { get; set; }
    public double MedianGPA { get; set; }
    public double StandardDeviationGPA { get; set; }
    public double AgeGPACorrelation { get; set; }
    public required List<Student> Outliers { get; set; }
}

public static class StudentExtensions
{
    public static IEnumerable<Student> FilterByAgeRange(this IEnumerable<Student> students, int minAge, int maxAge)
    {
        return students.Where(s => s.Age >= minAge && s.Age <= maxAge);
    }

    public static Dictionary<string, double> AverageGPAByMajor(this IEnumerable<Student> students)
    {
        return students.GroupBy(s => s.Major)
                      .ToDictionary(g => g.Key, g => g.Average(s => s.GPA));
    }

    public static string ToGradeReport(this Student student)
    {
        var report = $"Student: {student.Name}\n" +
                     $"Major: {student.Major}\n" +
                     $"GPA: {student.GPA:F2}\n" +
                     "Courses:\n";
        foreach (var course in student.Courses)
        {
            report += $"  {course.Code} - {course.Name}: {course.Grade:F2} ({course.Semester})\n";
        }
        return report;
    }

    public static StudentStatistics CalculateStatistics(this IEnumerable<Student> students)
    {
        var stats = new StudentStatistics { Outliers = new List<Student>() };
        var gpas = students.Select(s => s.GPA).ToList();
        var ages = students.Select(s => (double)s.Age).ToList();

        // Mean
        stats.MeanGPA = gpas.Average();

        // Median
        var sortedGPAs = gpas.OrderBy(g => g).ToList();
        stats.MedianGPA = sortedGPAs.Count % 2 == 0
            ? (sortedGPAs[sortedGPAs.Count / 2 - 1] + sortedGPAs[sortedGPAs.Count / 2]) / 2
            : sortedGPAs[sortedGPAs.Count / 2];

        // Standard Deviation
        double mean = stats.MeanGPA;
        stats.StandardDeviationGPA = Math.Sqrt(gpas.Average(g => Math.Pow(g - mean, 2)));

        // Correlation between Age and GPA
        double meanAge = ages.Average();
        double sumProduct = 0, sumSqrAge = 0, sumSqrGPA = 0;
        for (int i = 0; i < gpas.Count; i++)
        {
            sumProduct += (ages[i] - meanAge) * (gpas[i] - mean);
            sumSqrAge += Math.Pow(ages[i] - meanAge, 2);
            sumSqrGPA += Math.Pow(gpas[i] - mean, 2);
        }
        stats.AgeGPACorrelation = sumProduct / Math.Sqrt(sumSqrAge * sumSqrGPA);

        // Outliers (using IQR method)
        double q1 = sortedGPAs[sortedGPAs.Count / 4];
        double q3 = sortedGPAs[sortedGPAs.Count * 3 / 4];
        double iqr = q3 - q1;
        double lowerBound = q1 - 1.5 * iqr;
        double upperBound = q3 + 1.5 * iqr;
        stats.Outliers = students.Where(s => s.GPA < lowerBound || s.GPA > upperBound).ToList();

        return stats;
    }
}

public class LinqDataProcessor
{
    private List<Student> _students;

    public LinqDataProcessor()
    {
        _students = GenerateSampleData();
    }

    public void BasicQueries()
    {
        Console.WriteLine("=== BASIC LINQ QUERIES ===");

        // 1. Students with GPA > 3.5
        Console.WriteLine("\n1. Students with GPA > 3.5:");
        var highGPAStudents = _students.Where(s => s.GPA > 3.5);
        foreach (var student in highGPAStudents)
        {
            Console.WriteLine($"  {student.Name} - GPA: {student.GPA:F2}");
        }

        // 2. Group students by major
        Console.WriteLine("\n2. Students grouped by Major:");
        var byMajor = _students.GroupBy(s => s.Major);
        foreach (var group in byMajor)
        {
            Console.WriteLine($"  Major: {group.Key}");
            foreach (var student in group)
            {
                Console.WriteLine($"    {student.Name}");
            }
        }

        // 3. Average GPA per major
        Console.WriteLine("\n3. Average GPA by Major:");
        var avgGPAByMajor = _students.AverageGPAByMajor();
        foreach (var kvp in avgGPAByMajor)
        {
            Console.WriteLine($"  {kvp.Key}: {kvp.Value:F2}");
        }

        // 4. Students enrolled in specific courses (e.g., CS101 or CS102)
        Console.WriteLine("\n4. Students in CS101 or CS102:");
        var csStudents = _students
            .Where(s => s.Courses.Any(c => c.Code == "CS101" || c.Code == "CS102"));
        foreach (var student in csStudents)
        {
            Console.WriteLine($"  {student.Name}");
        }

        // 5. Sort students by enrollment date
        Console.WriteLine("\n5. Students sorted by Enrollment Date:");
        var sortedByDate = _students.OrderBy(s => s.EnrollmentDate);
        foreach (var student in sortedByDate)
        {
            Console.WriteLine($"  {student.Name} - {student.EnrollmentDate:yyyy-MM-dd}");
        }
    }

    public void CustomExtensionMethods()
    {
        Console.WriteLine("\n=== CUSTOM EXTENSION METHODS ===");

        // Using FilterByAgeRange
        Console.WriteLine("\n1. Students aged 20-25 with GPA > 3.5:");
        var highPerformers = _students.FilterByAgeRange(20, 25).Where(s => s.GPA > 3.5);
        foreach (var student in highPerformers)
        {
            Console.WriteLine($"  {student.Name} - Age: {student.Age}, GPA: {student.GPA:F2}");
        }

        // Using AverageGPAByMajor
        Console.WriteLine("\n2. Average GPA by Major (using extension):");
        var avgGPA = _students.AverageGPAByMajor();
        foreach (var kvp in avgGPA)
        {
            Console.WriteLine($"  {kvp.Key}: {kvp.Value:F2}");
        }

        // Using ToGradeReport
        Console.WriteLine("\n3. Grade Reports:");
        foreach (var student in _students.Take(2))
        {
            Console.WriteLine(student.ToGradeReport());
        }

        // Using CalculateStatistics
        Console.WriteLine("\n4. Statistics:");
        var stats = _students.CalculateStatistics();
        Console.WriteLine($"  Mean GPA: {stats.MeanGPA:F2}");
        Console.WriteLine($"  Median GPA: {stats.MedianGPA:F2}");
        Console.WriteLine($"  Standard Deviation: {stats.StandardDeviationGPA:F2}");
        Console.WriteLine($"  Age-GPA Correlation: {stats.AgeGPACorrelation:F2}");
        Console.WriteLine($"  Outliers: {stats.Outliers.Count} students");
    }

    public void DynamicQueries()
    {
        Console.WriteLine("\n=== DYNAMIC QUERIES ===");

        Func<Student, bool> BuildDynamicFilter(string property, string op, string value)
        {
            var parameter = Expression.Parameter(typeof(Student), "s");
            var propertyExp = Expression.Property(parameter, property);
            Expression comparison;

            if (property == "GPA")
            {
                double val = double.Parse(value);
                switch (op)
                {
                    case ">":
                        comparison = Expression.GreaterThan(propertyExp, Expression.Constant(val));
                        break;
                    case "<":
                        comparison = Expression.LessThan(propertyExp, Expression.Constant(val));
                        break;
                    default:
                        comparison = Expression.Equal(propertyExp, Expression.Constant(val));
                        break;
                }
            }
            else if (property == "Age")
            {
                int val = int.Parse(value);
                switch (op)
                {
                    case ">":
                        comparison = Expression.GreaterThan(propertyExp, Expression.Constant(val));
                        break;
                    case "<":
                        comparison = Expression.LessThan(propertyExp, Expression.Constant(val));
                        break;
                    default:
                        comparison = Expression.Equal(propertyExp, Expression.Constant(val));
                        break;
                }
            }
            else
            {
                throw new ArgumentException("Unsupported property");
            }

            var lambda = Expression.Lambda<Func<Student, bool>>(comparison, parameter);
            return lambda.Compile();
        }

        Console.WriteLine("\n1. Dynamic Filter (GPA > 3.5):");
        var highGPAFilter = BuildDynamicFilter("GPA", ">", "3.5");
        var highGPAStudents = _students.Where(highGPAFilter);
        foreach (var student in highGPAStudents)
        {
            Console.WriteLine($"  {student.Name} - GPA: {student.GPA:F2}");
        }

        Console.WriteLine("\n2. Dynamic Sort by GPA:");
        var property = Expression.Parameter(typeof(Student), "s");
        var propertyExp = Expression.Property(property, "GPA");
        var lambda = Expression.Lambda<Func<Student, double>>(propertyExp, property).Compile();
        var sortedStudents = _students.OrderBy(lambda);
        foreach (var student in sortedStudents)
        {
            Console.WriteLine($"  {student.Name} - GPA: {student.GPA:F2}");
        }

        Console.WriteLine("\n3. Dynamic Grouping by Major:");
        var groupedByMajor = _students.GroupBy(s => s.Major)
            .Select(g => new { Major = g.Key, AverageGPA = g.Average(s => s.GPA) });
        foreach (var group in groupedByMajor)
        {
            Console.WriteLine($"  {group.Major}: {group.AverageGPA:F2}");
        }
    }

    public void StatisticalAnalysis()
    {
        Console.WriteLine("\n=== STATISTICAL ANALYSIS ===");
        var stats = _students.CalculateStatistics();

        Console.WriteLine($"Mean GPA: {stats.MeanGPA:F2}");
        Console.WriteLine($"Median GPA: {stats.MedianGPA:F2}");
        Console.WriteLine($"Standard Deviation: {stats.StandardDeviationGPA:F2}");
        Console.WriteLine($"Age-GPA Correlation: {stats.AgeGPACorrelation:F2}");
        Console.WriteLine($"Number of Outliers: {stats.Outliers.Count}");
        foreach (var outlier in stats.Outliers)
        {
            Console.WriteLine($"  Outlier: {outlier.Name} (GPA: {outlier.GPA:F2})");
        }
    }

    public void PivotOperations()
    {
        Console.WriteLine("\n=== PIVOT OPERATIONS ===");

        Console.WriteLine("\n1. Students by Major vs GPA Ranges:");
        var gpaRanges = new[] { 0.0, 3.0, 3.5, 4.0 };
        var pivotTable = _students
            .GroupBy(s => s.Major)
            .Select(g => new
            {
                Major = g.Key,
                Below3 = g.Count(s => s.GPA < 3.0),
                GPA3To35 = g.Count(s => s.GPA >= 3.0 && s.GPA < 3.5),
                Above35 = g.Count(s => s.GPA >= 3.5)
            });
        foreach (var row in pivotTable)
        {
            Console.WriteLine($"  {row.Major}: <3.0: {row.Below3}, 3.0-3.5: {row.GPA3To35}, >3.5: {row.Above35}");
        }

        Console.WriteLine("\n2. Course Enrollment by Semester and Major:");
        var enrollmentPivot = _students
            .SelectMany(s => s.Courses.Select(c => new { s.Major, c.Semester }))
            .GroupBy(x => new { x.Major, x.Semester })
            .Select(g => new
            {
                g.Key.Major,
                g.Key.Semester,
                Count = g.Count()
            });
        foreach (var row in enrollmentPivot)
        {
            Console.WriteLine($"  {row.Major} - {row.Semester}: {row.Count} enrollments");
        }

        Console.WriteLine("\n3. Grade Distribution by Instructor:");
        var gradeDist = _students
            .SelectMany(s => s.Courses)
            .GroupBy(c => c.Instructor)
            .Select(g => new
            {
                Instructor = g.Key,
                AvgGrade = g.Average(c => c.Grade),
                MaxGrade = g.Max(c => c.Grade),
                MinGrade = g.Min(c => c.Grade)
            });
        foreach (var row in gradeDist)
        {
            Console.WriteLine($"  {row.Instructor}: Avg: {row.AvgGrade:F2}, Max: {row.MaxGrade:F2}, Min: {row.MinGrade:F2}");
        }
    }

    private List<Student> GenerateSampleData()
    {
        return new List<Student>
        {
            new Student
            {
                Id = 1,
                Name = "Alice Johnson",
                Age = 20,
                Major = "Computer Science",
                GPA = 3.8,
                EnrollmentDate = new DateTime(2022, 9, 1),
                Email = "alice.j@university.edu",
                Address = new Address { Street = "123 Main St", City = "Seattle", State = "WA", ZipCode = "98101" },
                Courses = new List<Course>
                {new Course { Code = "CS101", Name = "Intro to Programming", Credits = 3, Grade = 3.7, Semester = "Fall 2022", Instructor = "Dr. Smith" },
                    new Course { Code = "MATH201", Name = "Calculus II", Credits = 4, Grade = 3.9, Semester = "Fall 2022", Instructor = "Prof. Johnson" }
                }
            },
            new Student
            {
                Id = 2,
                Name = "Bob Wilson",
                Age = 22,
                Major = "Mathematics",
                GPA = 3.2,
                EnrollmentDate = new DateTime(2021, 9, 1),
                Email = "bob.w@university.edu",
                Address = new Address { Street = "456 Oak St", City = "Portland", State = "OR", ZipCode = "97201" },
                Courses = new List<Course>
                {
                    new Course { Code = "MATH301", Name = "Linear Algebra", Credits = 3, Grade = 3.3, Semester = "Spring 2023", Instructor = "Dr. Brown" },
                    new Course { Code = "STAT101", Name = "Statistics", Credits = 3, Grade = 3.1, Semester = "Spring 2023", Instructor = "Prof. Davis" }
                }
            },
            new Student
            {
                Id = 3,
                Name = "Carol Davis",
                Age = 19,
                Major = "Computer Science",
                GPA = 3.9,
                EnrollmentDate = new DateTime(2023, 9, 1),
                Email = "carol.d@university.edu",
                Address = new Address { Street = "789 Pine St", City = "San Francisco", State = "CA", ZipCode = "94101" },
                Courses = new List<Course>
                {
                    new Course { Code = "CS102", Name = "Data Structures", Credits = 4, Grade = 4.0, Semester = "Fall 2023", Instructor = "Dr. Smith" },
                    new Course { Code = "CS201", Name = "Algorithms", Credits = 3, Grade = 3.8, Semester = "Fall 2023", Instructor = "Prof. Lee" }
                }
            }
        };
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("=== HOMEWORK 3: LINQ DATA PROCESSOR ===");
        Console.WriteLine();

        Console.WriteLine("BASIC REQUIREMENTS:");
        Console.WriteLine("1. Implement basic LINQ queries (filtering, grouping, sorting)");
        Console.WriteLine("2. Use SelectMany for course data");
        Console.WriteLine("3. Calculate averages and aggregations");
        Console.WriteLine();

        Console.WriteLine("ADVANCED REQUIREMENTS:");
        Console.WriteLine("1. Create custom LINQ extension methods");
        Console.WriteLine("2. Implement dynamic queries using Expression Trees");
        Console.WriteLine("3. Perform statistical analysis (median, std dev, correlation)");
        Console.WriteLine("4. Create pivot table operations");
        Console.WriteLine();

        LinqDataProcessor processor = new LinqDataProcessor();

        processor.BasicQueries();
        processor.CustomExtensionMethods();
        processor.DynamicQueries();
        processor.StatisticalAnalysis();
        processor.PivotOperations();

        Console.ReadKey();
    }
}

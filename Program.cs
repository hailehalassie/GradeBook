using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GradeBook
{

    class Program
    {
        static void Main(string[] args)
        {
            IBook book = new DiskBook("Scott's book of grades");
            book.GradeAdded += OnGradeAdded;

            EnterGrades(book);

            var stats = book.GetStatistics();

            Console.WriteLine($"Highest grade is {stats.High}");
            Console.WriteLine($"Lowest grade is {stats.Low}");
            Console.WriteLine($"Average grade si {stats.Average:N1}");
            Console.WriteLine($"The letter grade is {stats.Letter}");
            Console.WriteLine(stats.Letter);
            Console.ReadKey();
        }

        private static void EnterGrades(IBook book)
        {
            while (true)
            {
                Console.WriteLine("Enter a grade: ");
                var input = Console.ReadLine();
                if (input == "q")
                {
                    break;
                }
                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }

                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);

                }
                catch (FormatException fx)
                {
                    Console.WriteLine(fx.Message);
                }
                finally
                {
                    Console.WriteLine("");
                }

            }
        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("A grade was added.");
        }
    }
}

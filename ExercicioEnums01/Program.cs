using System;
using System.Collections.Generic;
using ExercicioEnums01.Entities;
using ExercicioEnums01.Entities.Enums;

namespace ExercicioEnums01
{
    class Program
    {
        static void Main(string[] args)
        {

            List<HourContract> contract = new List<HourContract>();

            Console.Write("Enter department's name: ");
            string departmentName= Console.ReadLine();

            Department d1 = new Department(departmentName);

            Console.WriteLine("Enter Work Data:");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Level (Junior/MidLevel/Senior): ");
            WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine());
            Console.Write("Base Salary: ");
            double baseSalary = double.Parse(Console.ReadLine());
            Console.Write("How many contracts to this worker ? ");
            int n = int.Parse(Console.ReadLine());

            Worker worker = new Worker(name, level, baseSalary, d1);

            for (int i = 1; i<=n; i++)
            {
                Console.WriteLine("Enter #"+i+" contract data:");
                Console.Write("Date (DD/MM/YYYY): ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.Write("Value per hour: ");
                double valuePerHour = double.Parse(Console.ReadLine());
                Console.Write("Duration (hours): ");
                int hours = int.Parse(Console.ReadLine());

                HourContract c1 = new HourContract(date, valuePerHour, hours);

                worker.AddContract(c1);
            }


            Console.WriteLine();
            Console.Write("Enter month and year to calculate income(MM/YYYY): ");
            string monthAndYear = Console.ReadLine();

            int month = int.Parse(monthAndYear.Substring(0, 2));
            int year = int.Parse(monthAndYear.Substring(3));

            Console.WriteLine("Name: " + worker.Name);
            Console.WriteLine("Department: " + worker.Department.Name);
            Console.WriteLine("Income for " + monthAndYear+": " + worker.Income(year, month).ToString("F2"));
        }
    }
}

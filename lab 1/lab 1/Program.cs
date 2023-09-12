using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace lab_1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            double lownumber;
            double highnumber;

            do
            {
                Console.WriteLine("Enter a positive low number: ");
                lownumber = double.Parse(Console.ReadLine());
            } while (lownumber <= 0);

            do
            {
                Console.WriteLine("enter a big number: ");
                highnumber = double.Parse(Console.ReadLine());
            } while (highnumber <= lownumber);

            double subtract = highnumber - lownumber;

            Console.WriteLine(subtract);

            List<double> NumberList = new List<double>();
            for (double i = 0; i <= subtract; i++)
            {
                NumberList.Add(lownumber + i);
            }

            using (StreamWriter writer = new StreamWriter("numbers.txt"))
            {
                foreach (double number in NumberList)
                {
                    writer.WriteLine(number);
                }
            }

            double sum = 0;
            using (StreamReader reader = new StreamReader("numbers.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    double number = double.Parse(line);
                    sum += number;
                }
            }

            Console.WriteLine($"Sum of numbers from the Numbers file: {sum}");


            Console.WriteLine("The prime numbers between low and high: ");
            for (double i = lownumber; i <= highnumber; i++)
            {
                if (IsPrime(i))
                {
                    Console.WriteLine(i + " ");
                }
            }

        }
        static bool IsPrime(double number)
        {
            if (number <= 1) return false;
            else if (number <= 3) return true;
            else if (number % 2 == 0 || number % 3 == 0) return false;
            for (double i =  5; i * i <= number; i+= 6) 
            {
                if (number %  i == 0 || number % (i + 2) == 0)
                    return false;
            
            }
            return true;
        }
    }

}

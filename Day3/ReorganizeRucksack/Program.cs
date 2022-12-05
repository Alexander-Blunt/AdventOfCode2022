using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RucksackReorganization
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(PrioritySum.FindDuplicates(@"C:\Users\Spore\source\repos\AdventOfCode2022\Day3\ReorganizeRucksack\Day3input.txt"));
        }
    }

    public class PrioritySum
    {
        public static int FindDuplicates(string fileLocation)
        {
            string[] rucksacks = System.IO.File.ReadAllLines(fileLocation);
            int finalSum = 0;
            foreach (string sack in rucksacks)
            {
                int compartmentSize = sack.Length / 2;
                string compartment1 = sack.Substring(0, compartmentSize);
                string compartment2 = sack.Substring(compartmentSize);
                foreach (char item in compartment1)
                {
                    if (compartment2.Contains(item))
                    {
                        finalSum += GetPriority(item);
                        break;
                    }
                }
            }
            return finalSum;
        }

        public static int GetPriority(char item)
        {
            string alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            int priority = 0;
            foreach (char letter in alphabet)
            {
                priority++;
                if (letter == item)
                {
                    return priority;
                }
            }
            return 0;
        }
    }
}

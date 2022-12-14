using System.Runtime.CompilerServices;
using static System.Formats.Asn1.AsnWriter;

namespace Day2_RockPaperScissors;

public class RockPaperScissors
{
    static void Main(string[] args)
    {
        string fileLocation = "C:\\Users\\Spore\\source\\repos\\AdventOfCode2022\\Day2_RockPaperScissors\\Day2_RockPaperScissors\\Day3Input.txt";
        Console.WriteLine(SumScoreForAllRounds(fileLocation));
    }

    public static int SumScoreForAllRounds(string fileLocation)
    {
        int sum = 0;
        foreach (string line in File.ReadLines(fileLocation))
        {
            sum += CalculateScoreForRound(line);
        }
        return sum;
    }

    // Results
    // Win: A Y, B Z, C X 6 points
    // Draw: A X, B Y, C Z 3 points
    // Lose: A Z, B X, C Y 0 points
    // Would need to check for bad input.
    public static int CalculateScoreForRound(string round)
    {
        int yourScore = 0;
        if (round.Contains("X")) yourScore += 1;
        else if (round.Contains("Y")) yourScore += 2;
        else if (round.Contains("Z")) yourScore += 3;
        // Winning
        if (round == "A Y" || round == "B Z" || round == "C X")
        {
            yourScore += 6;
        }
        // Drawing
        else if (round == "A X" || round == "B Y" || round == "C Z")
        {
            yourScore += 3;
        }
        return yourScore;
    }
}
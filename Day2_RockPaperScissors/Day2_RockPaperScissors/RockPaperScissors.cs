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

    // You score 1 point for X (rock), 2 points for Y (paper) and 3 points for Z (scissors)
    // Results
    // Win: A Y, B Z, C X 6 points
    // Draw: A X, B Y, C Z 3 points
    // Lose: A Z, B X, C Y 0 points
    // Would need to check for bad input.
    public static int CalculateIncorrectScoreForRound(string round)
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

    // You lose with X, draw with Y and win with Z
    // When you play: Rock = 1 point, Paper = 2 points, Scissors = 3 points
    // Your oponent plays: A = Rock, B = Paper, C = Scissors
    public static int CalculateScoreForRound(string round)
    {
        int yourScore = 0;
        string theirChoice = round.Substring(0, 1);
        // lose
        if (round.Contains("X"))
        {
            switch (theirChoice)
            {
                case "A":
                    yourScore += 3;
                    break;
                case "B":
                    yourScore += 1;
                    break;
                case "C":
                    yourScore += 2;
                    break;
            }
        }
        // draw
        else if (round.Contains("Y"))
        {
            switch (theirChoice)
            {
                case "A":
                    yourScore += 1;
                    break;
                case "B":
                    yourScore += 2;
                    break;
                case "C":
                    yourScore += 3;
                    break;
            }
            yourScore += 3;
        }
        // win
        else if (round.Contains("Z"))
        {
            switch (theirChoice)
            {
                case "A":
                    yourScore += 2;
                    break;
                case "B":
                    yourScore += 3;
                    break;
                case "C":
                    yourScore += 1;
                    break;
            }
            yourScore += 6;
        }
        return yourScore;
    }
}
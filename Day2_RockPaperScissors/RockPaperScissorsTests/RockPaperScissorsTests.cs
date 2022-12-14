using Day2_RockPaperScissors;

namespace RockPaperScissorsTests
{
    public class RockPaperScissorsTests
    {
        [TestCase("A Y", 8)]
        [TestCase("B X", 1)]
        [TestCase("C Z", 6)]
        public void GivenValidInput_CalculateRockPaperScissorsScore_ReturnsCorrectScore(string round, int expected)
        {
            Assert.That(RockPaperScissors.CalculateScoreForRound(round), Is.EqualTo(expected));
        }
    }
}
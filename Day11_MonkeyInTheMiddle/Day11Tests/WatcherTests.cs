namespace Day11Tests;

public class WatcherTests
{
    private readonly string[] monkeyStrings =
    {
        "0:\r\n" +
        "  Starting items: 79, 98\r\n" +
        "  Operation: new = old * 19\r\n" +
        "  Test: divisible by 23\r\n" +
        "    If true: throw to monkey 2\r\n" +
        "    If false: throw to monkey 3\r\n",
        "1:\r\n" +
        "  Starting items: 54, 65, 75, 74\r\n" +
        "  Operation: new = old + 6\r\n" +
        "  Test: divisible by 19\r\n" +
        "    If true: throw to monkey 2\r\n" +
        "    If false: throw to monkey 0\r\n",
        "2:\r\n" +
        "  Starting items: 79, 60, 97\r\n" +
        "  Operation: new = old * old\r\n" +
        "  Test: divisible by 13\r\n" +
        "    If true: throw to monkey 1\r\n" +
        "    If false: throw to monkey 3\r\n",
        "3:\r\n" +
        "  Starting items: 74\r\n" +
        "  Operation: new = old + 3\r\n" +
        "  Test: divisible by 17\r\n" +
        "    If true: throw to monkey 0\r\n" +
        "    If false: throw to monkey 1"
    };

    Watcher _sut;

    [SetUp]
    public void SetUp()
    {
        _sut = new Watcher(new MonkeyDeserialiser());
        foreach (string monkeyString in monkeyStrings)
        {
            _sut.AddMonkeyFromString(monkeyString);
        }
    }

    [Test]
    public void GivenAWatcherAndAMonkeyList_WhenTheMonkeysTake20Rounds_ThenTheyHaveCorrectMonkeyBusinessScores()
    {
        _sut.ObserveRounds(20);
        int[] actual = _sut.GetMonkeyBusiness();
        int[] expected = new int[] { 101, 95, 7, 105 };

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void GivenAWatcherAndAMonkeyList_WhenTheMonkeysTake10000RoundsWithoutRelief_ThenTheyHaveCorrectActivityScores()
    {
        _sut.ObserveRounds(10000, false);
        int[] actual = _sut.GetMonkeyBusiness();
        int[] expected = new int[] { 52166, 47830, 1938, 52013 };

        Assert.That(actual, Is.EqualTo(expected));
    }
}

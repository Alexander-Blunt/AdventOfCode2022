namespace Day11Tests;

public class ADeserialiser
{
    MonkeyDeserialiser _sut;

    [SetUp]
    public void SetUp()
    {
        _sut = new MonkeyDeserialiser();
    }

    [Test]
    public void DeserialisesStartingItems()
    {
        Queue<int> result = _sut.DeserialiseStartingItems("56, 56, 92, 65, 71, 61, 79");
        Queue<int> expected = new(new int[] { 56, 56, 92, 65, 71, 61, 79 });

        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCaseSource(nameof(OperationCases))]
    public void DeserialisesOperation(string opString, Func<int, int> expected)
    {
        Func<int, int> actual = _sut.DeserialiseOperation(opString);
        int actualResult = actual(5);
        int expectedResult = expected(5);

        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    public static object[] OperationCases =
    {
        new object[] { "new = old + 5", new Func<int, int>(wl => wl + 5) },
        new object[] { "new = old + old", new Func<int, int>(wl => wl + wl) },
        new object[] { "new = old * 5", new Func<int, int>(wl => wl * 5) },
        new object[] { "new = old * old", new Func<int, int>(wl => wl * wl) }
    };

    [TestCaseSource(nameof(TestCases))]
    public void DeserialisesTest(string opString, Func<int, bool> expected)
    {
        Func<int, bool> actual = _sut.DeserialiseTest(opString);
        bool expectedResult = expected(23);
        bool actualResult = actual(23);

        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    public static object[] TestCases =
    {
        new object[] { "divisible by 23", new Func<int, bool>(i => i % 23 == 0) },
        new object[] { "divisible by 13", new Func<int, bool>(i => i % 13 == 0) },
    };
}

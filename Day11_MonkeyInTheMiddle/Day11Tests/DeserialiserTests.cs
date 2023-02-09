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

    [TestCaseSource(nameof(DeserialiseCases))]
    public void DeserialisesOperation(string opString, Func<int, int> expected)
    {
        Func<int, int> result = _sut.DeserialiseOperation(opString);
        int actualOut = result(5);
        int expectedOut = expected(5);

        Assert.That(actualOut, Is.EqualTo(expectedOut));
    }

    public static object[] DeserialiseCases =
    {
        new object[] { "new = old + 5", new Func<int, int>(wl => wl + 5) },
        new object[] { "new = old + old", new Func<int, int>(wl => wl + wl) },
        new object[] { "new = old * 5", new Func<int, int>(wl => wl * 5) },
        new object[] { "new = old * old", new Func<int, int>(wl => wl * wl) }
    };
}

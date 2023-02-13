using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;
using System.Security.Cryptography;

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
        Queue<long> result = _sut.DeserialiseStartingItems("56, 56, 92, 65, 71, 61, 79");
        Queue<long> expected = new(new long[] { 56, 56, 92, 65, 71, 61, 79 });

        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCaseSource(nameof(MonkeyCases))]
    public void DeserialisesAMonkey(string monkeyString, Monkey expected)
    {
        Monkey actual = _sut.DeserialiseMonkey(monkeyString);

        Assert.That(actual, Is.EqualTo(expected));
    }

    public static object[] MonkeyCases =
    {
        new object[] {
            "0:\r\n" +
            "  Starting items: 79, 98\r\n" +
            "  Operation: new = old * 19\r\n" +
            "  Test: divisible by 23\r\n" +
            "    If true: throw to monkey 2\r\n" +
            "    If false: throw to monkey 3" ,

            new Monkey(
            new Queue<long>(new long[] { 79, 98 }),
            "new = old * 19",
            "divisible by 23",
            2,
            3
            )}
    };
}

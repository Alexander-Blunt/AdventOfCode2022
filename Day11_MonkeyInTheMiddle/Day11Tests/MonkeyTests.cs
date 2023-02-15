namespace Day11Tests;

public class GivenAMonkey
{
    [TestCaseSource(nameof(OperateCases))]
    public void WhenOperateOnIsCalled_CorrectOperationIsPerformed(string operation, long input, long expected)
    {
        Monkey sut = new Monkey(
                new Queue<long>(),
                operation,
                5,
                1,
                2);
        long actual = sut.Inspect(input);

        Assert.That(actual, Is.EqualTo(expected));
    }

    public static object[] OperateCases =
    {
        new object[] { "new = old * old", 5, 25 },
        new object[] { "new = old + 5", 5, 10 },
        new object[] { "new = old * 5", 5, 25 },
    };

    [TestCase(10, true)]
    [TestCase(7, false)]
    public void WhenTestIsCalled_CorrectOperationIsPerformed(int input, bool expected)
    {
        Monkey sut = new Monkey(new Queue<long>(), "new = old * old", 5, 0, 0);
        bool actual = sut.Test(input);

        Assert.That(actual, Is.EqualTo(expected));
    }
}
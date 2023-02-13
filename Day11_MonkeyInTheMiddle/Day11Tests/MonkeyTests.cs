namespace Day11Tests;

public class GivenAMonkey
{
    [TestCaseSource(nameof(OperateCases))]
    public void WhenOperateOnIsCalled_CorrectOperationIsPerformed(Monkey sut, int input, int expected)
    {
        int actual = sut.OperateOn(input);

        Assert.That(actual, Is.EqualTo(expected));
    }

    public static object[] OperateCases =
    {
        new object[]
        {
            new Monkey(
                new Queue<int>(),
                "new = old * old",
                "divisible by 5",
                1,
                2),
            5, 25
        },
        new object[]
        {
            new Monkey(
                null,
                "new = old + 5",
                "divisible by 5",
                0,
                0),
            5, 10
        },
        new object[]
        {
            new Monkey(
                null,
                "new = old * 5",
                "divisible by 5",
                0,
                0),
            2, 10
        }
    };

    [TestCase(10, true)]
    [TestCase(7, false)]
    public void WhenTestIsCalled_CorrectOperationIsPerformed(int input, bool expected)
    {
        Monkey sut = new Monkey(new Queue<int>(), "new = old * old", "divisible by 5", 0, 0);
        bool actual = sut.Test(input);

        Assert.That(actual, Is.EqualTo(expected));
    }
}
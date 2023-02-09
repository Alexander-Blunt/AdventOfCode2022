namespace Day11Tests;

public class GivenAMonkey
{
    Monkey _sut;
    Monkey _trueReceiver;
    Monkey _falseReceiver;
    [SetUp]
    public void Setup()
    {
        _trueReceiver = new Monkey(new Queue<int>(), null, null, null, null);
        _falseReceiver = new Monkey(new Queue<int>(), null, null, null, null);

        _sut = new Monkey(
            new Queue<int>(),
            wl => wl * wl,
            wl => wl % 13 == 0,
            _trueReceiver,
            _falseReceiver
            );
    }

    [Test]
    public void WithAnItemThatWillTestTrue_WhenTheMonkeyTakesATurn_ThenTrueReceiverReceivesItem()
    {
        _sut.Items = new Queue<int>(new int[] { 79 });
        Queue<int> expected = new(new int[] { 2080 });
        _sut.TakeTurn();

        Assert.That(_trueReceiver.Items, Is.EqualTo(expected));
    }

    [Test]
    public void WithAnItemThatWillTestFalse_WhenTheMonkeyTakesATurn_ThenFalseReceiverReceivesItem()
    {
        _sut.Items = new Queue<int>(new int[] { 60 });
        Queue<int> expected = new(new int[] { 1200 });
        _sut.TakeTurn();

        Assert.That(_falseReceiver.Items, Is.EqualTo(expected));
    }
}
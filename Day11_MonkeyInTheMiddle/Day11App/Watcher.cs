namespace Day11App;

public class Watcher
{
    private MonkeyDeserialiser _deserialiser;

    public Watcher(MonkeyDeserialiser monkeyDeserialiser)
    {
        _deserialiser = monkeyDeserialiser;
        MonkeyList = new();
    }

    public List<Monkey> MonkeyList { get; private set; }
    private int _monkeyDivisorProduct = 1;

    public void AddMonkeyFromString(string monkeyString)
    {
        Monkey monkey = _deserialiser.DeserialiseMonkey(monkeyString);
        _monkeyDivisorProduct *= monkey.TestDivisor;
        MonkeyList.Add(monkey);
        monkey.AddWatcher(this);
    }

    public int[] GetMonkeyBusiness()
    {
        return MonkeyList.Select(m => m.Business).ToArray();
    }

    public void ObserveRound(bool relief = true)
    {
        foreach (Monkey monkey in MonkeyList)
        {
            if (relief) monkey.TakeDiv3Turn();
            else monkey.TakeTurnWithOverflowCheck(_monkeyDivisorProduct);
        }
    }

    public void ObserveRounds(int numRounds, bool relief = true)
    {
        for (int i = 0; i < numRounds; i++)
        {
            ObserveRound(relief);
        }
    }

    internal void ProcessThrow(int target, long worryLevel)
    {
        MonkeyList[target].Catch(worryLevel);
    }
}

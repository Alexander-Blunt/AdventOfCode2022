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

    public void AddMonkeyFromString(string monkeyString)
    {
        Monkey monkey = _deserialiser.DeserialiseMonkey(monkeyString);
        MonkeyList.Add(monkey);
        monkey.AddWatcher(this);
    }

    public int[] GetMonkeyBusiness()
    {
        return MonkeyList.Select(m => m.Business).ToArray();
    }

    public void ObserveRound()
    {
        foreach (Monkey monkey in MonkeyList)
        {
            monkey.TakeTurn();
        }
    }

    public void ObserveRounds(int numRounds)
    {
        for (int i = 0; i < numRounds; i++)
        {
            ObserveRound();
        }
    }

    internal void ProcessThrow(int target, long worryLevel)
    {
        MonkeyList[target].Catch(worryLevel);
    }
}

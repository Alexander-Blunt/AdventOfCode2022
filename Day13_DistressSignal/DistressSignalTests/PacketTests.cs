using DistressSignalApp;
namespace DistressSignalTests;

public class PacketTests
{
    [SetUp]
    public void Setup()
    {
    }

    [TestCaseSource(nameof(CompareSource))]
    public void Compare_CorrectlyComparesPackets(Packet left, Packet right, bool expected)
    {

        bool actual = Packet.Compare(left, right);
        Assert.Pass();
    }

    // Pairs copied from examples on AoC day 13
    public static object[] CompareSource =
    {
        new object[] // Pair 1
        {
            new Packet (new object[] {1, 1, 3, 1, 1}),
            new Packet (new object[] { 1, 1, 5, 1, 1 }),
            true
        },
        new object[] // Pair 2
        {
            new Packet (new object[] { new object[] { 1 }, new object[] { 2, 3, 4 } }),
            new Packet (new object[] { new object[] { 1 }, 4 }),
            true
        },
        new object[] // Pair 3
        {
            new Packet (new object[] { 9 }),
            new Packet (new object[] { new object[] { 8, 7, 6 } }),
            false
        },
        new object[] // Pair 4
        {
            new Packet (new object[] { new object[] { 4, 4 }, 4, 4 }),
            new Packet (new object[] { new object[] { 4, 4 }, 4, 4, 4 }),
            true
        },
        new object[] // Pair 5
        {
            new Packet (new object[] { 7, 7, 7, 7 }),
            new Packet (new object[] { 7, 7, 7 }),
            false
        },
        new object[] // Pair 6
        {
            new Packet (new object[] { }),
            new Packet (new object[] { 3 }),
            true
        },
        new object[] // Pair 7
        {
            new Packet (new object[] { new object[] { new object[] { } } }),
            new Packet (new object[] { new object[] { } }),
            false
        },
        new object[] // Pair 8
        {
            new Packet (new object[] { 1, new object[] { 2, new object[] { 3, new object[] { 4, new object[] { 5, 6, 7 } } } }, 8, 9 }),
            new Packet (new object[] { 1, new object[] { 2, new object[] { 3, new object[] { 4, new object[] { 5, 6, 0 } } } }, 8, 9 }),
            false
        }
    };
}
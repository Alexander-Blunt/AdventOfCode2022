using TuningTrouble;

namespace TuningTroubleTests
{
    public class CommunicationSystemTests
    {
        [TestCase("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 7)]
        [TestCase("bvwbjplbgvbhsrlpgdmjqwftvncz", 5)]
        [TestCase("nppdvjthqldpwncqszvftbrmjlhg", 6)]
        [TestCase("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 10)]
        [TestCase("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 11)]
        public void GivenADatastreamBuffer_FindStartOfPacket_ReturnsStartOfPacketLocation(string datastreamBuffer, int expectedStartOfPacket)
        {
            //Act
            int actualStartOfPacket = CommunicationSystem.FindStartOfPacket(datastreamBuffer);

            //Assert
            Assert.That(actualStartOfPacket, Is.EqualTo(expectedStartOfPacket));
        }

        [TestCase("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 19)]
        [TestCase("bvwbjplbgvbhsrlpgdmjqwftvncz", 23)]
        [TestCase("nppdvjthqldpwncqszvftbrmjlhg", 23)]
        [TestCase("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 29)]
        [TestCase("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 26)]
        public void GivenADatastreamBuffer_FindStartOfMessage_ReturnsStartOfPacketLocation(string datastreamBuffer, int expectedStartOfPacket)
        {
            //Act
            int actualStartOfPacket = CommunicationSystem.FindStartOfMessage(datastreamBuffer);

            //Assert
            Assert.That(actualStartOfPacket, Is.EqualTo(expectedStartOfPacket));
        }
    }
}
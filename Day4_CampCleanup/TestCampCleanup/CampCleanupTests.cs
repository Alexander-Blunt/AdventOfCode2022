using Camp;

namespace TestCampCleanup
{
    class CampCleanupTests
    {
        [TestCase("2-4,6-8", false)]
        [TestCase("2-3,4-5", false)]
        [TestCase("5-7,7-9", false)]
        [TestCase("2-8,3-7", true)]
        [TestCase("6-6,4-6", true)]
        [TestCase("2-6,4-8", false)]
        public void GivenValidInput_OneAssignmentFullyContainsTheOther_ReturnsCorrectValue(string assignmentPair, bool expected)
        {
            Assert.That(Cleanup.OneAssignmentFullyContainsTheOther(assignmentPair), Is.EqualTo(expected));
        }
    }
}
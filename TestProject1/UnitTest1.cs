using FancingClubManagementSystemProject.Service;

namespace TestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1_getPasswordByLogin()
        {
            var fs = new FensingService();
            string var = fs.getPasswordByLogin("0");

            Assert.That(var, Is.EqualTo("0"));
        }
    }


}
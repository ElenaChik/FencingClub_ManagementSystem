using FancingClubManagementSystemProject.DAO;
using FancingClubManagementSystemProject.Service;
using System.Numerics;

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


        [Test]
        public void Test2_isValidLogin()
        {
            var fs = new FensingService();
            Boolean var = fs.isLoginValid("0", "0");

            Assert.That(var, Is.True);
        }

        [Test]
        public void Test3_isValidLogin()
        {
            var fs = new FensingService();
            Boolean var = fs.isLoginValid("0", "1");

            Assert.That(var, Is.False);
        }
    }
}
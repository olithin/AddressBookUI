using NUnit.Framework;

namespace AddressbookWebTests
{
    [TestFixture]
    public class AuthTestBase : TestBase
    {
        [SetUp]
        public void SetupLogIn()
        {
            app.Auth.Login(new AccountData("admin", "secret"));
        }

    }
}
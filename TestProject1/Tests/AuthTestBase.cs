using NUnit.Framework;

namespace AddressbookWebTests
{
    public class AuthTestBase : TestBase
    {
        [SetUp]
        public void SetupLogIn()
        {
            app.Auth.Login(new AccountData("admin", "secret"));
        }

    }
}
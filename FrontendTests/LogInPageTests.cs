using BaseSetup.Browser;
using NUnit.Framework;
using TestBase;
using UiEntities.PageExtensions;
using UiEntities.Pages;

namespace FrontendTests
{
    [TestFixture]
    public class LogInPageTests : UiTestBase
    {
        private readonly string username = "user@phptravels.com";
        private readonly string password = "demouser";

        [Test]
        public void LogInToHomePage()
        {
            Driver
                .GoToPage<LogInPage>()
                .LogIn(username, password);
        }
    }
}

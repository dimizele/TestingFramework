using BaseUiSetup.DriverExtensions;
using BaseUiSetup.UpgradedSelenium;
using NUnit.Framework;

namespace TestBase
{
    public class UiTestBase : TestBase
    {
        public UpWebDriver Driver { get; set; }

        [SetUp]
        public override void SetUp()
        {
            DriverInit();
            BeforeEach();
        }

        [TearDown]
        public override void TearDown()
        {
            AfterEach();
            DriverDispose();
        }

        public void DriverInit()
        {
            Driver = new DriverFactory().CreateChromeDriver();
        }

        public void DriverDispose()
        {
            Driver.Dispose();
        }
    }
}

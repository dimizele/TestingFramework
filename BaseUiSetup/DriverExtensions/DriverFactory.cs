using System;
using BaseUiSetup.UpgradedSelenium;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace BaseUiSetup.DriverExtensions
{
    public class DriverFactory
    {
        public UpWebDriver Driver { get; set; }

        public UpWebDriver CreateChromeDriver(bool waitForAngular = false)
        {
            IWebDriver driver = new ChromeDriver();
            Driver = new UpWebDriver(driver);

            Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Driver.Manage().Window.Maximize();
            Driver.WaitForAngularCalls = waitForAngular;

            return Driver;
        }
    }
}

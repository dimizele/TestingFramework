using BaseUiSetup.UpgradedSelenium;
using BaseUiSetup.BasePage;
using OpenQA.Selenium;

namespace UiEntities.Pages
{
    public class LogInPage : BasePage
    {
        public UpWebElement Username => Driver.FindElement(By.Name("username"));

        public UpWebElement Password => Driver.FindElement(By.Name("password"));

        public UpWebElement LogInButton => Driver.FindElement(By.CssSelector(".loginbtn"));


        public override string pageUrl { get; set; } = "https://www.phptravels.net/login";
    }
}

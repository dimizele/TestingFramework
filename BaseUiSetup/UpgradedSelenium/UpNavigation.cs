using OpenQA.Selenium;
using System;

namespace BaseUiSetup.UpgradedSelenium
{
    public class UpNavigation : INavigation
    {
        private UpWebDriver upDriver;
        private INavigation navigation;

        public UpNavigation(UpWebDriver upDriver, INavigation navigation)
        {
            this.upDriver = upDriver;
            this.navigation = navigation;
        }

        public void Back()
        {
            navigation.Back();
            upDriver.WaitForPageReady();
        }

        public void Forward()
        {
            navigation.Forward();
            upDriver.WaitForPageReady();
        }

        public void GoToUrl(string url)
        {
            navigation.GoToUrl(url);
            upDriver.WaitForPageReady();
        }

        public void GoToUrl(Uri url)
        {
            navigation.GoToUrl(url);
            upDriver.WaitForPageReady();
        }

        public void Refresh()
        {
            navigation.Refresh();
            upDriver.WaitForPageReady();
        }
    }
}

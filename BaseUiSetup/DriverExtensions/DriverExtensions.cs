using System;
using System.Collections.Generic;
using System.Text;
using BaseUiSetup.BasePage;
using BaseUiSetup.UpgradedSelenium;
using OpenQA.Selenium;

namespace BaseSetup.Browser
{
    public static class BrowserExtensionMethods
    {
        public static T GoToPage<T>(this UpWebDriver driver) where T : BasePage, new()
        {
            var page = new T { Driver = driver };

            page.Driver.Navigate().GoToUrl(page.Url);

            return page;
        }
    }
}

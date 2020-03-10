using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;

namespace BaseUiSetup.UpgradedSelenium
{
    public class UpWebDriver : IWrapsDriver
    {
        protected const string bootstrapDefer = "NG_DEFER_BOOTSTRAP!";
        protected IWebDriver driver;
        protected IJavaScriptExecutor jsExe;
        protected string rootElement;

        public UpWebDriver(IWebDriver driver) : this(driver, "body")
        {

        }

        public UpWebDriver(IWebDriver driver, string rootElement)
        {
            this.driver = driver;
            jsExe = (IJavaScriptExecutor)driver;
            this.rootElement = rootElement;
        }

        public IWebDriver WrappedDriver => driver;

        public bool WaitForAngularCalls { get; set; }

        public string PageSource
        {
            get
            {
                WaitForAngular();
                return driver.PageSource;
            }
        }

        public string Title
        {
            get
            {
                WaitForAngular();
                return driver.Title;
            }
        }

        public string Url
        {
            get
            {
                WaitForAngular();
                return driver.Url;
            }
            set
            {
                driver.Url = "about:blank";
                jsExe.ExecuteScript($"window.name += '{bootstrapDefer}'; window.location.href = '{value}';");
                jsExe.ExecuteScript(JavaScriptScripts.JavaScriptScripts.ResumeAngularBootstrap);
            }
        }

        public string CurrentWindowHandle
        {
            get
            {
                return driver.CurrentWindowHandle;
            }
        }

        public ReadOnlyCollection<string> WindowHandles
        {
            get
            {
                return driver.WindowHandles;
            }
        }

        public void Close()
        {
            driver.Close();
        }

        public void Dispose()
        {
            driver.Dispose();
        }

        public UpWebElement FindElement(By by)
        {
            WaitForPageReady();
            return new UpWebElement(this, driver.FindElement(by));
        }

        public ReadOnlyCollection<UpWebElement> FindElements(By by)
        {
            WaitForPageReady();
            return new ReadOnlyCollection<UpWebElement>(driver.FindElements(by).Select(el => new UpWebElement(this, el)).ToList());
        }

        public IOptions Manage()
        {
            return driver.Manage();
        }

        public INavigation Navigate()
        {
            return new UpNavigation(this, driver.Navigate());
        }

        public void Quit()
        {
            driver.Quit();
        }

        public ITargetLocator SwitchTo()
        {
            return driver.SwitchTo();
        }

        public void WaitForAngular()
        {
            if (WaitForAngularCalls) jsExe.ExecuteAsyncScript(JavaScriptScripts.JavaScriptScripts.WaitForAngular, rootElement);
        }

        public void WaitForDocumentState()
        {
            for (int i = 0; i < 30; i++)
            {
                string documentReady = (driver as IJavaScriptExecutor).ExecuteScript("return document.readyState") as string;
                if (!documentReady.Equals("complete"))
                {
                    Thread.Sleep(1000);
                }
            }
        }

        public void WaitForjQuery()
        {
            if (!WaitForAngularCalls) return;
            for (int i = 0; i < 30; i++)
            {
                bool noOutstandingjQueryCalls = (bool)(driver as IJavaScriptExecutor).ExecuteScript("return jQuery.active == 0");
                if (!noOutstandingjQueryCalls)
                {
                    Thread.Sleep(1000);
                }
            }
        }

        public void WaitForPageReady()
        {
            WaitForDocumentState();
            WaitForjQuery();
            WaitForAngular();
        }
    }
}

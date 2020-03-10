using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Internal;

namespace BaseUiSetup.UpgradedSelenium
{
    public class UpWebElement : IWrapsElement
    {
        protected UpWebDriver upDriver;
        protected IWebElement element;


        public UpWebElement(UpWebDriver driver, IWebElement element)
        {
            this.upDriver = driver;
            this.element = element;
        }

        public UpWebElement(UpWebDriver driver, By elementLocator)
        {
            this.upDriver = driver;
            this.element = upDriver.FindElement(elementLocator).element;
        }

        public UpWebDriver UpDriver
        {
            get
            {
                return upDriver;
            }
        }

        public IWebElement WrappedElement
        {
            get { return element; }
        }

        public UpWebElement FindElement(By by)
        {
            upDriver.WaitForPageReady();
            return new UpWebElement(upDriver, element.FindElement(by));
        }

        public ReadOnlyCollection<UpWebElement> FindElements(By by)
        {
            upDriver.WaitForPageReady();
            return new ReadOnlyCollection<UpWebElement>(element.FindElements(by).Select(el => new UpWebElement(upDriver, el)).ToList());
        }

        public UpWebElement Clear()
        {
            upDriver.WaitForPageReady();
            element.Clear();

            return this;
        }

        public UpWebElement SendKeys(string text)
        {
            upDriver.WaitForPageReady();
            element.SendKeys(text);

            return this;
        }

        public UpWebElement Submit()
        {
            upDriver.WaitForPageReady();
            element.Submit();

            return this;
        }

        public UpWebElement Click()
        {
            upDriver.WaitForPageReady();
            element.Click();

            return this;
        }

        public string GetAttribute(string attributeName)
        {
            upDriver.WaitForPageReady();
            return element.GetAttribute(attributeName);
        }

        public string GetProperty(string propertyName)
        {
            upDriver.WaitForPageReady();
            return element.GetProperty(propertyName);
        }

        public string GetCssValue(string propertyName)
        {
            upDriver.WaitForPageReady();
            return element.GetCssValue(propertyName);
        }

        public string TagName
        {
            get
            {
                upDriver.WaitForPageReady();
                return element.TagName;
            }
        }

        public string Text
        {
            get
            {
                upDriver.WaitForPageReady();
                return element.Text;
            }
        }

        public bool Enabled
        {
            get
            {
                upDriver.WaitForPageReady();
                return element.Enabled;
            }
        }

        public bool Selected
        {
            get
            {
                upDriver.WaitForPageReady();
                return element.Selected;
            }
        }

        public Point Location
        {
            get
            {
                upDriver.WaitForPageReady();
                return element.Location;
            }
        }

        public Size Size
        {
            get
            {
                upDriver.WaitForPageReady();
                return element.Size;
            }
        }

        public bool Displayed
        {
            get
            {
                upDriver.WaitForPageReady();
                return element.Displayed;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace BaseUiSetup.UpgradedSelenium
{
    public class UpBy : By
    {
        public static By AttributeValue(string tagName, string attributeName, string attributeValue)
        {
            return CssSelector($"{tagName}[{attributeName}='{attributeValue}']");
        }
    }
}

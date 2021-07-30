using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns.Utils
{
    public static class Extensions
    {
        public static void WaitAndClick(this IWebElement element)
        {
            Wait.GetWait().Until(WaitConditions.ElementToBoClickable(element)).Click();
        }

        public static void WaitAndSendKeys(this IWebElement element, string input)
        {
            Wait.GetWait().Until(WaitConditions.ElementDisplayed(element)).SendKeys(input);
        }
    }
}

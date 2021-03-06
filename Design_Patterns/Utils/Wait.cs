using Design_Patterns.WebDriver;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns.Utils
{
    public static class Wait
    {
        public static WebDriverWait GetWait()
        {
            WebDriverWait wait = new WebDriverWait(Browser.Instance.GetDriver(), new TimeSpan(0, 0, 30))
            {
                PollingInterval = TimeSpan.FromMilliseconds(700)
            };
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException),
                typeof(StaleElementReferenceException));

            return wait;
        }
    }
}

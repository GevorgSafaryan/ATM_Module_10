using Design_Patterns.PageObjects;
using Design_Patterns.WebDriver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns.Controlers
{
    public abstract class BaseControler : BasePage
    {
        protected By rootLocator;
        protected IWebDriver driver;

        public BaseControler(By locator)
        {
            rootLocator = locator;
            driver = Browser.Instance.GetDriver();
        }
    }
}

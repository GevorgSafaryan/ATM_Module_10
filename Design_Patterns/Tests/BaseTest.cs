using Design_Patterns.WebDriver;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns.Tests
{
    public class BaseTest
    {
        protected static Browser Instance;
        [SetUp]
        public void Setup()
        {
            Instance = Browser.Instance;
            Browser.Instance.Navigate(Configuration.URL);
        }

        [TearDown]
        public void CleanUp()
        {
            Browser.Instance.Quit();
        }
    }
}

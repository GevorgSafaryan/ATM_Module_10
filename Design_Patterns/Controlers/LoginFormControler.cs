using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Design_Patterns.Utils;
using OpenQA.Selenium.Support.UI;

namespace Design_Patterns.Controlers
{
    public class LoginFormControler : BaseControler
    {
        private readonly By loginFieldLocator = By.XPath(".//input[@name = 'login']");
        private readonly By enterPasswordButtonLocator = By.XPath(".//button[@data-testid= 'enter-password']");
        private readonly By passwordFieldLocator = By.XPath(".//input[@name= 'password']");
        private readonly By enterButtonLocator = By.XPath(".//button[@data-testid= 'login-to-mail']");
        private readonly By domainsListLocator = By.XPath(".//select[@name = 'domain']");
        public LoginFormControler(By locator) : base(locator)
        {

        }

        public void EnterLogin(string login)
        {
            driver.FindElement(rootLocator).FindElement(loginFieldLocator).WaitAndSendKeys(login);
        }

        public void ClickOnEnterPasswordButton()
        {
            driver.FindElement(rootLocator).FindElement(enterPasswordButtonLocator).WaitAndClick();
        }

        public void EnterPassword(string password)
        {
            driver.FindElement(rootLocator).FindElement(passwordFieldLocator).WaitAndSendKeys(password);
        }

        public void ClickOnEnterButton()
        {
            driver.FindElement(rootLocator).FindElement(enterButtonLocator).WaitAndClick();
        }

        public void Login(string login, string password)
        {
            EnterLogin(login);
            ClickOnEnterPasswordButton();
            EnterPassword(password);
            ClickOnEnterButton();
        }

        public void SelectDomain(string domain)
        {
            IWebElement domainsList = driver.FindElement(rootLocator).FindElement(domainsListLocator);
            SelectElement domains = new SelectElement(domainsList);
            switch (domain)
            {
                case "mail.ru":
                    domains.SelectByIndex(0);
                    break;
                case "inbox.ru":
                    domains.SelectByIndex(1);
                    break;
                case "list.ru":
                    domains.SelectByIndex(2);
                    break;
                case "bk.ru":
                    domains.SelectByIndex(3);
                    break;
                case "internet.ru":
                    domains.SelectByIndex(4);
                    break;
                default:
                    domains.SelectByIndex(0);
                    break;
            }
        }
    }
}

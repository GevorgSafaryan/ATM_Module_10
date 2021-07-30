using Design_Patterns.Controlers;
using Design_Patterns.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns.PageObjects
{
    public class HomePage : BasePage
    {
        private static readonly string homePageTitle = "Mail.ru: почта, поиск в интернете, новости, игры";
        private readonly WebElement loginField = new WebElement(By.XPath("//input[@name = 'login']"));
        private readonly WebElement enterPasswordButton = new WebElement(By.XPath("//button[@data-testid= 'enter-password']"));
        private readonly WebElement passwordField = new WebElement(By.XPath("//input[@name= 'password']"));
        private readonly WebElement enterButton = new WebElement(By.XPath("//button[@data-testid= 'login-to-mail']"));
        private readonly WebElement createAccountButton = new WebElement(By.XPath("//a[@href = '//account.mail.ru/signup?from=main&rf=auth.mail.ru&app_id_mytracker=52848']"));
        private readonly WebElement errorMessage = new WebElement(By.XPath("//div[@class = 'error svelte-1eyrl7y']"));
        private readonly WebElement domainsList = new WebElement(By.Name("domain"));

        public HomePage() : base(homePageTitle)
        {

        }

        public LoginFormControler LoginFormControler = new LoginFormControler(By.XPath("//form[@data-testid = 'logged-out-form']"));

        public bool VerifySuccessfullLogout()
        {
            return wait.Until(WaitConditions.IsElementDisplayed(createAccountButton.GetElement()));
        }

        public bool VerifyErrorMessage(string message)
        {
            return errorMessage.GetText().Equals(message);
        }
    }
}

using Design_Patterns.WebDriver;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Design_Patterns.PageObjects
{
    public class EmailContentPage : BasePage
    {
        private static readonly WebElement mainFrame = new WebElement(By.XPath("//div[@class = 'application-mail__layout application-mail__layout_main']//div[@class = 'layout__main-frame']"));
        private static int emailsCount;
        private readonly WebElement firstemail = new WebElement(By.XPath("(//a[@class = 'llct js-letter-list-item'])[1]"));
        private readonly WebElement sentEmailsSubject = new WebElement(By.XPath("//h2[@class = 'thread__subject']"));
        private readonly WebElement sentEmailsRecipient = new WebElement(By.XPath("(//span[@class = 'letter-contact'])[2]"));
        private readonly WebElement sentEmailsBody = new WebElement(By.XPath("//div[@data-signature-widget= 'container']/../div[1]"));
        private readonly WebElement trashFolder = new WebElement(By.XPath("//div[@class = 'nav__folder-clear']"));
        private readonly WebElement draftsFolder = new WebElement(By.XPath("//a[@href = '/drafts/']"));
        private readonly WebElement sentFolder = new WebElement(By.XPath("//a[@href = '/sent/']"));
        private readonly WebElement checkbox = new WebElement(By.XPath("(//div[@class = 'checkbox__box checkbox__box_disabled'])[1]"));

        public EmailContentPage() : base(mainFrame)
        {

        }

        public void OpenEnEmailFromTheListById(int emailID)
        {
            int.TryParse(Regex.Match(draftsFolder.GetAttribute("title"), @"\d+").Value, out emailsCount);
            firstemail.Click();
        }

        public void DeleteEmailsByDragAndDrop()
        {
            int.TryParse(Regex.Match(draftsFolder.GetAttribute("title"), @"\d+").Value, out emailsCount);
            Actions actions = new Actions(Browser.Instance.GetDriver());
            actions.DragAndDrop(firstemail.GetElement(), trashFolder.GetElement()).Perform();
            //actions.ClickAndHold(firstemail.GetElement()).MoveToElement(trashFolder.GetElement()).Release(sentFolder.GetElement()).Build().Perform();
        }

        public bool VerifyThatEmailDisappearsFromDraftsFolder()
        {
            Browser.Instance.Refresh();
            int.TryParse(Regex.Match(draftsFolder.GetAttribute("title"), @"\d+").Value, out int emailsCountAfter);
            return emailsCountAfter == 0 || emailsCountAfter == emailsCount - 1;
        }

        public bool VerifySentEmailsContent(string recipient, string subject, string bodyText)
        {
            bool assertRecipient = sentEmailsRecipient.GetAttribute("title").Equals(recipient);
            bool assertSubject = sentEmailsSubject.GetText().Equals(subject);
            bool assertBody = sentEmailsBody.GetText().Contains(bodyText);
            return assertRecipient && assertSubject && assertBody;
        }
    }
}

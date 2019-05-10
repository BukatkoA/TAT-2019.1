using Dev9;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DevTask9Tests
{
    [TestFixture]
    public class MailLoginTests
    {
        private IWebDriver Driver { get; set; }

        [SetUp]
        public void OpenBrowser()
        {
            this.Driver = new ChromeDriver();
            this.Driver.Navigate().GoToUrl("https://mail.ru");
        }

        [TestCase("mailexampleq@mail.ru", "Qwerty123qq")]
        public void Login_CorrectInput_ElementDisplayed(string login, string password)
        {
            MailRuAccount mailPage = new MailRuAccount(this.Driver);
            mailPage.LogInPage(login, password);
            Assert.IsTrue(this.Driver.FindElement(By.XPath("//span[contains(text(), 'Написать письмо')]"), 3).Displayed);
        }

        [TestCase("pochta", "parol")]
        [TestCase("", "")]
        [TestCase("pochta", "")]
        [TestCase("", "parol")]
        public void Login_IncorrectInput_ErrorDisplayed(string login, string password)
        {
            MailRuAccount mailPage = new MailRuAccount(this.Driver);
            mailPage.LogInPage(login, password);
            Assert.IsTrue(this.Driver.FindElement(By.XPath("//div[@id = 'mailbox:error' and (contains(text(), 'имя') or contains(text(), 'пароль'))]"), 3).Displayed);
        }

        [TearDown]
        public void CloseBrowser()
        {
            this.Driver.Quit();
        }
    }
}
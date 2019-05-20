namespace Dev9
{
    /// <summary>
    /// Class has locators for each page of mail.
    /// </summary>
    public class MailRuLocators
    {
        /// <summary>
        /// Class has locators for login page.
        /// </summary>
        public class LoginPageLocator
        {
            public string PageLocator { get; } = "https://mail.ru/";
            public string LoginLocator { get; } = "//input[@id = 'mailbox:login']";
            public string PasswordLocator { get; } = "//input[@id = 'mailbox:password']";
            public string LoginButtonLocator { get; } = "//label[@id = 'mailbox:submit']";
        }

        /// <summary>
        /// Class has locators for main page.
        /// </summary>
        public class MainMailRuPage
        {
            public string WriteMessageLocator { get; } = "//span[contains(text(), 'Написать письмо')]";
        }

        /// <summary>
        /// Class has locators for write letter page.
        /// </summary>
        public class SendMessageToGoogle
        {
            public string SendToLocator { get; } = "//textarea[@class = 'js-input compose__labels__input']";
            public string MessageBoxLocator { get; } = "//body[@id = 'tinymce']";
            public string MessageBoxEnterLocator { get; } = "//span[@class = 'b-dropdown__list__item__tick']";
            public string SendButtonLocator { get; } = "//div[@class = 'b-toolbar__btn b-toolbar__btn_ b-toolbar__btn_false js-shortcut']";
        }
    }
}
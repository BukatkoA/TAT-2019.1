namespace Dev9
{
    /// <summary>
    /// Class has locators for each page of mail.
    /// </summary>
    public class GoogleLocators
    {
        /// <summary>
        /// Class has locators for login page.
        /// </summary>
        public class LoginPageLocator
        {
            public string PageLocator { get; } = "http://gmail.com/";
            public string LoginLocator { get; } = "//input[@name = 'identifier']";
            public string PasswordLocator { get; } = "//input[@name = 'password']";
            public string LoginButtonLocator { get; } = "//content[@class= 'CwaK9']";
        }

        /// <summary>
        /// Class has locators for main page.
        /// </summary>
        public class MainGooglePage
        {
            public string WriteMessageLocator { get; } = "//div[@class = 'T-I J-J5-Ji T-I-KE L3']";
        }

        /// <summary>
        /// Class has locators for write letter page.
        /// </summary>
        public class SendMessageToMailRu
        {
            public string SendToLocator { get; } = "//textarea[@name = 'to']";
            public string MessageBoxLocator { get; } = "//div[@id= ':9a']";
            public string SendButtonLocator { get; } = "//div[@id= ':7v']";
        }

        /*/// <summary>
        /// Class has locators for letter page.
        /// </summary>
        public class Recipient
        {
            public string PageLocator { get; } = "http://gmail.com/";
        }

        /// <summary>
        /// Class has locators for setting page.
        /// </summary>
        public class SettingsPage
        {

        }*/
    }
}
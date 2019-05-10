using System;

namespace Dev9
{
    /// <summary>
    /// Entry point to the programm
    /// </summary>
    class EntryPoint
    {
        /// <summary>
        /// Entry point to the programm
        /// </summary>
        static void Main()
        {
            try
            {
                var googleAccount = new GoogleAccount();
                googleAccount.GoToUrl();
                googleAccount.LogInPage("gogogomoro123@gmail.com", "Qwerty123qq");
                /*.Finder()
                .SenderMessage("mailexampleq@mail.ru", "Hi");*/
                /*var mailRuAccount = new MailRuAccount();
                mailRuAccount.GoToUrl();
                mailRuAccount.LogInPage("mailexampleq@mail.ru", "Qwerty123qq")
                             .Finder()
                             .SenderMessage("gogogomoro123@gmail.com", "NewNickname");*/
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
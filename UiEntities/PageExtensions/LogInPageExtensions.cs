using UiEntities.Pages;

namespace UiEntities.PageExtensions
{
    public static class LogInPageExtensions
    {
        public static LogInPage FillUsername(this LogInPage logInPage, string username)
        {
            logInPage.Username
                .Clear()
                .SendKeys(username);

            return logInPage;
        }

        public static LogInPage FillPassword(this LogInPage logInPage, string password)
        {
            logInPage.Password
                .Clear()
                .SendKeys(password);

            return logInPage;
        }

        public static AccountPage ClickLogInButton(this LogInPage logInPage)
        {
            logInPage.LogInButton.Click();

            return new AccountPage();
        }

        public static AccountPage LogIn(this LogInPage logInPage, string username, string password)
        {
            return logInPage
                .FillUsername(username)
                .FillPassword(password)
                .ClickLogInButton();
        }
    }
}

using OpenQA.Selenium;

namespace Challenge.Pages
{
    public class LoginPage
    {
        private IWebDriver webdriver;
        // Locators
        By locatorUsernameInput = By.Id("user-name");
        By locatorPasswordInput = By.Id("password");
        By locatorLoginButton = By.Id("login-button");

        public LoginPage(IWebDriver webdriver)
        {
            this.webdriver = webdriver;
        }

        #region SendKeys
        public void SendKeysToUsernameTextField(string username)
        {
            webdriver.FindElement(locatorUsernameInput).SendKeys(username);
        }

        public void SendKeysToPasswordTextField(string password)
        {
            webdriver.FindElement(locatorPasswordInput).SendKeys(password);
        }
        #endregion

        #region Clicks
        public void ClickonTheLoginButton()
        {
            webdriver.FindElement(locatorLoginButton).Click();
        }
        #endregion
    }
}
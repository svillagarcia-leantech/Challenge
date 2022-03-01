using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using SeleniumExtras;

namespace Challenge.Pages
{
    public class CheckoutPage
    {
        private IWebDriver webdriver;
        // Locators
        By locatorCheckoutButton = By.Id("shopping_cart_container");
        By locatorProductCheckout = By.XPath("//*[@id='item_4_title_link']/div");
        By locatorCheckoutTitle = By.XPath("//*[@id='header_container']/div[2]/span");
        By locatorCheckoutFinishButton = By.Id("checkout");
        By locatorCheckoutProcessTitle = By.ClassName("title");
        By locatorNameInput = By.Id("first-name");
        By locatorLastNameInput = By.Id("last-name");
        By locatorZipCodeInput = By.Id("postal-code");
        By locatorContinueButton = By.Id("continue");
        By locatorOverviewTitle = By.ClassName("title");
        By locatorProductOverview = By.ClassName("inventory_item_name");
        By locatorFinishButton = By.Id("finish");
        By locatorCompleteTitle = By.ClassName("title");

        public CheckoutPage(IWebDriver webdriver)
        {
            this.webdriver = webdriver;
        }

        #region SendKeys
        public void SendKeysToCheckoutNameTextField(string name)
        {
            webdriver.FindElement(locatorNameInput).SendKeys(name);
        }
        public void SendKeysToCheckoutLastNameTextField(string lastname)
        {
            webdriver.FindElement(locatorLastNameInput).SendKeys(lastname);
        }
        public void SendKeysToCheckoutZipTextField(string zipCode)
        {
            webdriver.FindElement(locatorZipCodeInput).SendKeys(zipCode);
        }
        #endregion

        #region Gets
        public string GetCheckoutText()
        {
            return webdriver.FindElement(locatorCheckoutTitle).Text;
        }
        public string GetProductCheckout()
        {
            return webdriver.FindElement(locatorProductCheckout).Text;
        }
        public string GetCheckoutProcessTitle()
        {
            return webdriver.FindElement(locatorCheckoutProcessTitle).Text;
        }
        public string GetOverviewTitle()
        {
            return webdriver.FindElement(locatorOverviewTitle).Text;
        }
        public string GetProductOverview()
        {
            return webdriver.FindElement(locatorProductOverview).Text;
        }
        public string GetCompleteTitle()
        {
            return webdriver.FindElement(locatorCompleteTitle).Text;
        }
        #endregion

        #region Clicks
        public void ClickonCheckoutButton()
        {
            webdriver.FindElement(locatorCheckoutButton).Click();
        }
        public void ClickonCheckoutFinishButton()
        {
            webdriver.FindElement(locatorCheckoutFinishButton).Click();
        }
        public void ClickonContinueButton()
        {
            webdriver.FindElement(locatorContinueButton).Click();
        }
        public void ClickonFinishButton()
        {
            webdriver.FindElement(locatorFinishButton).Click();
        }
        #endregion
    }
}

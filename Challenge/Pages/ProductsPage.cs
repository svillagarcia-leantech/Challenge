using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using SeleniumExtras;

namespace Challenge.Pages
{
    public class ProductsPage
    {
        private IWebDriver webdriver;
        // Locators
        By locatorProductsText = By.ClassName("title");
        By locatorAddProductButton = By.Id("add-to-cart-sauce-labs-backpack");
        By locatorProductName = By.XPath("//*[@id='item_4_title_link']/div");

        public ProductsPage(IWebDriver webdriver)
        {
            this.webdriver = webdriver;
        }

        #region Gets
        public string GetProductsText()
        {
            return webdriver.FindElement(locatorProductsText).Text;
        }

        public string GetProductsTextExplicitWait()
        {
            // Thread.Sleep(2000);
            WebDriverWait wait = new WebDriverWait(webdriver, TimeSpan.FromSeconds(10));
            IWebElement element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locatorProductsText));
            return element.Text;
        }

        public string GetProductName()
        {
            return webdriver.FindElement(locatorProductName).Text;
        }
        #endregion

        #region Clicks
        public void ClickonTheAddProductButton()
        {
            webdriver.FindElement(locatorAddProductButton).Click();
        }
        #endregion
    }
}

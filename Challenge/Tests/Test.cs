using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections;

namespace Challenge.Tests
{
    public class Test
    {
        IWebDriver webdriver;

        [SetUp]
        public void Setup()
        {
            webdriver = new ChromeDriver("C:\\Users\\SEBASTIAN NUNEZ\\Downloads\\Chrome Drivers\\chromedriver_win32");
            webdriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [Test, Category("Regression"), Category("Production"), Category("Stage"), Category("Test"), TestCaseSource("TestUsers")]
        [Author("Sebastian Villa Garcia")]
        public void LoginProducts(string username)
        {
            // URL and variables
            webdriver.Url = "https://www.saucedemo.com/";
            string password = "secret_sauce";
            string name = "John";
            string lastName = "Jackson";
            string zipCode = "12345";

            // Login
            var loginPage = new Pages.LoginPage(webdriver);
            loginPage.SendKeysToUsernameTextField(username);
            loginPage.SendKeysToPasswordTextField(password);
            loginPage.ClickonTheLoginButton();

            // Product
            var productsPage = new Pages.ProductsPage(webdriver);
            Assert.That(productsPage.GetProductsText().Equals("PRODUCTS"), $"The Products text is: {productsPage.GetProductsText()}");

            // Add Product
            productsPage.ClickonTheAddProductButton();

            // Get product name
            var productName = productsPage.GetProductName();
            Assert.That(productName.Equals("Sauce Labs Backpack"), $"The product name is: {productName}");

            // Open checkout page
            var checkoutPage = new Pages.CheckoutPage(webdriver);
            checkoutPage.ClickonCheckoutButton();
            Assert.That(checkoutPage.GetCheckoutText().Equals("YOUR CART"), $"The Page text is: {checkoutPage.GetCheckoutText()}");
            Assert.That(checkoutPage.GetProductCheckout().Equals(productName), $"The product name in checkout is: {checkoutPage.GetProductCheckout()}, which is different from {productName}");

            // Continue with Checkout
            checkoutPage.ClickonCheckoutFinishButton();
            Assert.That(checkoutPage.GetCheckoutProcessTitle().Equals("CHECKOUT: YOUR INFORMATION"), $"The Page text is: {checkoutPage.GetCheckoutProcessTitle()}");
            checkoutPage.SendKeysToCheckoutNameTextField(name);
            checkoutPage.SendKeysToCheckoutLastNameTextField(lastName);
            checkoutPage.SendKeysToCheckoutZipTextField(zipCode);

            // Finish with Checkout
            checkoutPage.ClickonContinueButton();
            Assert.That(checkoutPage.GetOverviewTitle().Equals("CHECKOUT: OVERVIEW"), $"The Page text is: {checkoutPage.GetOverviewTitle()}");
            Assert.That(checkoutPage.GetProductOverview().Equals("Sauce Labs Backpack"), $"The Page text is: {checkoutPage.GetProductOverview()}");
            checkoutPage.ClickonFinishButton();
            Assert.That(checkoutPage.GetCompleteTitle().Equals("CHECKOUT: COMPLETE!"), $"The Page text is: {checkoutPage.GetCompleteTitle()}");
        }

        [TearDown]
        public void CloseBrowser()
        {
            webdriver.Close();
            webdriver.Quit();
        }
        public static IEnumerable TestUsers
        {
            get
            {
                yield return "standard_user";
            }
        }
    }
}
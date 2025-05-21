using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using AC2025.PageObjectModel;
using AC2025.TestData;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Drawing;
using AC2025.TestData;
using System;

namespace AC2025
{
    [TestClass]
    public class Main
    {
        private IWebDriver driver;
        private HomePage homePage;
        private SignupPage signupPage;
        private LoginPage loginPage;
        private ProductsPage productsPage;
        private CartPage cartPage;
        private PaymentPage paymentPage;
        private OrderPlaced orderPlaced;
        private DeleteProduct deleteProduct;
        private ReviewPage reviewPage;

        [TestInitialize]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Size = new Size(800, 600);
            driver.Navigate().GoToUrl(TestData.TestData.BaseUrl);

            homePage = new HomePage(driver);
            signupPage = new SignupPage(driver);
            loginPage = new LoginPage(driver);
            productsPage = new ProductsPage(driver);
            cartPage = new CartPage(driver);
            paymentPage = new PaymentPage(driver);
            orderPlaced = new OrderPlaced(driver);
            deleteProduct = new DeleteProduct(driver);
            reviewPage = new ReviewPage(driver);
        }

        [TestMethod]
        public void RegisterUser_Test()
        {
            homePage.ClickSignIn();

            var user = TestData.TestData.NewUniqueUser();

            signupPage.FillSignupForm(user.Name, user.Email);
            signupPage.FillAccountDetails(
                password: user.Password,
                day: user.BirthDay,
                month: user.BirthMonth,
                year: user.BirthYear,
                firstName: user.FirstName,
                lastName: user.LastName,
                address1: user.Address1,
                country: user.Country,
                state: user.State,
                city: user.City,
                zipcode: user.ZipCode,
                mobile: user.Mobile
            );
            signupPage.ClickCreateAccount();
            Assert.IsTrue(signupPage.GetAccountCreatedMessage().ToLower().Contains("account created!"));
            signupPage.ClickContinue();

            Assert.IsTrue(homePage.IsLogoutVisible());
            homePage.ClickLogout();

            homePage.ClickSignIn();
            loginPage.Login(user.Email, user.Password);
            Assert.IsTrue(homePage.IsLogoutVisible());
        }

        [TestMethod]
        public void Checkout_Test()
        {
            productsPage.ClickProductsButton();
            productsPage.SelectCategory("KIDS");
            productsPage.SelectSubCategory("TOPS & SHIRTS");
            productsPage.SelectFirstProduct();
            productsPage.ViewProduct();
            productsPage.SetQuantity(3);
            productsPage.ClickAddToCart();
            productsPage.ClickViewCart();

            Assert.AreEqual(3, productsPage.GetProductQuantityInCart());

            cartPage.ClickProceedToCheckout();
            driver.FindElement(By.XPath("//a[@href='/login' and normalize-space()='Register / Login']")).Click();


            var user = TestData.TestData.ExistingUser;

            loginPage.Login(user.Email, user.Password);
            Assert.IsTrue(homePage.IsLoggedInAs(user.Name));

            homePage.ClickViewCart1();
            cartPage.ClickProceedToCheckout();
            cartPage.PlaceOrder();

            driver.FindElement(By.Name("name_on_card"));

            paymentPage.FillCardName(user.Name);
            paymentPage.FillCardNumber(user.CardNumber);
            paymentPage.FillCVC(user.CardCVC);
            paymentPage.FillExpiry(user.CardMonth, user.CardYear);
            paymentPage.ClickPayAndConfirm();

            Assert.IsTrue(paymentPage.IsOrderSuccessVisible());

            orderPlaced.DeleteAccButton();
            orderPlaced.ContinueDelete();
        }

        [TestMethod]
        public void DeleteProductFromCart_Test()
        {
            productsPage.ClickProductsButton();
            productsPage.SelectCategory("KIDS");
            productsPage.SelectSubCategory("TOPS & SHIRTS");
            productsPage.SelectFirstProduct();
            productsPage.ViewProduct();
            productsPage.SetQuantity(3);
            productsPage.ClickAddToCart();
            productsPage.ClickViewCart();

            Assert.AreEqual(3, productsPage.GetProductQuantityInCart());

            deleteProduct.DeleteProductFromCart();
            Assert.IsFalse(deleteProduct.IsProductInCart(11));
        }

        [TestMethod]
        public void LeaveProductReview_Test()
        {
            var review = TestData.TestData.ReviewData;
            productsPage.ClickProductsButton();
            reviewPage.SearchProduct(review.ProductName);
            reviewPage.ClickViewProduct(review.ProductName);
            reviewPage.WriteReview(review.ReviewerName, review.ReviewerEmail, review.Text);
            Assert.IsTrue(reviewPage.IsReviewSubmitted());
        }

        [TestCleanup]
        public void Cleanup()
        {
            driver.Quit();
        }
    }
}
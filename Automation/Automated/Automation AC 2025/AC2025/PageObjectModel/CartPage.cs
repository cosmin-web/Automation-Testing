using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AC2025.PageObjectModel
{
    public class CartPage
    {
        private IWebDriver driver;

        public CartPage(IWebDriver browser) => driver = browser;

        public bool IsCartPageVisible()
            => driver.FindElement(By.XPath("//li[contains(text(),'Shopping Cart')]")).Displayed;

        public void ClickProceedToCheckout()
            => driver.FindElement(By.XPath("//a[@class='btn btn-default check_out' and text()='Proceed To Checkout']")).Click();

        public void ClickRegisterLogIn()
            => driver.FindElement(By.XPath("//a[@href='/login' and normalize-space()='Register / Login']")).Click();

        public void PlaceOrder()
           => driver.FindElement(By.XPath("//a[contains(@class,'check_out') and normalize-space()='Place Order']")).Click();
    }
}
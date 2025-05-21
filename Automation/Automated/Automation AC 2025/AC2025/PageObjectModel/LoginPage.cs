using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AC2025.PageObjectModel
{
    class LoginPage
    {
        private IWebDriver driver;

        public LoginPage(IWebDriver browser)
        {
            driver = browser;
        }

        public void Login(string email, string password)
        {
            driver.FindElement(By.XPath("//input[@data-qa='login-email']")).SendKeys(email);
            driver.FindElement(By.XPath("//input[@data-qa='login-password']")).SendKeys(password);
            driver.FindElement(By.XPath("//button[@data-qa='login-button']")).Click();
        }
    }
}

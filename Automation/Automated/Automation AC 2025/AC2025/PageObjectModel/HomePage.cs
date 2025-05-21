using OpenQA.Selenium;
using System.Threading;

namespace AC2025.PageObjectModel
{
    public class HomePage
    {
        private IWebDriver driver;

        public HomePage(IWebDriver browser)
        {
            driver = browser;
        }

        public void ClickSignIn()
        {
            driver.FindElement(By.XPath("//a[contains(text(),'Signup / Login')]")).Click();
        }

        public bool IsLogoutVisible()
        {
            return driver.FindElement(By.XPath("//a[contains(text(),' Logout')]")).Displayed;
        }

        public void ClickLogout()
        {
            driver.FindElement(By.XPath("//a[@href='/logout']")).Click();
        }

        public bool IsLoggedInAs(string username)
        {

            string xpath = $"//a[contains(normalize-space(.), 'Logged in as') and contains(., '{username}')]";
            return driver.FindElement(By.XPath(xpath)).Displayed;
        }

        public void ClickViewCart1()
        {
            driver.FindElement(By.XPath("//a[contains(@href,'view_cart') and normalize-space(.)='Cart']\r\n")).Click();
            Thread.Sleep(2000);
        }
    }
}
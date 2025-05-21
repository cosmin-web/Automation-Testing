using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace AC2025.PageObjectModel
{
    public class SignupPage
    {
        private IWebDriver driver;

        public SignupPage(IWebDriver browser)
        {
            driver = browser;
        }

        public void FillSignupForm(string name, string email)
        {
            driver.FindElement(By.XPath("//input[@data-qa='signup-name']")).SendKeys(name);
            driver.FindElement(By.XPath("//input[@data-qa='signup-email']")).SendKeys(email);
            driver.FindElement(By.XPath("//button[@data-qa='signup-button']")).Click();
        }

        public void FillAccountDetails(string password, string day, string month, string year,
            string firstName, string lastName, string address1,
            string country, string state, string city, string zipcode, string mobile)
        {
            driver.FindElement(By.Id("id_gender1")).Click();
            driver.FindElement(By.Id("password")).SendKeys(password);
            new SelectElement(driver.FindElement(By.Id("days"))).SelectByValue(day);
            new SelectElement(driver.FindElement(By.Id("months"))).SelectByValue(month);
            new SelectElement(driver.FindElement(By.Id("years"))).SelectByValue(year);

            driver.FindElement(By.Id("first_name")).SendKeys(firstName);
            driver.FindElement(By.Id("last_name")).SendKeys(lastName);
            driver.FindElement(By.Id("address1")).SendKeys(address1);
            new SelectElement(driver.FindElement(By.Id("country"))).SelectByText(country);
            driver.FindElement(By.Id("state")).SendKeys(state);
            driver.FindElement(By.Id("city")).SendKeys(city);
            driver.FindElement(By.Id("zipcode")).SendKeys(zipcode);
            driver.FindElement(By.Id("mobile_number")).SendKeys(mobile);
        }

        public void ClickCreateAccount()
        {
            driver.FindElement(By.XPath("//button[@data-qa='create-account']")).Click();
            Thread.Sleep(5000);  
        }

        public string GetAccountCreatedMessage()
        {
            return driver.FindElement(By.XPath("//h2[@data-qa='account-created']")).Text;
        }


        public void ClickContinue()
        {
            driver.FindElement(By.XPath("//a[@data-qa='continue-button']")).Click();
            Thread.Sleep(5000);  
        }
    }
}
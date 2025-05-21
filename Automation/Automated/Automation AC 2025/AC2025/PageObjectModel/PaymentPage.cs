using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AC2025.PageObjectModel
{
    internal class PaymentPage
    {
        private IWebDriver driver;
        public PaymentPage(IWebDriver browser) => driver = browser;

        public void FillCardName(string name)
           => driver.FindElement(By.Name("name_on_card")).SendKeys(name);
        public void FillCardNumber(string number)
            => driver.FindElement(By.Name("card_number")).SendKeys(number);
        public void FillCVC(string cvc)
            => driver.FindElement(By.Name("cvc")).SendKeys(cvc);
        public void FillExpiry(string month, string year)
        {
            driver.FindElement(By.Name("expiry_month")).SendKeys(month);
            driver.FindElement(By.Name("expiry_year")).SendKeys(year);
        }

        public void ClickPayAndConfirm()
        {
            driver.FindElement(By.XPath("//button[@data-qa='pay-button']")).Click();

        }

        public bool IsOrderSuccessVisible()
        {
            try
            {
                return driver.FindElement(By.XPath("//p[contains(text(),'Congratulations! Your order has been confirmed!')]")).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}

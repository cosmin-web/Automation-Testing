using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AC2025.PageObjectModel
{
    public class OrderPlaced
    {

        private IWebDriver driver;

        public OrderPlaced(IWebDriver browser)
        {
            driver = browser;
        }

        public void DeleteAccButton()
        {
            driver.FindElement(By.XPath("//a[@href='/delete_account']")).Click();

        }

        public void ContinueDelete()
        {
            driver.FindElement(By.XPath("//a[@data-qa='continue-button']")).Click();
        }

    }
}

using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AC2025.PageObjectModel
{
    class ReviewPage
    {
        private IWebDriver driver;

        public ReviewPage(IWebDriver browser)
        {
            driver = browser;
        }

        public void SearchProduct(string productName)
        {
            var searchInput = driver.FindElement(By.Id("search_product"));
            searchInput.Clear();
            searchInput.SendKeys(productName);

            driver.FindElement(By.Id("submit_search")).Click();
            Thread.Sleep(2000);
        }

        public void ClickViewProduct(string productName)
        {
            var viewButton = driver.FindElement(By.XPath("//a[@href='/product_details/31' and contains(text(), 'View Product')]"));
            viewButton.Click();
            Thread.Sleep(2000);
        }

        public void WriteReview(string name, string email, string review)
        {
            driver.FindElement(By.Id("name")).SendKeys(name);
            driver.FindElement(By.Id("email")).SendKeys(email);
            driver.FindElement(By.Id("review")).SendKeys(review);

            driver.FindElement(By.Id("button-review")).Click();
            Thread.Sleep(2000);
        }

        public bool IsReviewSubmitted()
        {
            try
            {
                return driver.PageSource.Contains("Thank you for your review.");
            }
            catch
            {
                return false;
            }
        }
    }
}

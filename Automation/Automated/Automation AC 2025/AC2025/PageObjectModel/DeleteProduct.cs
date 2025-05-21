using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AC2025.PageObjectModel
{
    class DeleteProduct
    {
        private IWebDriver driver;

        public DeleteProduct(IWebDriver browser)
        {
            driver = browser;
        }

        public void DeleteProductFromCart()
        {
            driver.FindElement(By.XPath("//a[@class='cart_quantity_delete' and @data-product-id='11']")).Click();
            Thread.Sleep(2000);
        }

        public bool IsProductInCart(int productId)
        {
            try
            {
                driver.FindElement(By.XPath($"//a[@class='cart_quantity_delete' and @data-product-id='{productId}']"));
                return true;
            }
            catch(NoSuchElementException)
            {
                return false;
            }
        }
    }
}
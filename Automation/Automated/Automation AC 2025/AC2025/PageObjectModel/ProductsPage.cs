using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AC2025.PageObjectModel
{
    class ProductsPage
    {
        private IWebDriver driver;

        public ProductsPage(IWebDriver browser)
        {
            driver = browser;
        }

        public void ClickProductsButton()
        {
            driver.FindElement(By.XPath("//a[@href='/products']")).Click();
            Thread.Sleep(2000);
        }

        public void SelectCategory(string category)
        {
            var categoryElement = driver.FindElement(By.XPath("//a[@data-toggle='collapse' and @href='#Kids' and contains(normalize-space(), 'Kids')]"));
            categoryElement.Click();
            Thread.Sleep(1000);
        }

        public void SelectSubCategory(string subCategory)
        {
            var subCategoryElement = driver.FindElement(By.XPath("//div[@id='Kids']//a[contains(normalize-space(), 'Tops & Shirts')]"));
            subCategoryElement.Click();
            Thread.Sleep(2000);
        }

        public void SelectFirstProduct()
        {
            driver.FindElement(By.XPath("(//div[@class='product-image-wrapper'])[1]")).Click();
            Thread.Sleep(2000);
        }

        public void ViewProduct()
        {
            driver.FindElement(By.XPath("//a[@href='/product_details/11']")).Click();
            Thread.Sleep(2000);
        }

        public void SetQuantity(int quantity)
        {
            var qtyInput = driver.FindElement(By.Id("quantity"));
            qtyInput.Clear();
            qtyInput.SendKeys(quantity.ToString());
        }

        public void ClickAddToCart()
        {
            driver.FindElement(By.XPath("//button[@type='button' and contains(normalize-space(.), 'Add to cart')]")).Click();
            Thread.Sleep(2000);
        }

        public void ClickViewCart()
        {
            driver.FindElement(By.XPath("//div[@class='modal-body']//a[@href='/view_cart']")).Click();
            Thread.Sleep(2000);
        }

        public int GetProductQuantityInCart()
        {
            var qtyElement = driver.FindElement(By.XPath("//tr[@id='product-11']//td[@class='cart_quantity']//button"));
            string qtyText = qtyElement.Text.Trim();
            return int.Parse(qtyText);
        }
    }
}
using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace FinalProject.Page
{
    class ProductsPage : BasePage
    {
        public IList<IWebElement> Products => _driver.FindElements(By.ClassName("productListProducts_product"));
        public IWebElement AddToBasketButton => _driver.FindElement(By.ClassName("productAddToBasket-buyNow"));
        public IWebElement AddedToBasketTitle => _driver.FindElement(By.Id("added-to-basket-modal-title"));
        public ProductsPage(IWebDriver driver) : base(driver) { }

        public ProductsPage Open()
        {
            _driver.Navigate().GoToUrl("https://www.myprotein.lt/nutrition/protein/whey-protein.list");
            return this;
        }

        public ProductsPage AcceptCookies()
        {
            Cookie myCookie = new Cookie(
                "cookieNoticeShown",
                "cookieNoticeShown",
                "www.myprotein.lt",
                "/",
                DateTime.Now.AddYears(1)
             );

            _driver.Manage().Cookies.AddCookie(myCookie);
            _driver.Navigate().Refresh();

            return this;
        }

        public ProductsPage ChooseProduct(int number)
        {
            if (number <= Products.Count - 1)
                Products[number].FindElement(By.ClassName("athenaProductBlock_button-moreInfo")).Click();
            return this;
        }

        public ProductsPage ClickAddToBasket()
        {
            AddToBasketButton.Click();
            return this;
        }
    }
}

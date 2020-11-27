using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace FinalProject.Page
{
    class BasketPage : BasePage
    {

        public IList<IWebElement> Products => _driver.FindElements(By.ClassName("productListProducts_product"));
        public IWebElement AddToBasketButton => _driver.FindElement(By.ClassName("productAddToBasket-buyNow"));
        public IWebElement OpenBasketButton => _driver.FindElement(By.ClassName("addedToBasketModal_viewBasketButton"));
        public bool EmptyBasketMessageDisplayed => _driver.FindElements(By.ClassName("athenaBasket_emptyBasketMessage")).Count > 0;
        public IWebElement BasketTitle => _driver.FindElement(By.ClassName("athenaBasket_headerTitle"));
        public IList<IWebElement> RemoveItemButtons => _driver.FindElements(By.ClassName("athenaBasket_removeItem"));

        public BasketPage(IWebDriver driver) : base(driver) { }

        public BasketPage Open()
        {
            _driver.Navigate().GoToUrl("https://www.myprotein.lt/nutrition/protein/whey-protein.list");
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            return this;
        }

        public BasketPage ChooseProduct(int number)
        {
            if (number <= Products.Count - 1)
                Products[number].FindElement(By.ClassName("athenaProductBlock_button-moreInfo")).Click();
            return this;
        }

        public BasketPage ClickAddToBasket()
        {
            AddToBasketButton.Click();
            return this;
        }
        public BasketPage ClickOpenBasket()
        {
            WebDriverWait wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 5));
            wait.Until(_ => OpenBasketButton.Displayed);
            OpenBasketButton.Click();
            return this;
        }

        public BasketPage WaitForBasketOpen()
        {
            WebDriverWait wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 5));
            wait.Until(_ => BasketTitle.Displayed);
            return this;
        }

        public BasketPage AcceptCookies()
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

        public BasketPage RemoveAllItems()
        {
            if (RemoveItemButtons.Count > 0)
            {
                foreach (IWebElement button in RemoveItemButtons)
                {
                    button.Click();
                }
            }
            return this;
        }
    }
}

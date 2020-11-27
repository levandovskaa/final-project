using FinalProject.Page;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FinalProject.Elements
{
    class FilterElement : BasePage
    {
        public FilterElement(IWebDriver driver) : base(driver) { }
        private IReadOnlyCollection<IWebElement> filters => _driver.FindElements(By.ClassName("responsiveFacets_sectionItemValue"));
        public IList<IWebElement> Products => _driver.FindElements(By.ClassName("productListProducts_product"));
        public IWebElement AddToBasketButton => _driver.FindElement(By.ClassName("productAddToBasket-buyNow"));
        public SelectElement Dropdown => new SelectElement(_driver.FindElement(By.Id("product-variation-dropdown-5")));

        public FilterElement Open()
        {
            _driver.Navigate().GoToUrl("https://www.myprotein.lt/nutrition/protein/whey-protein.list");
            return this;
        }

        public FilterElement AcceptCookies()
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

        public FilterElement ChooseProduct(int number)
        {
            if (number <= Products.Count - 1)
                Products[number].FindElement(By.ClassName("athenaProductBlock_button-moreInfo")).Click();
            return this;
        }

        public FilterElement ClickAddToBasket()
        {
            AddToBasketButton.Click();
            return this;
        }

        public bool SelectIncludes(string product)
        {
            List<IWebElement> options = new List<IWebElement>(Dropdown.Options);
            if (options.Where(option => option.Text.ToLower().Contains(product.ToLower())).Count() == 0)
                return false;

            return true;
        }

        public FilterElement ChooseFilter(string filterText)
        {
            List<IWebElement> filterList = new List<IWebElement>(filters);
            IWebElement filter = filterList.Find(e => e.Text.ToLower().Equals(filterText.ToLower()));

            if (filter != null)
                filter.Click();

            return this;
        }
    }
}

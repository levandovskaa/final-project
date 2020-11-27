using FinalProject.Page;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace FinalProject.Elements
{
    class NavigationElement : BasePage
    {
        public IWebElement VeganButton => _driver.FindElement(By.CssSelector("[alt='Vegan']"));

        public IWebElement ProductTitle => _driver.FindElement(By.Id("responsive-product-list-title"));

        public NavigationElement(IWebDriver driver) : base(driver) { }

        public NavigationElement Open()
        {
            _driver.Navigate().GoToUrl("https://www.myprotein.lt/");
            return this;
        }


        public NavigationElement AcceptCookies()
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
        public NavigationElement ClickVeganButton()
        {
            VeganButton.Click();
            return this;
        }
        public NavigationElement WaitForTitle()
        {
            WebDriverWait wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 5));
            wait.Until(_ => ProductTitle.Displayed);
            return this;
        }
    }
}

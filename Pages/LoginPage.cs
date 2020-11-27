using OpenQA.Selenium;
using System;

namespace FinalProject.Page
{
    class LoginPage : BasePage
    {
        public IWebElement EmailInput => _driver.FindElement(By.Id("username"));
        public IWebElement EmailPassword => _driver.FindElement(By.Id("password"));
        public IWebElement LoginSubmit => _driver.FindElement(By.Id("login-submit"));
        public IWebElement ErrorMessage => _driver.FindElement(By.ClassName("login_alertDanger"));

        public LoginPage(IWebDriver driver) : base(driver) { }

        public LoginPage TypeEmail(string email)
        {
            EmailInput.SendKeys(email);
            return this;
        }
        public LoginPage TypePassword(string password)
        {
            EmailPassword.SendKeys(password);
            return this;
        }
        public LoginPage LoginClick()
        {
            LoginSubmit.Click();
            return this;
        }

        public LoginPage Open()
        {
            _driver.Navigate().GoToUrl("https://www.myprotein.lt/login.jsp?returnTo=https%3A%2F%2Fwww.myprotein.lt%2FaccountHome.account");
            return this;
        }

        public LoginPage AcceptCookies()
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
    }

}

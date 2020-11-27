using OpenQA.Selenium;

namespace FinalProject.Page
{
    class BasePage
    {
        public IWebDriver _driver;
        public BasePage (IWebDriver driver)
        {
            _driver = driver;
        }
    }
}

using FinalProject.Page;
using NUnit.Framework;
using System;

namespace FinalProject.Test
{
    public class LoginTests : BaseTest
    {
        [Test]
        public void TestEmail()
        {
            LoginPage page = new LoginPage(driver).Open().AcceptCookies().TypeEmail("test").LoginClick();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1000);
            Assert.IsTrue(page.ErrorMessage.Displayed);
        }

        [Test]
        public void TestPassword()
        {
            LoginPage page = new LoginPage(driver).Open().AcceptCookies().TypePassword("test").LoginClick();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1000);
            Assert.IsTrue(page.ErrorMessage.Displayed);
        }

        [Test]
        public void TestBoth()
        {
            LoginPage page = new LoginPage(driver).Open().AcceptCookies().TypeEmail("Test").TypePassword("test").LoginClick();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1000);
            Assert.IsTrue(page.ErrorMessage.Displayed);
        }
    }
}
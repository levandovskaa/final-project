using FinalProject.Page;
using NUnit.Framework;

namespace FinalProject.Test
{
    class BasketPageTest : BaseTest
    {
        [Test]
        public void TestAddedToBasket()
        {
            BasketPage page = new BasketPage(driver)
                .Open()
                .AcceptCookies()
                .ChooseProduct(0)
                .ClickAddToBasket()
                .ClickOpenBasket()
                .WaitForBasketOpen();

            Assert.IsFalse(page.EmptyBasketMessageDisplayed, "Basket is not empty");
        }

        [Test]
        public void TestRemoveFromBasket()
        {
            BasketPage page = new BasketPage(driver)
                .Open()
                .AcceptCookies()
                .ChooseProduct(0)
                .ClickAddToBasket()
                .ClickOpenBasket()
                .WaitForBasketOpen()
                .RemoveAllItems();

            Assert.IsTrue(page.EmptyBasketMessageDisplayed, "Basket is empty");
        }
    }
}

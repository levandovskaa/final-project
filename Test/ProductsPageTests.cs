using FinalProject.Page;
using NUnit.Framework;
using System.Threading;

namespace FinalProject.Test
{
    class ProductsPageTests : BaseTest
    {
        [Test]
        public void TestAddToBasket()
        {
            ProductsPage page = new ProductsPage(driver).Open().AcceptCookies().ChooseProduct(0).ClickAddToBasket();
            Thread.Sleep(2000);
            Assert.IsTrue(page.AddedToBasketTitle.Displayed);
        }
    }
}

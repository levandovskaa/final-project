using FinalProject.Elements;
using NUnit.Framework;

namespace FinalProject.Test
{
    class NavigationElementTest : BaseTest
    {
        [Test]
        public void TestTitleVegan()
        {
            NavigationElement Element = new NavigationElement(driver).Open().AcceptCookies().ClickVeganButton().WaitForTitle();
            Assert.AreEqual("Veganiški produktai", Element.ProductTitle.Text, "Displays expected title");
        }
    }
}

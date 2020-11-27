using FinalProject.Elements;
using NUnit.Framework;

namespace FinalProject.Test
{
    class FilterElementTest : BaseTest
    {
        [Test]
        public void TestFilter()
        {
            string filter = "Šokolado";
            FilterElement element = new FilterElement(driver).Open().AcceptCookies().ChooseFilter(filter).ChooseProduct(0);
            Assert.IsTrue(element.SelectIncludes(filter));
        }
    }
}

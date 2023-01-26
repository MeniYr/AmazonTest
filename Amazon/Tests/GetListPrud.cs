using Amazon_test.Source;
using Amazon_test.Source.pages;
using Amazon_test.utiils;
using OpenQA.Selenium;

namespace Amazon_test.Tests
{
    class GetListPrud
    {
        private BrowserFactory factoryDrivers;
        private IDictionary<string, IWebDriver> drivers;
        private IList<Item> items = new List<Item>();

        [SetUp]
        public void init()
        {
            factoryDrivers = new BrowserFactory();
            drivers = factoryDrivers.Drivers_dict;
            if (!drivers.ContainsKey("Chrome"))
            {
                factoryDrivers.InitBrowser("Chrome");
                factoryDrivers.LoadApplication("https://www.amazon.com/ref=nav_logo?language=en_US");
            }
/*            if (!drivers.ContainsKey("Firefox"))
            {
                factoryDrivers.InitBrowser("Firefox");
                factoryDrivers.LoadApplication("https://www.amazon.com/ref=nav_logo?language=en_US");
            }*/
        }
        [Test]
        public void sreachPruds()
        {
            foreach (var driver in drivers.Values)
            {
                Amazon Amazon = new Amazon(driver);
                Dictionary<string, string> query = new Dictionary<string, string>();
                query.Add("price_lower_then", "40");
                query.Add("price_higher_or_equal", "10");
                query.Add("free_shipping", "FREE");
                Amazon.Pages.Home.SearchBar.Text = "mouse";
                Amazon.Pages.Home.SearchBar.Click();
                items = Amazon.Pages.Results.GetRustsBy(query);
                foreach (var item in items)
                {
                    Console.Write(item.ToString());
                    Assert.True(Convert.ToDouble(item.price) < 40);
                    Assert.True(Convert.ToDouble(item.price) >= 10);
                }
            }
        }
        [TearDown]
        public void cleanUp()
        {
            factoryDrivers.CloseAllDrivers();
        }
    }
}

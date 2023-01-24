using Amazon_test.Source;
using Amazon_test.Source.pages;
using Amazon_test.utiils;
using OpenQA.Selenium;

namespace Amazon_test.Tests
{
    class GetListPrud
    {
        private BrowserFactory factoryDrivers;
        private IWebDriver driver;
        private IDictionary<string, IWebDriver> drivers;
        private List <Item> items = new List<Item>();

        [SetUp]
        public void init()
        {
            factoryDrivers = new BrowserFactory();
            drivers = factoryDrivers.Drivers_dict;
            if (!drivers.ContainsKey("Chrome"))
            {
                factoryDrivers.InitBrowser("Chrome");
                factoryDrivers.LoadApplication("https://www.amazon.com/");
            }
        }


        [Test]
        public void sreachPruds()
        {

            foreach (var driver in drivers.Values)
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

                Amazon Amazon = new Amazon(driver);
                Dictionary<string, string> query = new Dictionary<string, string>();
                query.Add("price_lower_then", "30");
                query.Add("price_higher_or_equal", "40");
                query.Add("free_shipping", "FREE");

                Amazon.Pages.Home.SearchBar.Text = "mouse";
                Amazon.Pages.Home.SearchBar.Click();
                items = Amazon.Pages.Results.GetRustsBy(query);
                Assert.IsNotNull(items);


            }

        }

        [TearDown]
        public void cleanUp()
        {
            factoryDrivers.CloseAllDrivers();
        }
    }
}

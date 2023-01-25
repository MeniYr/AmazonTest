using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;


namespace Amazon_test.utiils
{
    class BrowserFactory
    {
        private readonly IDictionary<string, IWebDriver> Drivers = new Dictionary<string, IWebDriver>();
        private IWebDriver? driver;

        public IDictionary<string, IWebDriver> Drivers_dict
        {
            get { return Drivers; }

        }
        public IWebDriver Driver
        {
            get
            {
                if (driver == null)
                    throw new NullReferenceException("The WebDriver browser instance was not initialized. You should first call the method InitBrowser.");
                return driver;
            }
            private set
            {
                driver = value;
            }
        }

        public void InitBrowser(string browserName)
        {
            switch (browserName.ToUpper())
            {
                case "FIREFOX":
                    if (!Drivers.ContainsKey(browserName))
                    {
                        driver = new FirefoxDriver(); // the driver exe is already on firfox folder
                        Drivers.Add("Firefox", driver);
                    }
                    break;

                case "IE":
                    if (!Drivers.ContainsKey(browserName))
                    {
                        driver = new EdgeDriver(@"C:\Drivers\edgedriver_win64");
                        Drivers.Add("IE", driver);
                    }
                    break;

                case "CHROME":
                    if (!Drivers.ContainsKey(browserName))
                    {
                        driver = new ChromeDriver("C:\\Drivers\\chromedriver_win32");
                        Drivers.Add("Chrome", driver);
                    }
                    break;
            }
        }

        public void LoadApplication(string url)
        {
            driver.Url = url;
        }

        public void CloseAllDrivers()
        {
            foreach (var key in Drivers.Keys)
            {
                Drivers[key].Close();
                Drivers[key].Quit();
            }
        }
    }
}
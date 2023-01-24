using Amazon_test.Source;
using Amazon_test.Source.pages;
using OpenQA.Selenium;


namespace Amazon_test.Source
{
    class Pages
    {
        private Home home;
        private Results results;
        IWebDriver driver;
        public Pages(IWebDriver driver)
        {
            this.driver = driver;

        }
        public Home Home
        {
            get
            {
                if (home == null)
                {
                    return this.home = new Home(driver);

                }
                return this.home;
            }
        }

        public Results Results
        {
            get
            {
                if (results == null)
                {
                    return this.results = new Results(driver);

                }
                return this.results;
            }
        }

    }
}

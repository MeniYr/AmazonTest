using OpenQA.Selenium;


namespace Amazon_test.Source
{
    class Amazon
    {
        private IWebDriver driver;
        private Pages pages;
        public Amazon(IWebDriver driver)
        {
            this.driver = driver;
        }
        public Pages Pages
        {
            get
            {
                if (pages == null)
                    return this.pages = new Pages(this.driver);
                return this.pages;
            }
        }
    }
}

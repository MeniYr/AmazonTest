using OpenQA.Selenium;

namespace Amazon_test.Source.pages
{
    class SearchBar
    {
        private IWebDriver driver;
        private IWebElement submit;
        public string Text
        {
            set { driver.FindElement(By.Id("twotabsearchtextbox")).SendKeys(value); }
        }
        public SearchBar(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void Click()
        {
            submit = driver.FindElement(By.Id("nav-search-submit-button"));
            submit.Click();
        }
    }
}

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon_test.Source.pages
{
    class SearchBar
    {
        public Results results;
        private IWebDriver driver;
        private IWebElement submit;
        private IWebElement input;


        public string Text { get; set; }
        public SearchBar(IWebDriver driver)
        {
            this.driver = driver;

        }

        public void Click()
        {
            input = driver.FindElement(By.Id("twotabsearchtextbox"));
            input.Click();
            input.SendKeys(Text);

            submit = driver.FindElement(By.Id("nav-search-submit-button"));
            submit.Click();
        }


    }
}

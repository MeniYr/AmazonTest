using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon_test.Source.pages
{
    class Home
    {
        private IWebDriver driver;
        public SearchBar searchBar;
        public Home(IWebDriver driver)
        {
            this.driver = driver;
        }
        public SearchBar SearchBar
        {
            get
            {
                if (searchBar == null)
                    return this.searchBar = new SearchBar(driver);
                return this.searchBar;
            }
        }
    }
}

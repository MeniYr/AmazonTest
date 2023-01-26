using OpenQA.Selenium;

namespace Amazon_test.Source.pages
{
    class Results
    {
        private Item Item;
        private IList<Item> ItemsList;
        private IWebDriver driver;
        private string title_xpath;
        private string price_xpath;
        private string url_xpath;
        private List<IWebElement> allElements;
        public Results(IWebDriver driver)
        {
            ItemsList = new List<Item>();
            this.driver = driver;
        }

        public IList<Item> GetRustsBy(Dictionary<string, string> filters)
        {

            string Price_xPath_fill_in = " and translate(., '$,', '') ";
            string Price_xPath_forward = " and parent::span[not (contains(@data-a-strike, 'true'))] ";
            string full_xPath = "//span[@class='a-offscreen' ";
            string free_shipingXpath = " and ancestor::div[@class ='a-section a-spacing-small a-spacing-top-small' and  contains(. , 'FREE Shipping')  ]";
            string full_higher_or_equal;
            string full_lower;
            string wholePrice;
            string fractionPrice;
            string title;
            string wholePrice_xpath;
            string fractionPrice_xpath;
            string url;
            
            foreach (var filter in filters)
            {

                switch (filter.Key)
                {
                    case "price_lower_then":
                        full_xPath += Price_xPath_fill_in + " <" + filter.Value + Price_xPath_forward;
                        
                        break;
                    case "price_higher_or_equal":
                        full_xPath += Price_xPath_fill_in + " >=" + filter.Value + Price_xPath_forward;

                        break;
                    case "free_shipping":
                        full_xPath += free_shipingXpath ;

                        break;

                    default:
                        break;
                }
            }
            full_xPath += "]/ancestor::div[@class = 'a-section a-spacing-small a-spacing-top-small']";
            title_xpath = ".//span[@class ='a-size-medium a-color-base a-text-normal']";
            wholePrice_xpath = ".//span[@class='a-price-whole']";
            fractionPrice_xpath = ".//span[@class='a-price-fraction']";
            url_xpath = ".//*[contains(@class,'a-link-normal s-underline-text s-underline-link-text s-link-style a-text-normal')]";
            this.allElements = driver.FindElements(By.XPath(full_xPath)).ToList<IWebElement>();

            foreach (IWebElement element in allElements)
            {
                title = element.FindElement(By.XPath(title_xpath)).Text;
                url = element.FindElement(By.XPath(url_xpath)).GetAttribute("href");
                wholePrice = element.FindElement(By.XPath(wholePrice_xpath)).Text;
                fractionPrice = element.FindElement(By.XPath(fractionPrice_xpath)).Text;
                Item = new Item(title, wholePrice + "." + fractionPrice, url);
                ItemsList.Add(Item);
            }
            return ItemsList;
        }
    }
}

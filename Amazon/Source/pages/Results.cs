using OpenQA.Selenium;

namespace Amazon_test.Source.pages
{
    class Results
    {
        private Item Item;
        private IList<Item> ItemsList;
        private IWebDriver driver;
        private List<IWebElement> allElements;
        public Results(IWebDriver driver)
        {
            ItemsList = new List<Item>();
            this.driver = driver;
        }

        public IList<Item> GetRustsBy(Dictionary<string, string> filters)
        {
            /*
            * collecting the search line:
                with those strings i was collect the relevant information we need to find elements on Amazon web site.
                the collecting Occurs by starting with "full_xPath" as default, then every case - if there exists - will
                add is own condition to the relevant helper string like "url_xpath" or "title_xpath" to "full_xPath" string and so on.
                in the end, the "full_path" will closed by "end_xPath" string.
            * using:
                the elements parent of all the relevant filters will added to the list. then, three details extract: title, price and url.
                the details get into Item object so for all element - will created Item and adding to list of Items.
                in the end, the list will be returned
             */
            string full_xPath = "//span[@class='a-offscreen' ";
            string Price_xPath_fill_in = " and translate(., '$,', '') ";
            string Price_xPath_forward = " and parent::span[not (contains(@data-a-strike, 'true'))] ";
            string free_shipingXpath = " and ancestor::div[@class ='a-section a-spacing-small a-spacing-top-small' and  contains(. , 'FREE Shipping')  ]";
            string not_free_shipingXpath = " and ancestor::div[@class ='a-section a-spacing-small a-spacing-top-small' and not(contains(. , 'FREE Shipping'))  ]";
            string url_xpath = ".//*[contains(@class,'a-link-normal s-underline-text s-underline-link-text s-link-style a-text-normal')]";
            string title_xpath = ".//span[@class ='a-size-medium a-color-base a-text-normal']";
            string wholePrice_xpath = ".//span[@class='a-price-whole']";
            string fractionPrice_xpath = ".//span[@class='a-price-fraction']";
            string end_xPath = "]/ancestor::div[@class = 'a-section a-spacing-small a-spacing-top-small']";
            string wholePrice;
            string fractionPrice;
            string title;
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
                        full_xPath += filter.Value.ToUpper().Equals("TRUE") ? free_shipingXpath : not_free_shipingXpath;
                        break;
                    default:
                        break;
                }
            }
            full_xPath += end_xPath;
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

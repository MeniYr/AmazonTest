using OpenQA.Selenium;

namespace Amazon_test.Source.pages
{
    class Results
    {
        private Item Item;
        private List<Item> ItemsList;
        private IWebDriver driver;
        private string title;
        private string price;
        private string url;
        private IWebElement item;
        public Results(IWebDriver driver)
        {
            this.driver = driver;

        }

        public List<Item> GetRustsBy(Dictionary<string, string> filters)
        {
            //concat(substring(//span[@class = 'a-price-whole'],0,4), //following-sibling::span[@class = 'a-price-fraction'])
            ////*[contains(@class, "a-price-whole") and . >=11]
            // string Price_xPath = "//*[contains(@class, 'a-price-whole')";
            string Price_xPath = "concat(substring(//span[@class = 'a-price-whole'],0,4), //following-sibling::span[@class = 'a-price-fraction'])";
            string Shipping_xPath = "//*[contains(@class, 'a-color-base a-text-bold') and  contains(. , 'FREE Shipping')]";
            string parent_xPath = "//preceding::*[@class ='a-section a-spacing-small a-spacing-top-small'] ";
            // string all_xPath = " //* [(contains(@class, 'a-price-whole') and . >=11)]//preceding::*[@class ='a-section a-spacing-small a-spacing-top-small'] "
            string childTitleXpath = "//child::*[contains(@*,'a-size-medium a-color-base a-text-normal')]";
            string childPriceXpath = "//child::*[contains(@*,'a-price-whole')]";
            foreach (var filter in filters)
            {

                switch (filter.Key)
                {
                    case "price_lower_then":
                        Price_xPath += "and .<" + filter.Value + "])";
                        title = driver.FindElement(By.XPath("//* [concat(substring(span[@class='a-price']//text(),1,3) ,'.',span[@class='a-price-fraction']//text()) <60]//preceding::*[@class ='a-section a-spacing-small a-spacing-top-small']//child::*[contains(@*,'a-size-medium a-color-base a-text-normal')]")).Text;
                        Console.WriteLine(title);
                        price = driver.FindElement(By.XPath("//span[concat(span[@class='a-price-whole']//text() ,'.',span[@class='a-price-fraction']//text()) <60]")).Text;
                        Console.WriteLine(price);
                        url = driver.FindElement(By.XPath("//* [concat(span[@class='a-price-whole']//text() ,'.',span[@class='a-price-fraction']//text()) <60]//preceding::*[@class ='a-section a-spacing-small a-spacing-top-small']//child::*[contains(@class,'a-link-normal s-underline-text s-underline-link-text s-link-style a-text-normal')]")).GetAttribute("href");
                        Console.WriteLine(url);


                        break;
                    case "price_higher_or_equal":
                        Price_xPath += "and .<= " + filter.Value + "]";

                        break;
                    case "free_shipping":
                        parent_xPath += "and .= " + filter.Value + "]";
                        ////*[contains(@class, "a-color-base a-text-bold") and  contains(. , "FREE Shipping")  ]
                        break;

                    default:
                        break;
                }

             Item = new Item(title ="", price="", url="");
             ItemsList.Add(Item);


            }
            return ItemsList;
        }
    }
}

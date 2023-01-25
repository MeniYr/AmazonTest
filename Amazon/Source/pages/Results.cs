using OpenQA.Selenium;

namespace Amazon_test.Source.pages
{
    class Results
    {
        private Item Item;
        private IList<Item> ItemsList;
        private IWebDriver driver;
        private string title;
        private string price;
        private string url;
        private IWebElement item;
        private IList<IWebElement> allElements;
        public Results(IWebDriver driver)
        {
            this.driver = driver;

        }

        public IList<Item> GetRustsBy(Dictionary<string, string> filters)
        {
            //concat(substring(//span[@class = 'a-price-whole'],0,4), //following-sibling::span[@class = 'a-price-fraction'])
            ////*[contains(@class, "a-price-whole") and . >=11]
            // string Price_xPath = "//*[contains(@class, 'a-price-whole')";
            //string Shipping_xPath = "//*[contains(@class, 'a-color-base a-text-bold') and  contains(. , 'FREE Shipping')]";
            // string all_xPath = " //* [(contains(@class, 'a-price-whole') and . >=11)]//preceding::*[@class ='a-section a-spacing-small a-spacing-top-small'] "
            //string childPriceXpath = "//child::*[contains(@*,'a-price-whole')] ";
            //bool lowerFiltered = false;
            //lowerFiltered = true;

            string Price_xPath_fill_in = "//span[@class='a-offscreen' and translate(., '$,', '') ";
            string Price_xPath_forward = " and parent::span[not (contains(@data-a-strike, 'true'))]] ";

            string parent_xPath = "//preceding::*[@class ='a-section a-spacing-small a-spacing-top-small'] ";
            string childTitleXpath = "//child::*[contains(@*,'a-size-medium a-color-base a-text-normal')] ";
            string childUrlXpath = "//child::*[contains(@class,'a-link-normal s-underline-text s-underline-link-text s-link-style a-text-normal')]";
            string full_xPath = "";
            string free_shipingXpath = "//*[contains(@class, 'a-color-base a-text-bold') and  contains(. , 'FREE Shipping')  ]";
            string price_condition = "";
            string full_higher_or_equal;
            string full_lower;
            foreach (var filter in filters)
            {

                switch (filter.Key)
                {
                    case "price_lower_then":
                        price_condition = Price_xPath_fill_in += " <" + filter.Value;
                        full_lower = price_condition + Price_xPath_forward;
                       // Console.WriteLine("lower: " +full_lower);
                        //full_xPath += full_lower;
                        break;
                    case "price_higher_or_equal":
                        //span[@class='a-offscreen' and translate(., '$,', '')  <40 and translate(., '$,', '') >=30 and parent::span [not(contains(@data-a-strike, 'true'))]]
                        if (price_condition == "")
                        {
                            full_higher_or_equal = (Price_xPath_fill_in += " >= ") + filter.Value + Price_xPath_forward;
                            //Console.WriteLine("if - full_higher_or_equal: " + full_higher_or_equal);
                        }
                        else
                        {
                            full_higher_or_equal = (price_condition += " and translate(., '$,', '') >= " ) + filter.Value + Price_xPath_forward;
                           // Console.WriteLine("else - full_higher_or_equal: " + full_higher_or_equal);
                        }


                        Console.WriteLine("higher: "+ full_higher_or_equal);
                        full_xPath += full_higher_or_equal;
                        break;
                    case "free_shipping":
                        full_xPath = full_xPath + parent_xPath + free_shipingXpath;
                       // Console.WriteLine("full: "+full_xPath);
                        ////*[contains(@class, "a-color-base a-text-bold") and  contains(. , "FREE Shipping")  ]
                        break;

                    default:
                        break;
                }

                //Console.WriteLine("full_xPath: "+ full_xPath + parent_xPath);

                //title -> 
                //span[@class='a-offscreen' and translate(., '$,', '')  <40 and translate(., '$,', '') >= 30 and parent::span[not (contains(@data-a-strike, 'true'))]] //preceding::*[@class ='a-section a-spacing-small a-spacing-top-small'] //*[contains(@class, 'a-color-base a-text-bold') and  contains(. , 'FREE Shipping')  ]//preceding::*[@class ='a-section a-spacing-small a-spacing-top-small'] //child::*[contains(@*,'a-size-medium a-color-base a-text-normal')]
                //< - title
                //title = driver.FindElement(By.XPath("//child::*[contains(@*,'a-size-medium a-color-base a-text-normal')]")).Text;

                //Console.WriteLine(title);
                //price = driver.FindElement(By.XPath("//descendant::*[@class='a-offscreen']")).Text;
                //Console.WriteLine(price);
                //url = driver.FindElement(By.XPath("//* [concat(span[@class='a-price-whole']//text() ,'.',span[@class='a-price-fraction']//text()) <60]//preceding::*[@class ='a-section a-spacing-small a-spacing-top-small']//child::*[contains(@class,'a-link-normal s-underline-text s-underline-link-text s-link-style a-text-normal')]")).GetAttribute("href");
                //Console.WriteLine(url);

                //allElements = driver.FindElements(By.XPath(full_xPath));
                // foreach (var element in allElements)
                //   {
                //      title = element.FindElement(By.XPath(childTitleXpath)).Text;
                //      url = element.FindElement(By.XPath(childUrlXpath)).GetAttribute("href");
                //     price = element.FindElement(By.XPath(Price_xPath_fill_in + Price_xPath_forward)).Text;
                //     Console.WriteLine(title, url, price);
                //     Item = new Item(title = "", price = "", url = "");
                //     ItemsList.Add(Item);
                // }



            }
            return ItemsList;
        }
    }
}

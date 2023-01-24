using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon_test.Source.pages
{
    class Item
    {
        public string Title { get; set; }
        public string Price { get; set; }
        public string title;
        public string price;
        public string url;

        IWebElement item;


        public Item(string title, string price, string url)
        {
            this.title = title;
            this.price = price; 
            this.url = url;
        //    Price = item.FindElement(By.XPath(childTitleXpath)).Text;
         //   Title = item.FindElement(By.ClassName(childPriceXpath)).Text;
        }

    }
}

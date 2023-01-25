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
        public string title { get; set; }
        public string price { get; set; }
        public string url { get; set; }

        IWebElement item;


        public Item(string title, string price, string url)
        {
            this.title = title;
            this.price = price; 
            this.url = url;
        }

    }
}

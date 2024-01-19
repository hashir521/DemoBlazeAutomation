using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace demoBlaze
{
    public class Category:BasePage
    {
        IWebDriver driver;
      

        public void caategory()
        {
            By mob = By.CssSelector("div.col-md-6:nth-child(1) > div:nth-child(1) > div:nth-child(2) > h4:nth-child(1) > a:nth-child(1)");
            click(mob);
            //// You should check if the element is present before attempting to interact with it
            //try
            //{
                
            //    Console.WriteLine("Enter in catch");
            //    Thread.Sleep(1000);
            //    IWebElement ele = driver.FindElement(By.XPath("/html/body/div[5]/div/div[2]/div/div[1]/div/a/img"));
            //    ele.Click();
            //    Console.WriteLine("Clicked");
            //}
            //catch (NoSuchElementException)
            //{
            //    Console.WriteLine("Element not found");
            //}
        }
    }
}

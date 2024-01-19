using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace demoBlaze
{
    public class AddToCart : BasePage{
        BasePage b = new BasePage();
        //IWebDriver driver;
        //By addCart = By.LinkText("Add to cart");
        //public void AaddToCart()
        //{
        //    // click(addCart);
        //    driver.FindElement(By.LinkText("Add to cart")).Click();
        //}
        By addCart = By.XPath("/html/body/div[5]/div/div[2]/div[2]/div/a");

        public void addToCart()
        {
            try
            {
                // Click on the element using the correct method
                Console.WriteLine("enter in catch");
                Thread.Sleep(2500);
                //IWebElement element = driver.FindElement(addCart);
                click(addCart);
               
                // element.Click();
                b.AleartforCart();
            }
            catch (NoSuchElementException ex)
            {
                // Handle the case where the element is not found
                Console.WriteLine($"Element not found: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}

using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace demoBlaze
{
    public class PlaceAnOrder:BasePage{
        //click
        By cartLink = By.XPath("//*[@id=\"cartur\"]");
        //click
        By placeorder = By.XPath("/html/body/div[6]/div/div[2]/button");
        //write
        By name = By.Id("name");
        By country = By.Id("country");
        By city = By.Id("city");
        By cardNum = By.Id("card");
        By month = By.Id("month");
        By year = By.Id("year");
        //click
        By purchase = By.XPath("/html/body/div[3]/div/div/div[3]/button[2]");


        public void placeOrder(String Name, String Country, String City, String CardNum, String Month, String Year)
        {
            click(cartLink);
            Thread.Sleep(1500);
            click(placeorder);
            Thread.Sleep(500);
            write(name, Name);
            Thread.Sleep(500);
            write(country, Country);
            Thread.Sleep(500);
            write(city, City);
            Thread.Sleep(500);
            write(cardNum, CardNum);
            Thread.Sleep(500);
            write(month, Month);
            Thread.Sleep(500);
            write(year, Year);
            Thread.Sleep(500);
            click(purchase);

            // Handling possible modal dialogs
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                Console.WriteLine(alertText);
                alert.Accept();
            }
            catch (NoAlertPresentException)
            {
                // Handle the case when no alert is present
                Console.WriteLine("No alert found.");
            }

        }
    }
}

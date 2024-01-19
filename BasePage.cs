using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace demoBlaze
{
    public class BasePage
    {
        public static IWebDriver driver;
        public static string url = "https://www.demoblaze.com/";
        By SignUpLink = By.Id("signin2");

        ///Extent report var <summary>
        public TestContext testContext;
        //public static int MaxTimeToFindElement = Convert.ToInt32(ConfigurationManager.AppSettings["MaxTimeToFindElement"]);
        //        public static string ExecutionBrowser = ConfigurationManager.AppSettings["ExecutionBrowser"].ToString();

        public static string pathNameWithFileNameExtension;
        public static string dirpath;
        public static ExtentReports extentReports;
        public static ExtentTest Test;
        public static ExtentTest Steps;

        public static void CreateReport(string path)
        {
            extentReports = new ExtentReports();
            var sparkReporter = new ExtentSparkReporter(path);
            extentReports.AttachReporter(sparkReporter);

        }
        public static void takeScreenShot(Status status, string stepDetail)
        {
            string path = @"C:\Users\19-12-2023\Desktop\demoBlaze\Extentreport\images\" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".png";
            Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            File.WriteAllBytes(path, screenshot.AsByteArray);
            Steps.Log(status, stepDetail, MediaEntityBuilder.CreateScreenCaptureFromPath(path).Build());

        }

        /// 



        public static void setUp(String browser)
        {
            if (browser == "Chrome")
            {
                driver = new ChromeDriver();
                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl(url);
                //MessageBox.Show("Google opening");
                Console.WriteLine("Google opening");

            }
            else if (browser == "Firefox")
            {
                driver = new FirefoxDriver();
                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl(url);
                Console.WriteLine("Firefox opening");
            }
            else
            {
                Console.WriteLine("enter correct browser");
            }


        }
        public static void tearDown()
        {
            driver.Quit();
        }

        public void write(By by, String data)
        {
            try
            {
                driver.FindElement(by).SendKeys(data);
                takeScreenShot(Status.Pass, data + ": data enter successfully");
            }
            catch (Exception e)
            {
                takeScreenShot(Status.Fail, "Fail to enter data" + e);            
            }
           
        }
        public void click(By by)
        {
            driver.FindElement(by).Click();
        }
        public string GenerateRandomUsername()
        {
            string randomChars = Path.GetRandomFileName().Replace(".", "").Substring(0, 4);

            return "_" + randomChars;
        }
        public void scrollDown()
        {

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollBy(0, 400);"); // Scroll down by 500 pixels
        }
        public void ThreadSleepWait()
        {
            Thread.Sleep(4000);
        }
        public void AleartforCart()
        {
            //Console.WriteLine("Enter in Aleart Method");
            //IAlert alert = driver.SwitchTo().Alert();
            //String alertText = alert.Text;
            //Console.WriteLine("Prodduct is:" + alertText);
            //alert.Accept();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            // Check if the alert is present
            if (wait.Until(ExpectedConditions.AlertIsPresent()) != null)
            {
                // Retrieve and print the alert text
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                Console.WriteLine("Alert Text: " + alertText);

                // Handle the alert (Accept or Dismiss based on your requirement)
                alert.Accept();
                Console.WriteLine("product is added successfully");

            }
            else
            {
                // Handle the case when no alert is present (user successfully registered)
                Console.WriteLine("product does not added successfully");
            }
        }
        public void AleartforContact()
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            // Check if the alert is present
            if (wait.Until(ExpectedConditions.AlertIsPresent()) != null)
            {
                // Retrieve and print the alert text
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                Console.WriteLine("Alert Text: " + alertText);

                // Handle the alert (Accept or Dismiss based on your requirement)
                alert.Accept();
                Console.WriteLine("DemoBlaze says: " + alertText);

            }
            else
            {
                // Handle the case when no alert is present (user successfully registered)
                Console.WriteLine("Error");
            }
        }

        public bool isAleartPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException e)
            {
                return false;
            }
        }
    }
}

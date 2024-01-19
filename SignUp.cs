using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using SeleniumExtras.WaitHelpers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace demoBlaze
{
    public class SignUp : BasePage 
    {
        Login l = new Login();
       
        By SignUpLink = By.Id("signin2");
        By username = By.Id("sign-username");
        By password = By.Id("sign-password");
        By signUpBtn = By.XPath("//*[@id=\"signInModal\"]/div/div/div[3]/button[2]");
        By closeBtn = By.XPath("//*[@id=\"signInModal\"]/div/div/div[3]/button[1]");
        // TestExecution t = new TestExecution();

        public void Signup(String userName, String pass)
        {
            try
            {
                Steps = Test.CreateNode("SignPage");
                click(SignUpLink);
                write(username, userName);
                Thread.Sleep(500);
                write(password, pass);
                Thread.Sleep(500);
                click(signUpBtn);

                // Wait for the alert to be present
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));

                // Check if the alert is present
                if (wait.Until(ExpectedConditions.AlertIsPresent()) != null)
                {
                    // Retrieve and print the alert text
                    IAlert alert = driver.SwitchTo().Alert();
                    string alertText = alert.Text;
                    Console.WriteLine("Alert Text: " + alertText);

                    // Handle the alert (Accept or Dismiss based on your requirement)
                    alert.Accept();
                    // driver.FindElement(By.XPath("//*[@id=\"signInModal\"]/div/div/div[3]/button[1]")).Click();
                    click(closeBtn);
                    //   l.Login_Method(userName, pass);

                }
                else
                {
                    // Handle the case when no alert is present (user successfully registered)
                    Console.WriteLine("User successfully registered.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error during sign-up: " + ex.Message);
                // Handle the exception as needed
            }


        }
    }
}

using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace demoBlaze
{
    public class Login : BasePage
    {

        By loginLink = By.Id("login2");
        By username = By.Id("loginusername");
        By password = By.Id("loginpassword");
        By loginBtn = By.XPath("//*[@id=\"logInModal\"]/div/div/div[3]/button[2]");

        public void Login_Method(String userNAme, String pass)
        {
            Steps = Test.CreateNode("LoginPage");
            click(loginLink);
            Thread.Sleep(500);
            write(username, userNAme);
            Thread.Sleep(500);
            write(password, pass);
            Thread.Sleep(500);
            click(loginBtn);

            // String actualRes = driver.FindElement(By.Id("nameofuser")).Text;
            // Assert.AreEqual("Welcome hashir103", actualRes);
        }
    }
}

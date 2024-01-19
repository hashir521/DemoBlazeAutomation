using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace demoBlaze
{
    public class Contact : BasePage
    {
        By ContactLink = By.CssSelector("li.nav-item:nth-child(2) > a:nth-child(1)");
        By contactEmail = By.Id("recipient-email");
        By contactName = By.Id("recipient-name");
        By MessageText = By.Id("message-text");
        By sendMessage = By.XPath("/html/body/div[1]/div/div/div[3]/button[2]");

        public void cotactPage(String email, String name, String mesgText)
        {
            Thread.Sleep(1500);
            click(ContactLink);
            write(contactEmail, email);
            Thread.Sleep(500);
            write(contactName, name);
            Thread.Sleep(500);
            write(MessageText, mesgText);
            Thread.Sleep(500);
            click(sendMessage);
            AleartforContact();



        }
    }
}

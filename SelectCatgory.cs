using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demoBlaze
{
    public class SelectCatgory : BasePage{
        By Phones = By.Id("itemc");
        /// after this click some scroll
        By selectMobile = By.XPath("//*[@id=\"tbodyid\"]/div[4]/div/div/h4/a");

        public void selectCategory()
        {
            click(Phones);
            ThreadSleepWait();
            scrollDown();
            click(selectMobile);

        }
    }
}

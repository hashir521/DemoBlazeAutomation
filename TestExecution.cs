using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Configuration;
using System.IO;
using System.Threading;

namespace demoBlaze
{
    [TestClass]
    public class TestExecution : BasePage
    {
        BasePage b = new BasePage();
        SignUp s = new SignUp();
        Login l = new Login();
        Category c = new Category();
        AddToCart a = new AddToCart();
        SelectCatgory select = new SelectCatgory();
        PlaceAnOrder p = new PlaceAnOrder();
        Contact con = new Contact();
        String user;
        String pass;
        public TestContext instance;

        //Assembly
        [AssemblyInitialize()]
        public static void AssemblyInit(TestContext context)
        {
            string ResultFile = @"C:\Users\19-12-2023\Desktop\demoBlaze\Extentreport\" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".html";
            CreateReport(ResultFile);
        }
        [AssemblyCleanup()]
        public static void AssemblyCleanUp()
        {
            extentReports.Flush();
        }
        public TestContext TestContext
        {
            set
            {
                instance = value;
            }
            get
            {
                return instance;
            }

        }
        [TestInitialize]
        public void TestInit()
        {
            Test = extentReports.CreateTest(TestContext.TestName);
            BasePage.setUp(ConfigurationManager.AppSettings["browser"].ToString());
          
        }
        [TestCleanup]
        public void TestCleanup()
        {
            BasePage.tearDown();
        }

        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "Data.xml", "TestMethod1", DataAccessMethod.Sequential)]
        public void TestMethod1()
        {

            // Generate a random username and merge it with the data from the external source
            string randomUsername = GenerateRandomUsername();
            user = TestContext.DataRow["username"].ToString() + randomUsername;
            pass = TestContext.DataRow["password"].ToString();
            //for contact page
            string contactEmail = TestContext.DataRow["contactEmail"].ToString();
            string contactName = TestContext.DataRow["contactName"].ToString();
            string contactMessage = TestContext.DataRow["contactMessage"].ToString();
            //For place an order page
            string orderName = TestContext.DataRow["orderName"].ToString();
            string orderCountry = TestContext.DataRow["orderCountry"].ToString();
            string orderCity = TestContext.DataRow["orderCity"].ToString();
            string orderZipCode = TestContext.DataRow["orderZipCode"].ToString();
            string orderMonth = TestContext.DataRow["orderMonth"].ToString();
            string orderYear = TestContext.DataRow["orderYear"].ToString();

            // Method calling
            s.Signup(user, pass);
            l.Login_Method(user, pass);
            Console.WriteLine("user is:" + user);
            con.cotactPage(contactEmail, contactName, contactMessage);
            ThreadSleepWait();
            b.scrollDown();

            //category
            ThreadSleepWait();
            select.selectCategory();
            a.addToCart();
            p.placeOrder(orderName, orderCountry, orderCity, orderZipCode, orderMonth, orderYear);
            Thread.Sleep(1000);


        }

    }
}

using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NunitFrameworkBasic
{
    public class Nunit
    {
        ChromeDriver driver;

        [SetUp]
        public void Initialize()
        {
         

            ChromeOptions option = new ChromeOptions();
            option.AddArgument("headless");
             driver = new ChromeDriver(option);
            driver.Navigate().GoToUrl("https://demo.nopcommerce.com");// This has to define at the top level,otherwise you need to define at all the subesquent test.
        }

        [Test, Order(1)]
        public void OpenWebsite()
        {
          
            Thread.Sleep(3000);
            System.Console.WriteLine(driver.Title);
           String X = "Welcome to our store"; //Tests whether the specified condition is true and throws an exception if the condition is false.
                 Assert.IsTrue(driver.PageSource.Contains(X));
              
        }

     [Test,Order(2)]

     public void Textverification()
        {
         
            IWebElement Link = driver.FindElement(By.LinkText("Apparel"));
            string actualvalue = Link.GetAttribute("text");//Get link lable
            //Assert.AreEqual(actualvalue, "Apparel");
            System.Console.WriteLine("The link lable is" + actualvalue);
        }



        [TearDown]
        public void EndTest()
        {
            driver.Close();
            driver.Quit();
        }

    }
}

//https://www.youtube.com/watch?v=0gSDYRbtwmw
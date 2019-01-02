using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

namespace OpenQA
{
    class NUnitTest
    {
        //public void TestApp()
        //{
        //    IWebDriver driver = new ChromeDriver();
        //    driver.Url = "http://www.demoqa.com";
        //    driver.Close();
        //}
        IWebDriver driver;
        [SetUp]
        public void Initialize()
        {
            driver = new ChromeDriver();
        }
        [Test]
        public void OpenAppTest()
        {
            driver.Url = "http://www.demoqa.com";
        }
        [TearDown]
        public void EndTest()
        {
            driver.Close();
        }
        
        
    }
}

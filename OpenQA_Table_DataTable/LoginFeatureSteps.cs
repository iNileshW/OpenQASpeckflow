using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using System.Data;
using OpenQA_Table_DataTable.Utils;

namespace OpenQA_Table_DataTable
{
    [Binding]
    public sealed class LoginFeatureSteps
    {
        // For additional details on SpecFlow step definitions see http://go.specflow.org/doc-stepdef
        public IWebDriver driver;
        [Given(@"User is at the Home Page")]
        public void GivenUserIsAtTheHomePage()
        {
            driver = new ChromeDriver();
            driver.Url = "http://www.store.demoqa.com"; 
        }

        [Given(@"Navigate to LogIn Page")]
        public void GivenNavigateToLogInPage()
        {
            driver.FindElement(By.XPath(".//*[@id='account']/a")).Click();
        }

        [When(@"User enter credentials")]
        public void WhenUserEnterCredentials(Table table)
        {
            var dataTable = TableExtensions.ToDataTable(table);
            foreach (DataRow row in dataTable.Rows)
            {
                driver.FindElement(By.Id("log")).SendKeys(row.ItemArray[0].ToString());
                driver.FindElement(By.Id("pwd")).SendKeys(row.ItemArray[1].ToString());
                driver.FindElement(By.Id("login")).Click();
                driver.FindElement(By.Id("log")).Clear();
                driver.FindElement(By.Id("pwd")).Clear();
            }
        }
        [When(@"Click on the LogIn button")]
        public void WhenClickOnTheLogInButton()
        {
            driver.FindElement(By.Id("login")).Click();
        }

        [Then(@"Successful LogIN message should display")]
        public void ThenSuccessfulLogINMessageShouldDisplay()
        {
            true.Equals(driver.FindElement(By.XPath(".//*[@id='account_logout']/a")).Displayed);
        }

        [When(@"User LogOut from the Application")]
        public void WhenUserLogOutFromTheApplication()
        {
            //ScenarioContext.Current.Pending();
        }

        [Then(@"Successful LogOut message should display")]
        public void ThenSuccessfulLogOutMessageShouldDisplay()
        {
            //ScenarioContext.Current.Pending();
        }

    }
}


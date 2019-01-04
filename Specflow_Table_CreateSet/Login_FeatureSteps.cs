using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using System.Data;
using Specflow_Table_CreateSet.Utils;

namespace Specflow_Table_CreateSet
{
    public class Login_FeatureSteps
    {
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
            var credentials = table.CreateSet<Credentials>();
            foreach (var userData in credentials)
            {
                driver.FindElement(By.Id("log")).SendKeys(userData.Username);
                driver.FindElement(By.Id("pwd")).SendKeys(userData.Password);
                driver.FindElement(By.Id("login")).Click();
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

using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using UnitTestProject1.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;

namespace UnitTestProject1.FeatureStepDefinitions
{
    [Binding]
    public class SeleniumAutomationStepDefinition
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        public readonly ScenarioContext _scenarioContext;
        public IWebDriver driver;
        public SeleniumAutomationStepDefinition(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            var driverhelper = new DriverHelper();
            driver = driverhelper.InitializeDriver(driver);
        }


        [Given(@"the user enters the URL in Chrome browser")]
        public void GivenTheUserEntersTheURLInChromeBrowser()
        {
            try
            {
                driver.Navigate().GoToUrl("https://www.moneycorp.com/en-gb/");
                driver.Manage().Window.Maximize();
                
            }
            catch (Exception e)
            {
                driver.Close();
                driver.Dispose();
                Assert.Fail(e.Message);
            }
        }

        [Then(@"verifies the URL of the opened pge")]
        public void ThenVerifiesTheURLOfTheOpenedPge()
        {
            try
            {
                string url = driver.Url;
                Assert.AreEqual(url, "https://www.moneycorp.com/en-gb/");
            }
            catch (Exception e)
            {
                driver.Close();
                driver.Dispose();
                Assert.Fail(e.Message);
            }
        }

        [Then(@"changes the language and region")]
        public void ThenChangesTheLanguageAndRegion()
        {
            try
            {
                driver.FindElement(By.XPath("//*[@id='language-dropdown-flag']")).Click();
                driver.FindElement(By.XPath("(//*[@class='country-language'])[9]")).Click();
                
            }
            catch (Exception e)
            {
                driver.Close();
                driver.Dispose();
                Assert.Fail(e.Message);
            }
        }

        [Then(@"verifies the changed language and region")]
        public void ThenVerifiesTheChangedLanguageAndRegion()
        {
            driver.FindElement(By.XPath("//*[@id='language-dropdown-flag']")).Click();
            string Country = driver.FindElement(By.XPath("(//*[@class='country-language'])[1]/span")).Text;
            Assert.AreEqual(Country, "USA");
            string url = driver.Url;
            Assert.AreEqual(url, "https://www.moneycorp.com/en-us/");
                       
        }

        [Then(@"Clicks on the Find out more button for Foreign exchange solutions")]
        public void ThenClicksOnTheFindOutMoreButtonForForeignExchangeSolutions()
        {
            var FindOutMore = driver.FindElement(By.XPath("//*[contains (text(), 'Business Solutions - manage risk & send global payments')]"));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", FindOutMore);
            var dWait = new WebDriverWait(driver, TimeSpan.FromSeconds(45));
            driver.FindElement(By.XPath("(//span[contains(text(), 'Find out more')])[1]")).Click();

            //IWebElement dynamicElement = dWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("(//span[contains(text(), 'Find out more')])[1]")));

            //Actions action = new Actions(driver);
            //action.MoveToElement(FindOutMore).Build().Perform();            

        }

        [Then(@"verifies the page where it has taken the user")]
        public void ThenVerifiesThePageWhereItHasTakenTheUser()
        {
            try
            {
                //IList<WebElement> elements = (IList<WebElement>)driver.FindElements(By.XPath("//*[contains(text(), 'Corporate foreign exchange')]"));

                int elements = driver.FindElements(By.XPath("//*[contains(text(), 'Corporate foreign exchange')]")).Count;
                if (elements == 0)
                {
                    Assert.Fail("Wrong Page Reched");
                }

            }
            catch (Exception e)
            {
                driver.Close();
                driver.Dispose();
                Assert.Fail(e.Message);
            }
        }

        [Then(@"search International Payments in the search box")]
        public void ThenSearchInternationalPaymentsInTheSearchBox()
        {
            driver.FindElement(By.XPath("(//input[@id='nav_search'])[2]")).SendKeys("International Payments"+ Keys.Enter);
            
        }

        [Then(@"verifies the page has taken the user to results page")]
        public void ThenVerifiesThePageHasTakenTheUserToResultsPage()
        {
            string url = driver.Url;
            Assert.AreEqual(url, "https://www.moneycorp.com/en-gb/search/?q=International+Payments");
        
        }
        
            
        




        [AfterScenario]

        public void AfterScenario()
        {
            driver.Close();
        }
    }


         
}

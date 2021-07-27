using JupiterFramework.Global;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Threading;

namespace JupiterFramework.Pages
{
    class HomePage
    {
        public HomePage()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }
        //Finding the Login Button
        [FindsBy(How = How.XPath, Using = "//a[contains(.,'Home')]")]
        private IWebElement HomeBtn { get; set; }

        internal void HomeStep()
        {
            Thread.Sleep(6000);
            //Click login
            HomeBtn.Click();
            try
            {
                
                
                
                //Validating if the Url is correct Homepage

               // GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, "XPath", "//h1[contains(.,'Jupiter Toys')]", 10000);
                // check login is successfull
                var PageCheck = "test";
                PageCheck = GlobalDefinitions.driver.FindElement(By.XPath("//h1[contains(.,'Jupiter Toys')]")).GetAttribute("innerText");

                Assert.That(PageCheck == "Jupiter Toys");
            }
            catch (Exception ex)
            {
                Assert.Fail("Test failed at login step", ex.Message);
            }

        }

    }
}
using JupiterFramework.Global;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Threading;

namespace JupiterFramework.Pages
{
    internal class ContactPage
    {
        public ContactPage()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        #region Initialize web elements
        //Click on ContactPage Button
        [FindsBy(How = How.XPath, Using = "//a[contains(.,'Contact')]")]
        private IWebElement ContactBtn { get; set; }

        //Click on submit button
        [FindsBy(How = How.XPath, Using = "//a[contains(.,'Submit')]")]
        private IWebElement SubmitBtn { get; set; }

        //Enter the Title Header
        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'alert alert-error ng-scope')]")]
        private IWebElement TitleHead { get; set; }

        //Enter the Forename in textbox
        [FindsBy(How = How.XPath, Using = "//input[@id='forename']")]
        private IWebElement Forenametxtbx { get; set; }


        //Enter Surname in textbox
        [FindsBy(How = How.XPath, Using = "//input[@id='email']")]
        private IWebElement Email { get; set; }

        //Enter Messafw in textbox
        [FindsBy(How = How.XPath, Using = "//textarea[@id='message']")]
        private IWebElement Message { get; set; }

        String TileCheck = "We welcome your feedback - but we won't get it unless you complete the form correctly.";

        //Thanks you Header
        [FindsBy(How = How.XPath, Using = "//div[@class='alert alert-success'][contains(.,'Thanks John, we appreciate your feedback.')]")]
        private IWebElement ThankyouHeader { get; set; }
        #endregion
        #region Enter ContactPage Data
        //Add share skill details
        internal void EnterContactPageData()
        {
            //Populate the excel data

            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ContactPage");

            try
            {
                
                //Click on Contact Btn button
                GlobalDefinitions.WaitForElementClickable(GlobalDefinitions.driver, "XPath", "//a[contains(.,'Contact')]", 10000);
                ContactBtn.Click();

                GlobalDefinitions.WaitForElementClickable(GlobalDefinitions.driver, "XPath", "//input[@id='forename']", 10000);
                Forenametxtbx.Click();
                Forenametxtbx.Clear();
                Forenametxtbx.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Forename"));


                
                //Enter the Email in textbox
                GlobalDefinitions.WaitForElementClickable(GlobalDefinitions.driver, "XPath", "//input[@id='email']", 10000);
                
                Email.Click();
                Email.Clear();
                Email.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Email"));
                


                //Enter the Message in textbox
                GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, "XPath", "//textarea[@id='message']", 10000);
                
                Message.Click();
                Message.Clear();
                Message.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Message"));

                Thread.Sleep(3000);
                //Click on submit button
                GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, "XPath", "//a[contains(.,'Submit')]", 10000);

                SubmitBtn.Click();

                Thread.Sleep(6000);

                //Verification of Submission Message
                var ActualTitle = "Thanks John, we appreciate your feedback.";
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//div[contains(@class,'alert alert-success')]", 10000);
                var checktitle = GlobalDefinitions.driver.FindElement(By.XPath("//div[contains(@class,'alert alert-success')]")).GetAttribute("textContent");
                Assert.That(checktitle, Is.EqualTo(ActualTitle));
                // Assert.IsTrue(checktitle.Contains("Thanks John, we appreciate your feedback."));
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Details Added Succesfully");
            }

            catch (Exception ex)
            {
                Assert.Fail("Test failed to enter Skill details", ex.Message);
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Details not added");
            }
        }
        #endregion



        #region Enter Invalid ContactPage Data
        //The Application Accepts All Data Except Null Data
        internal void EnterInvalidContactPageData()
        {
            //Populate the excel data

            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ContactPage");

            try
            {
                Thread.Sleep(3000);


                //Click on Contact Btn button
                GlobalDefinitions.WaitForElementClickable(GlobalDefinitions.driver, "XPath", "//a[contains(.,'Contact')]", 10000);
                ContactBtn.Click();

                // GlobalDefinitions.WaitForTextPresentInElement(GlobalDefinitions.driver, TitleHead, TitleCheck, 10000);

                // GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//a[contains(.,'Submit')]", 10000);
                //  SubmitBtn.Click();

                //Enter the Forename in textbox


                GlobalDefinitions.WaitForElementClickable(GlobalDefinitions.driver, "XPath", "//input[@id='forename']", 10000);
                Forenametxtbx.Click();
                Forenametxtbx.Clear();
                Forenametxtbx.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "Forename"));


                Thread.Sleep(3000);
                //Enter the Email in textbox
                GlobalDefinitions.WaitForElementClickable(GlobalDefinitions.driver, "XPath", "//input[@id='email']", 10000);
                Thread.Sleep(3000);
                Email.Click();
                Email.Clear();
                Email.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "Email"));
                Thread.Sleep(3000);


                //Enter the Message in textbox
                GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, "XPath", "//textarea[@id='message']", 10000);
                Thread.Sleep(3000);
                Message.Click();
                Message.Clear();
                Message.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "Message"));

                Thread.Sleep(3000);
                //Click on submit button
                GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, "XPath", "//a[contains(.,'Submit')]", 10000);

                SubmitBtn.Click();

                Thread.Sleep(6000);
                var ActualTitle = "Thanks John, we appreciate your feedback.";
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//div[contains(@class,'alert alert-success')]", 10000);
                var checktitle = GlobalDefinitions.driver.FindElement(By.XPath("//div[contains(@class,'alert alert-success')]")).GetAttribute("textContent");
                Assert.That(checktitle, Is.EqualTo(ActualTitle));
                // Assert.IsTrue(checktitle.Contains("Thanks John, we appreciate your feedback."));
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Details Added Succesfully");
            }

            catch (Exception ex)
            {
                Assert.Fail("Test failed to enter Skill details", ex.Message);
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Details not added");
            }
        }
        #endregion

        #region Enter Null Data ContactPage
        //TestCase 1 , Clicking on the Submit Button without Data 
        internal void EnterNullContactPageData()
        {
            //Populate the excel data

            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ContactPage");

            try
            {
                Thread.Sleep(3000);


                //Click on Contact Btn button
                GlobalDefinitions.WaitForElementClickable(GlobalDefinitions.driver, "XPath", "//a[contains(.,'Contact')]", 10000);
                ContactBtn.Click();

                

                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//a[contains(.,'Submit')]", 10000);
                SubmitBtn.Click();

                var TitleCheck = GlobalDefinitions.driver.FindElement(By.XPath("//div[contains(@class,'alert alert-error ng-scope')]")).GetAttribute("textContent");
                if (TileCheck == TitleCheck)

                {
                    EnterContactPageData();
                }


                //Enter the Forename in textbox
                Thread.Sleep(3000);
                //Enter the Forename in textbox


                GlobalDefinitions.WaitForElementClickable(GlobalDefinitions.driver, "XPath", "//input[@id='forename']", 10000);
                Forenametxtbx.Click();
                Forenametxtbx.Clear();
               


                Thread.Sleep(3000);
                //Enter the Email in textbox
                GlobalDefinitions.WaitForElementClickable(GlobalDefinitions.driver, "XPath", "//input[@id='email']", 10000);
                Thread.Sleep(3000);
                Email.Click();
                Email.Clear();
                
                Thread.Sleep(3000);


                //Enter the Message in textbox
                GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, "XPath", "//textarea[@id='message']", 10000);
                Thread.Sleep(3000);
                Message.Click();
                Message.Clear();
                

                Thread.Sleep(3000);
                //Click on submit button
                GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, "XPath", "//a[contains(.,'Submit')]", 10000);

                SubmitBtn.Click();

                Thread.Sleep(6000);
                var ActualTitle1 = "We welcome your feedback - but we won't get it unless you complete the form correctly.";
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//div[contains(@class,'alert alert-error ng-scope')]", 10000);
                var checktitle1 = GlobalDefinitions.driver.FindElement(By.XPath("//div[contains(@class,'alert alert-error ng-scope')]")).GetAttribute("textContent");
                Assert.That(checktitle1, Is.EqualTo(ActualTitle1));
               
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Null Data Succesfully");

            }

            catch (Exception ex)
            {
                Assert.Fail("Test failed to enter Skill details", ex.Message);
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Null Data Not Successfull");
            }
        }
        #endregion
    }
}

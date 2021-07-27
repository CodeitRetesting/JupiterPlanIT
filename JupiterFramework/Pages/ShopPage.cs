using JupiterFramework.Global;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Threading;

namespace JupiterFramework
{
    internal class ShopPage
    {

        public ShopPage()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        #region  Initialize Web Elements 
        //Click on Buy Button Teddy Bear button
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[2]/div/span/i")]
        private IWebElement BuyTeddy { get; set; }

        //Click on Buy Button Stuffed Frog button
        [FindsBy(How = How.Name, Using = "availabiltyType")]
        private IWebElement BuyFrog { get; set; }


        //Click  on Buy Button HandMade Doll
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[3]/div/span/i")]
        private IWebElement BuyHandmade { get; set; }


        //Click  on Buy Button Fluffy Bunny Doll
        [FindsBy(How = How.XPath, Using = "(//a[contains(.,'Buy')])[4]")]
        private IWebElement BuyFluffyBunny { get; set; }


        //Click  on Buy Button Fluffy Smiley Bear
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[4]/div/span/i")]
        private IWebElement BuySmileyBear { get; set; }

        ////Click  on Buy Funny Cow
        [FindsBy(How = How.XPath, Using = "(//a[contains(.,'Buy')])[6]")]
        private IWebElement BuyFunnyCow { get; set; }

        //Click  on Buy Button Valentine Bear
        [FindsBy(How = How.XPath, Using = "")]
        private IWebElement BuyValentineBear { get; set; }


        //Click  On Cart Button
        [FindsBy(How = How.XPath, Using = "//a[contains(.,'Cart')]")]
        private IWebElement CartBtn { get; set; }

        //Quantity Button
        [FindsBy(How = How.XPath, Using = "//body")]
        private IWebElement QuantityBtn { get; set; }

        //Shop PageButton
        [FindsBy(How = How.XPath, Using = "//a[contains(.,'Shop')]")]
        private IWebElement ShopBtn { get; set; }
        //Shop Cart Count
        [FindsBy(How = How.XPath, Using = "//*[@id='nav - cart']/a/span")]
        private IWebElement CartCount { get; set; }




        #endregion

        //Add Items to Cart
        internal void AddToShopCart()
        {
            //Populate the excel data

            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ShopPage");


            #region Shopping Data
            try
            {
                //Navigate to Shopping 
                GlobalDefinitions.WaitForElementClickable(GlobalDefinitions.driver, "XPath", "//a[contains(.,'Shop')]", 10000);
                ShopBtn.Click();


                Thread.Sleep(3000);




                // Click on Funny Cow

                //   int k = (Convert.ToInt32((Global.GlobalDefinitions.ExcelLib.ReadData(2, "Funny Cow"))));

                for (int i = 0; i < (Convert.ToInt32((Global.GlobalDefinitions.ExcelLib.ReadData(2, "Funny Cow")))); i++)
                {
                    //  GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//a[contains(.,'Buy')])[6]", 10000);
                    BuyFunnyCow.Click();

                }



                // Click on Fluffy Bunny

                for (int j = 0; j < (Convert.ToInt32((Global.GlobalDefinitions.ExcelLib.ReadData(2, "Fluffy Bunny")))); j++)
                {
                    // GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//a[contains(.,'Buy')])[4]", 10000);
                    BuyFluffyBunny.Click();
                }

                // Click on Cart;

                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//a[contains(.,'Cart')]", 10000);
                Thread.Sleep(5000);
                CartBtn.Click();


            }
            catch (Exception ex)
            {
                Assert.Fail("Test failed Click on Items", ex.Message);
            }

            try
            {
                //Read and Compare Excel Data
                var ValidateFirstItem = GlobalDefinitions.driver.FindElement(By.XPath("//td[@class='ng-binding'][contains(.,'Funny Cow')]")).GetAttribute("textContent");


                var ValidateSecondItem = GlobalDefinitions.driver.FindElement(By.XPath("//td[@class='ng-binding'][contains(.,'Fluffy Bunny')]")).GetAttribute("textContent");


                var ValidateFirstQuantity = GlobalDefinitions.driver.FindElement(By.XPath("(//input[@name='quantity'])[1]")).GetAttribute("textContent");


                var ValidateSecondQuantity = GlobalDefinitions.driver.FindElement(By.XPath("(//input[@name='quantity'])[2]")).GetAttribute("textContent");

                Assert.That(ValidateFirstItem, Is.EqualTo("Funny Cow"));
                Assert.That(ValidateSecondItem, Is.EqualTo("Fluffy Bunny"));
                Assert.That(ValidateFirstQuantity, Is.EqualTo("2"));
                Assert.That(ValidateSecondQuantity, Is.EqualTo("1"));
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Items added successfully");
            }
            catch (Exception ex)
            {
                Assert.Fail("verify the share skill page failed", ex.Message);
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Items not added");

            }


        }
        #endregion
       
    }



}

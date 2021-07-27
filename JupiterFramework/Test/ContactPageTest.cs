using JupiterFramework.Pages;
using NUnit.Framework;

namespace JupiterFramework
{
    public class ContactPageTest
    {
        [TestFixture, Description("this fixture contains Jupiter Framework")]
        [Category("Sprint1")]
        class User : Global.Base
        { 

            [Test, Order(2), Description("Check if the user is able to EnterContactPage Data successfully")]
            public void EnterValidData()
            {
                test = extent.StartTest("Add Valid ShopPage Data");
                ContactPage contactpageObj = new ContactPage();
                contactpageObj.EnterContactPageData();

            }



            #region Validate Errors page
            [Test, Order(3), Description("Test Case 3,Check if the user is able to EnterContactPage Data successfully")]
            public void EnterInvalidData()
            {
                test = extent.StartTest("Add Invalid Data");
                ContactPage contactObj = new ContactPage();
                contactObj.EnterInvalidContactPageData();

            }
            #endregion

            #region Validate Null Data page
            [Test, Order(1), Description("Test Case 1,Check if the user is able to Null Data into ContactPage successfully")]
            public void EnterNullData()
            {
                test = extent.StartTest("Add Null Data");
                ContactPage contactObj = new ContactPage();
                contactObj.EnterNullContactPageData();

            }
            #endregion
        }
    }
}
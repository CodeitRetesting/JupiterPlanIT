using JupiterFramework.Pages;
using NUnit.Framework;

namespace JupiterFramework
{
    public class ShopPageTest
    {
        [TestFixture, Description("this fixture contains Jupiter Framework")]
        [Category("Sprint1")]
        class User : Global.Base
        {

            #region Validate Errors page
            [Test, Description("Check The Quantity of Items in Shopping cart")]
            public void ShoppingCart()
            {
                test = extent.StartTest("Add ShopPage Data");
                ShopPage shopObj = new ShopPage();
                shopObj.AddToShopCart();
                

            }

            #endregion


         



           

            
        }
    }
}
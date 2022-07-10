using MyStoreProject.Com.ActionDriver;
using MyStoreProject.Com.Base;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace MyStoreProject.Com.PageObjects
{
    public class MyAccountPage: BaseClass
    {
        BasicAction action;

        [FindsBy(How = How.XPath, Using = "//span[text()='My wishlists']")]
        IWebElement myWishlist;

        [FindsBy(How = How.XPath, Using = "//span[text()='Order history and details']")]
        IWebElement orderHistoryAndDetails;

        [FindsBy(How = How.XPath, Using = "//span[text()='My credit slips']")]
        IWebElement mycreditSlip;

        [FindsBy(How = How.XPath, Using = "//span[text()='My addresses']")]
        IWebElement myAddresses;

        [FindsBy(How = How.XPath, Using = "//span[text()='My personal information']")]
        IWebElement myPersonalInformation;

        [FindsBy(How = How.XPath, Using = "//span[text()=' Home']")]
        IWebElement homeBtn;


        public MyAccountPage(IWebDriver driver) : base(driver)
        {
            action = new BasicAction(GetDriver());
            PageFactory.InitElements(GetDriver(), this);
        }
        

        public bool ValidateMyWishlist()
        {
            return action.IsDisplayed(GetDriver(), myWishlist);
        }

        public bool ValidateOrderHistory()
        {
            return action.IsDisplayed(GetDriver(), orderHistoryAndDetails);
            
        }
    }
}

using MyStoreProject.Com.ActionDriver;
using MyStoreProject.Com.Base;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace MyStoreProject.Com.PageObjects
{
    public class AddressPage : BaseClass
    {
        BasicAction action;

        [FindsBy(How = How.XPath, Using = "//span[text()='Proceed to checkout']")]
        IWebElement _proceedToCheckoutBtn;

        public AddressPage(IWebDriver driver): base(driver)
        {
            action = new BasicAction(GetDriver());
            PageFactory.InitElements(GetDriver(), this);
        }

        public ShippingPage ClickOnCheckOut()
        {
            _proceedToCheckoutBtn.Click();
            return new ShippingPage(GetDriver());
        }
    }
}

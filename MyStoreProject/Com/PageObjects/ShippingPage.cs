using MyStoreProject.Com.ActionDriver;
using MyStoreProject.Com.Base;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace MyStoreProject.Com.PageObjects
{
    public class ShippingPage : BaseClass
    {


        [FindsBy(How = How.Id, Using = "cgv")]
        IWebElement agreeCheckBox;

        [FindsBy(How = How.XPath, Using = "//button[@name='processCarrier']")]
        IWebElement proceedToCheckoutBtn;
        public ShippingPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(GetDriver(), this);
        }


        public void ClickAgreeCheckBox()
        {
            agreeCheckBox.Click();
        }

        public PaymentPage ClickOnProceedToCheckOut()
        {
            proceedToCheckoutBtn.Click();
            return new PaymentPage(GetDriver());
        }
    }

}

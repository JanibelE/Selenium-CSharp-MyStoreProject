using MyStoreProject.Com.ActionDriver;
using MyStoreProject.Com.Base;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace MyStoreProject.Com.PageObjects
{
    public class PaymentPage : BaseClass
    {
        BasicAction action;

        [FindsBy(How = How.XPath, Using = "//a[@title='Pay by check']")]
        IWebElement payByCheckMethod;


        [FindsBy(How = How.XPath, Using = "//a[@title='Pay by bank wire']")]
        IWebElement payByBankWireMethod;

        public PaymentPage(IWebDriver driver) : base(driver)
        {
            action = new BasicAction(GetDriver());
            PageFactory.InitElements(GetDriver(), this);
        }

        public OrderSummaryPage ClickOnBankWirePaymentMethod()
        {
            action.JSClick(GetDriver(),payByBankWireMethod);
            return new OrderSummaryPage(GetDriver());
        }

    }
}

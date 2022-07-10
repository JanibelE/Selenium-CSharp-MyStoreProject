using MyStoreProject.Com.ActionDriver;
using MyStoreProject.Com.Base;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Text.RegularExpressions;

namespace MyStoreProject.Com.PageObjects
{
    public class OrderSummaryPage : BaseClass
    {


        [FindsBy(How = How.XPath, Using = "//span[text()='I confirm my order']")]
        IWebElement confirmMyOrderBtn;
        public OrderSummaryPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(GetDriver(),this);
        }

        public OrderConfirmationPage ClickOnConfirm()
        {
            confirmMyOrderBtn.Click();
            return new OrderConfirmationPage(GetDriver());
        }

    }
}

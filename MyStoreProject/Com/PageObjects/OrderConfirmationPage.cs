using MyStoreProject.Com.ActionDriver;
using MyStoreProject.Com.Base;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace MyStoreProject.Com.PageObjects
{
    public class OrderConfirmationPage : BaseClass
    {


        [FindsBy(How = How.XPath, Using = "//strong[text()='Your order on My Store is complete.']")]
        IWebElement orderIsCompleteText;

        public OrderConfirmationPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(GetDriver(), this);
        }

        public string ValidateConfirmMessage()
        {
            return orderIsCompleteText.Text;
        }

    }
}

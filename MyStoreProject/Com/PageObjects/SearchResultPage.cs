using MyStoreProject.Com.ActionDriver;
using MyStoreProject.Com.Base;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace MyStoreProject.Com.PageObjects
{
    public class SearchResultPage: BaseClass
    {
        BasicAction action;

        [FindsBy(How = How.XPath, Using = "//*[@id='center_column']//img")]
        IWebElement productResult;

        public SearchResultPage(IWebDriver driver) : base(driver)
        {
            action = new BasicAction(GetDriver());
            PageFactory.InitElements(GetDriver(), this);
        }

        public bool IsProductAvailable()
        {
            return action.IsDisplayed(GetDriver(), productResult);
        }

        public AddToCartPage ClickOnProduct()
        {
            productResult.Click();
            return new AddToCartPage(GetDriver());
        }
    }
}

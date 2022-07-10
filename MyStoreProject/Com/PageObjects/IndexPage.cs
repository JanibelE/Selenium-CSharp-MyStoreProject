
using MyStoreProject.Com.ActionDriver;
using MyStoreProject.Com.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace MyStoreProject.Com.PageObjects
{
    public class IndexPage: BaseClass
    {
        BasicAction action;

        [FindsBy(How = How.XPath, Using = "//a[@class='login']")]
        IWebElement signInBtn;

        [FindsBy(How = How.Id, Using = "search_query_top")]
        IWebElement searchProductBox;

        [FindsBy(How = How.XPath, Using = "//img[@class='logo img-responsive']")]
        IWebElement myStoreLogo;

        [FindsBy(How = How.Name, Using = "submit_search")]
        IWebElement searchBtn;

        public IndexPage(IWebDriver driver) : base(driver)
        {
            action = new BasicAction(GetDriver());
            PageFactory.InitElements(GetDriver(), this);
        }

        public LoginPage ClickOnSignIn()
        {
            Thread.Sleep(1500);
            //action.WaitForElement(GetDriver(), By.XPath("//a[@class='login']"));
            
            signInBtn.Click();
            
            return new LoginPage(GetDriver());
        }

        public bool ValidateLogo()
        {
            return action.IsDisplayed(GetDriver(),myStoreLogo);
        }

        public string GetMyStoreTitle(IWebDriver driver)
        {
            return action.GetPageTitle(driver);
        }

        public SearchResultPage SearchProduct(string product)
        {
            action.TypeKeys(searchProductBox,product);
            Thread.Sleep(1500);
            searchBtn.Click();
            return new SearchResultPage(GetDriver());
        }



    }
}

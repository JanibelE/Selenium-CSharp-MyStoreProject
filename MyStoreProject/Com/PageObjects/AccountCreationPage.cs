using MyStoreProject.Com.ActionDriver;
using MyStoreProject.Com.Base;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace MyStoreProject.Com.PageObjects
{
    public class AccountCreationPage:BaseClass
    {

        BasicAction action;

        [FindsBy(How = How.Id, Using = "id_gender1")]
        IWebElement Mr;

        [FindsBy(How = How.Id, Using = "id_gender2")]
        IWebElement Mrs;

        [FindsBy(How = How.XPath, Using = "//h1[text()='Create an account']")]
        IWebElement createAccountTitle;

        public AccountCreationPage(IWebDriver driver): base(driver)
        {
            action = new BasicAction(GetDriver());
            PageFactory.InitElements(GetDriver(), this);
        }
        
        public bool ValidateCreateAccountPage()
        {
            return action.IsDisplayed(GetDriver(), createAccountTitle);
        }

    }
}

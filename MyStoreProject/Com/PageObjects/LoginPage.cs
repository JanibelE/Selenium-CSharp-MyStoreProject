
using MyStoreProject.Com.ActionDriver;
using MyStoreProject.Com.Base;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
/// <summary>
/// 
/// </summary>
namespace MyStoreProject.Com.PageObjects
{
    public class LoginPage: BaseClass
    {
        BasicAction action ;

        [FindsBy(How = How.Id, Using = "email")]
        IWebElement username;

        [FindsBy(How = How.Id, Using = "passwd")]
        IWebElement password;

        [FindsBy(How = How.Id, Using = "SubmitLogin")]
        IWebElement signInBtn;

        [FindsBy(How = How.XPath, Using = "//p[@class='lost_password form-group']/a")]
        IWebElement lost_passwordLink;

        [FindsBy(How = How.Id, Using = "email_create")]
        IWebElement emailForNewAccount;

        [FindsBy(How = How.Id, Using = "SubmitCreate")]
        IWebElement submitCreateAccountBtn;


        public LoginPage(IWebDriver driver) : base(driver)
        {
            action = new BasicAction(GetDriver());
            PageFactory.InitElements(GetDriver(),this);
        }

        public MyAccountPage Login(string usern, string passw)
        {
            action.TypeKeys(username, usern);
            action.TypeKeys(password, passw);
            signInBtn.Click();
            return new MyAccountPage(GetDriver());
        }

        public AddressPage Login_processToCheckOut(string usern, string passw)
        {
            action.TypeKeys(username, usern);
            action.TypeKeys(password, passw);
            signInBtn.Click();
            return new AddressPage(GetDriver());
        }
        public AccountCreationPage CreateAccount(string email)
        {
            action.TypeKeys(emailForNewAccount, email);
            submitCreateAccountBtn.Click();
            return new AccountCreationPage(GetDriver());
        }


    }
}

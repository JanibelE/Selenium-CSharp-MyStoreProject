using MyStoreProject.Com.ActionDriver;
using MyStoreProject.Com.Base;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Text.RegularExpressions;

namespace MyStoreProject.Com.PageObjects
{
    public class OrderPage:BaseClass
    {

        BasicAction action;

        [FindsBy(How = How.XPath, Using = "//td[@class='cart_unit']/span[@class='price']/span[1]")]
        IWebElement unitPrice;

        [FindsBy(How = How.XPath, Using = "//input[@class='cart_quantity_input form-control grey']")]
        IWebElement qty;

        [FindsBy(How = How.XPath, Using = "//a[@title='Proceed to checkout']/span[text()='Proceed to checkout']")]
        IWebElement proceedToCheckoutBtn;

        [FindsBy(How = How.Id, Using = "total_price")]
        IWebElement total_price;

        public OrderPage(IWebDriver driver) : base(driver)
        {
            action = new BasicAction(GetDriver());
            PageFactory.InitElements(GetDriver(), this);
        }


        public double GetUnitPrice()
        {
            action.WaitForElement(GetDriver(),By.XPath("//td[@class='cart_unit']/span[@class='price']/span[1]"));
            var unitPrice_text = unitPrice.Text;
            unitPrice_text = Regex.Replace(unitPrice_text, "[a-zA-Z,$]", "");
            var finalUnitPrice = double.Parse(unitPrice_text);
            return finalUnitPrice;
        }
        public double GetTotalPrice()
        {
            action.WaitForElement(GetDriver(), By.Id("total_price"));
            var totalPrice_text = total_price.Text;
            totalPrice_text = Regex.Replace(totalPrice_text, "[a-zA-Z,$]", "");
            var finalTotalPrice = double.Parse(totalPrice_text);
            return finalTotalPrice;
        }

        public LoginPage ClickOnCheckOut()
        {
            proceedToCheckoutBtn.Click();
            return new LoginPage(GetDriver());
        }
    }
}

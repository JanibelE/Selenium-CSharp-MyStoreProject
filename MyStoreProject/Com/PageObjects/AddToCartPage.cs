using MyStoreProject.Com.ActionDriver;
using MyStoreProject.Com.Base;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace MyStoreProject.Com.PageObjects
{
    public class AddToCartPage: BaseClass
    {
        BasicAction action;

        [FindsBy(How = How.XPath, Using = "//button[@name='Submit']/span[text()='Add to cart']")]
        IWebElement addToCartBtn;

        [FindsBy(How = How.Id, Using = "quantity_wanted")]
        IWebElement quantityTextBox;

        [FindsBy(How = How.Id, Using = "group_1")]
        IWebElement sizeDropDown;

        [FindsBy(How = How.XPath, Using = "//*[@id='layer_cart']/div[1]/div[1]/h2")]
        IWebElement addToCartMessage;

        [FindsBy(How = How.XPath, Using = "//a[@title='Proceed to checkout']")]
        IWebElement proceedToCheckoutBtn;




        public AddToCartPage(IWebDriver driver) : base(driver)
        {
            action = new BasicAction(GetDriver());
            PageFactory.InitElements(GetDriver(), this);
        }

        public void SelectQuantity(string amount)
        {
            action.TypeKeys(quantityTextBox, amount);
        }

        public void SelectSize(string size)
        {
            action.SelectElementByText(sizeDropDown, size);
        }

        public void ClickOnAddToCart()
        {
            addToCartBtn.Click();
        }

        public bool ValidateAddToCart()
        {
            action.WaitForElement(GetDriver(), By.XPath("//*[@id='layer_cart']/div[1]/div[1]/h2"));
            return action.IsDisplayed(GetDriver(), addToCartMessage);
        }

        public OrderPage ClickOnCheckout()
        {
            action.JSClick(GetDriver(),proceedToCheckoutBtn);
            return new OrderPage(GetDriver());
        }
    }
}

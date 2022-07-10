using MyStoreProject.Com.Base;
using MyStoreProject.Com.PageObjects;
using MyStoreProject.Com.Utility;
using MyStoreProject.Configuration;
using MyStoreProject.Configuration.Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCases_MyStoreProject
{
    public class EndToEnd_Test : BaseClass
    {
        [SetUp]
        public void Setup()
        {
            LaunchApp();
        }

        [TearDown]
        public void TearDown()
        {
            QuitDriver();
        }
        [Test]
        public void EndToEndTest()
        {
            Log.startTestCase("EndToEndTest");
            IndexPage indexPage = new IndexPage(GetDriver());
            SearchResultPage resultPage = new SearchResultPage(GetDriver());
            AddToCartPage addToCartPage;
            OrderPage orderPage;
            LoginPage loginPage;
            AddressPage addressPage;
            ShippingPage shippingPage;
            PaymentPage paymentPage;
            OrderSummaryPage orderSummaryPage;
            OrderConfirmationPage orderConfirmationPage;
            Settings settings = new Settings();
            ConfigurationModel userData = settings.getSettings();
            var quantity = 2;
            var Totalshipping = 2;

            indexPage.SearchProduct("shirt");
            var productAvailable = resultPage.IsProductAvailable();
            Assert.IsTrue(productAvailable, "Product not available.");

            addToCartPage = resultPage.ClickOnProduct();
            addToCartPage.SelectQuantity(quantity.ToString());
            addToCartPage.SelectSize("M");
            addToCartPage.ClickOnAddToCart();
            var validateSuccessMessage = addToCartPage.ValidateAddToCart();
            Assert.IsTrue(validateSuccessMessage, "Product successfully added.");

            orderPage = addToCartPage.ClickOnCheckout();
            var UnitPrice = orderPage.GetUnitPrice();
            var TotalPrice = orderPage.GetTotalPrice();
            var expectedValue = (UnitPrice * quantity) + Totalshipping;
            Assert.AreEqual(expectedValue, TotalPrice);

            loginPage = orderPage.ClickOnCheckOut();
            addressPage= loginPage.Login_processToCheckOut(userData.Username, userData.Password);

            shippingPage=addressPage.ClickOnCheckOut();
            shippingPage.ClickAgreeCheckBox();
            paymentPage=shippingPage.ClickOnProceedToCheckOut();
            orderSummaryPage=paymentPage.ClickOnBankWirePaymentMethod();
            orderConfirmationPage= orderSummaryPage.ClickOnConfirm();
            var ConfirmMessage = orderConfirmationPage.ValidateConfirmMessage();
            Assert.AreEqual("Your order on My Store is complete.", ConfirmMessage);
            Log.info("Test success");
            Log.endTestCase("EndToEndTest");
        }
    }
}

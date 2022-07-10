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
    public class OrderPage_Test : BaseClass
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
        public void VerifyTotalPrice()
        {
            Log.startTestCase("VerifyTotalPrice");
            IndexPage indexPage = new IndexPage(GetDriver());
            SearchResultPage resultPage = new SearchResultPage(GetDriver());
            LoginPage loginPage = new LoginPage(GetDriver());
            Settings settings = new Settings();
            ConfigurationModel userData = settings.getSettings();
            var quantity = 2;
            var Totalshipping = 2;
            indexPage.SearchProduct("shirt");
            var productAvailable = resultPage.IsProductAvailable();
            Assert.IsTrue(productAvailable, "Product not available.");

            AddToCartPage addToCartPage = resultPage.ClickOnProduct();
            addToCartPage.SelectQuantity(quantity.ToString());
            addToCartPage.SelectSize("M");
            addToCartPage.ClickOnAddToCart();
            var validateSuccessMessage = addToCartPage.ValidateAddToCart();
            Assert.IsTrue(validateSuccessMessage, "Product successfully added.");

            OrderPage orderPage = addToCartPage.ClickOnCheckout();

            var UnitPrice = orderPage.GetUnitPrice();
            var TotalPrice = orderPage.GetTotalPrice();

            var expectedValue = (UnitPrice * quantity)+Totalshipping;

            Assert.AreEqual(expectedValue, TotalPrice);
            Log.info("Test success");
            Log.endTestCase("VerifyTotalPrice");

        }
    }
}

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
    public class AddToCartPage_Test : BaseClass
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
        public void ValidateAddToCart()
        {
            Log.startTestCase("ValidateAddToCart");
            IndexPage indexPage = new IndexPage(GetDriver());
            SearchResultPage resultPage = new SearchResultPage(GetDriver());
            AddToCartPage addToCartPage = new AddToCartPage(GetDriver());

            indexPage.SearchProduct("shirt");
            var productAvailable = resultPage.IsProductAvailable();
            Assert.IsTrue(productAvailable,"Product not available.");

            resultPage.ClickOnProduct();
            addToCartPage.SelectQuantity("2");
            addToCartPage.SelectSize("M");
            addToCartPage.ClickOnAddToCart();
            var validateSuccessMessage = addToCartPage.ValidateAddToCart();
            Assert.IsTrue(validateSuccessMessage,"Product successfully added.");
            Log.info("Test success");
            Log.endTestCase("ValidateAddToCart");
        }

    }
}

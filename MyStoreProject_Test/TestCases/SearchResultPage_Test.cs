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
    public class SearchResultPage_Test: BaseClass
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
        public void IsProductAvailable()
        {
            Log.startTestCase("IsProductAvailable");
            IndexPage indexPage = new IndexPage(GetDriver());
            SearchResultPage resultPage = new SearchResultPage(GetDriver());

            indexPage.SearchProduct("shirt");
            var productAvailable = resultPage.IsProductAvailable();
            Assert.IsTrue(productAvailable);
            Log.info("Test success");
            Log.endTestCase("IsProductAvailable");
        }


    }
}

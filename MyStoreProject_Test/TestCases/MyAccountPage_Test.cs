using MyStoreProject.Com.Base;
using MyStoreProject.Com.PageObjects;
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
    public class MyAccountPage_Test : BaseClass
    {
        [SetUp]
        public void Setup()
        {
            LaunchApp();
        }

        [Test]
        public void ValidateMyWishList()
        {
            IndexPage indexPage = new IndexPage(GetDriver());
            LoginPage loginPage = new LoginPage(GetDriver());
            MyAccountPage homePage;
            Settings settings = new Settings();
            ConfigurationModel userData = settings.getSettings();

            indexPage.ClickOnSignIn();
            homePage = loginPage.Login(userData.Username, userData.Password);
            var validate = homePage.ValidateMyWishlist();

            Assert.IsTrue(validate);
        }

        [Test]
        public void ValidateOrderHistory()
        {
            IndexPage indexPage = new IndexPage(GetDriver());
            LoginPage loginPage = new LoginPage(GetDriver());
            MyAccountPage homePage;
            Settings settings = new Settings();
            ConfigurationModel userData = settings.getSettings();

            indexPage.ClickOnSignIn();
            homePage = loginPage.Login(userData.Username, userData.Password);
            var validate = homePage.ValidateOrderHistory();

            Assert.IsTrue(validate);
        }

        [TearDown]
        public void TearDown()
        {
            QuitDriver();
        }
    }
}

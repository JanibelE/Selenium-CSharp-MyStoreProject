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
    public class LoginPage_Test : BaseClass
    {
        [SetUp]
        public void Setup()
        {
            LaunchApp();
        }

        [Test]
        public void Login()
        {
            Log.startTestCase("Login");
            IndexPage indexPage = new IndexPage(GetDriver());
            indexPage.ClickOnSignIn();
            Settings settings = new Settings();
            ConfigurationModel userData = settings.getSettings();

            LoginPage loginPage = new LoginPage(GetDriver());
            MyAccountPage homePage=loginPage.Login(userData.Username, userData.Password);
            var currentUrl = GetCurentUrl();
            Assert.AreEqual(currentUrl, "http://automationpractice.com/index.php?controller=my-account");
            Log.info("Test success");
            Log.endTestCase("Login");
        }

        [TearDown]
        public void TearDown()
        {
            QuitDriver();
        }
    }
}

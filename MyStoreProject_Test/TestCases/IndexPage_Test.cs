using NUnit.Framework;
using MyStoreProject;
using MyStoreProject.Com.PageObjects;
using MyStoreProject.Com.Base;
using MyStoreProject.Com.Utility;
using log4net;
using log4net.Config;
using System.IO;
using System.Configuration;

namespace TestCases_MyStoreProject
{
    [TestFixture]
    [Category("IndexPage TestCases")]
    public class IndexPage_Test : BaseClass
    {
        [SetUp]
        public void Setup()
        {
            LaunchApp();
        }

        [Test]
        public void VerifyLogo()
        {
            Log.startTestCase("VerifyLogo");
            IndexPage indexPage = new IndexPage(GetDriver());
            Log.info("Validating logo.");
            var result = indexPage.ValidateLogo();
            Log.info("Logo validated.");
            Assert.IsTrue(result);
            Log.info("Test success");
            Log.endTestCase("VerifyLogo");
        }

        [Test]
        public void VerifyTitle()
        {
            Log.startTestCase("VerifyTitle");
            IndexPage indexPage = new IndexPage(GetDriver());
            var title = indexPage.GetMyStoreTitle(GetDriver());
            Assert.AreEqual(title, "My Store");
            Log.info("Test success");
            Log.endTestCase("VerifyTitle");
        }

        [TearDown]
        public void TearDown()
        {
            QuitDriver();
        }
    }
}
using MyStoreProject.Configuration;
using MyStoreProject.Configuration.Model;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Remote;
using log4net.Config;
using System.Configuration;
using MyStoreProject.Com.Utility;

namespace MyStoreProject.Com.Base
{
    public class BaseClass
    {
        public Settings settings;
        private IWebDriver _driver;

        ThreadLocal<IWebDriver> webDriver = new ThreadLocal<IWebDriver>();

        //public WebDriver GetDriver()
        //      {
        //	return webDriver.get
        //      }

        public BaseClass() { }

        public BaseClass(IWebDriver driver)
        {
            //_webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(_wait_ForElement_TimeOut));
            _driver = driver;
            settings = new Settings();
            PageFactory.InitElements(_driver, this);
        }

        public IWebDriver GetDriver()
        {
            return _driver;
        }

        public ConfigurationModel getConfigData()
        {
            settings= new Settings();
            return settings.getSettings();
        }
        public void LaunchApp()
        {
            Log.SetLogType(GetType());
            ConfigurationModel configData = getConfigData();
            if (configData.Browser.Equals("Chrome", StringComparison.OrdinalIgnoreCase))
            {
                _driver = new ChromeDriver();
                /*ChromeOptions chromeOptions = new ChromeOptions();
				_driver = new RemoteWebDriver(new Uri("http://192.168.31.163:4444/"),chromeOptions);
				*/
            }
            else if (configData.Browser.Equals("FireFox", StringComparison.OrdinalIgnoreCase))
            {
                _driver = new FirefoxDriver();
            }
            else if (configData.Browser.Equals("Edge", StringComparison.OrdinalIgnoreCase))
            {
                _driver = new EdgeDriver();
            }
            //Maximize the screen
            _driver.Manage().Window.Maximize();
            //Delete all the cookies
            _driver.Manage().Cookies.DeleteAllCookies();
            //Implicit TimeOuts
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(int.Parse(configData.implicitWait));
        
            //PageLoad TimeOuts
            _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(int.Parse(configData.pageLoadTimeOut));
            //Launching the URL
            _driver.Url = configData.Url;
        }

        public void QuitDriver()
        {
            _driver.Quit();
        }

        public string GetCurentUrl()
        {
            return _driver.Url;
        }
    }
}

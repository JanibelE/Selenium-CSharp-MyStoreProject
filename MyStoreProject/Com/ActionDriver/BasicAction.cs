using MyStoreProject.Com.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace MyStoreProject.Com.ActionDriver
{
    public class BasicAction : BaseClass,IAction
    {
        public BasicAction(IWebDriver driver) : base(driver)
        {
        }

        public void WaitForElement(IWebDriver webDriver, By locator)
        {
            var wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.FindElement(locator).Enabled && driver.FindElement(locator).Displayed);
           
           
            //WebDriverWait wait = new WebDriverWait(GetDriver(), TimeSpan.FromSeconds(30));
            //Func<IWebDriver, bool> waitForElement = new Func<IWebDriver, bool>((IWebDriver Web) =>
            //{
            //    var ele = Web.FindElement(locator);
            //    return ele.Displayed && ele.Enabled;
            //});
            //wait.Until(waitForElement);
        }
        
        public bool IsDisplayed(IWebDriver driver, IWebElement element)
        {
            var found = false;
            try
            {
                found = element.Displayed;
                System.Console.WriteLine("Element is displayed: " + element.Text);
            }
            catch (Exception)
            {
                System.Console.WriteLine("Element not found: " + element.Text);
            }
            return found;
        }

        public string GetPageTitle(IWebDriver driver)
        {
            var title = driver.Title;
            System.Console.WriteLine("The title of the page is: " + title);

            return title;
        }
        public void Perform()
        {
            throw new NotImplementedException();
        }

        public void TypeKeys(IWebElement element, string product)
        {
            var flag = false;
            try
            {
                if (element.Displayed)
                {
                    element.Clear();
                    element.SendKeys(product);
                } 
            }
            catch (Exception)
            {
                System.Console.WriteLine("Element not found.");
            }
            finally
            {
                if (flag)
                    System.Console.WriteLine("Successfully entered value.");
                else
                    System.Console.WriteLine("Unable to enter value.");
            }
        }
    
    
        public bool SelectElementByText(IWebElement element, string text)
        {
            var flag = false;
            try
            {
                if (element.Displayed)
                {
                    var select = new SelectElement(element);
                    select.SelectByText(text);
                    flag =true;
                }
            }
            catch (Exception)
            {
               System.Console.WriteLine("Error trying to select element by visibleText");
            }
            finally
            {
                if (flag)
                    System.Console.WriteLine("Element selected");
                else
                    System.Console.WriteLine("Element not selected by visibleText");

            }
                return flag;
        }
    
        public bool JSClick(IWebDriver driver, IWebElement element)
        {
            var flag = false;
            try
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor) GetDriver();
                js.ExecuteScript("arguments[0].click();", element);
                flag = true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error trying to click element. "+ e.Message);
            }
            finally
            {
                if (flag)
                {
                    Console.WriteLine("Click Action is performed");
                }
                else if (!flag)
                {
                    Console.WriteLine("Click Action is not performed");
                }
            }
            return flag;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using System.Threading;
namespace KTPMWEB
{
    public class BasePage
    {
        protected IWebDriver driver;        
        public BasePage(IWebDriver driver)
        {
            this.driver = driver;        
        }
        public static IWebElement WaitUntilElementIsVisible(IWebDriver driver, By locator, TimeSpan timeout)
        {
            IWebElement element = null;
            DateTime startTime = DateTime.Now;
            while (DateTime.Now - startTime < timeout)
            {
                try
                {
                    element = driver.FindElement(locator);
                    if (element.Displayed)
                    {
                        return element;
                    }
                }
                catch (NoSuchElementException) { } // Bỏ qua ngoại lệ nếu phần tử không được tìm thấy
            }
            throw new NoSuchElementException($"Element {locator} not found or not visible within specified timeout.");
        }
        public void CloseWeb()
        {
            driver.Close();
            driver.Quit();
        }
        public void OpenWeb()
        {
            string firefox_driver_path = "F:\\HKVIII\\geckodriver.exe";
            FirefoxDriverService firefox = FirefoxDriverService.CreateDefaultService(firefox_driver_path);
            firefox.HideCommandPromptWindow = true;
            driver = new FirefoxDriver(firefox);
        }

    }
    public class InstagramPage : BasePage
    {
        private string baseURL = "https://www.instagram.com/";
        public InstagramPage(IWebDriver driver) : base(driver) { }
        public void OpenInstagram()
        {   
            driver.Navigate().GoToUrl(baseURL);
        }
    }
    public class LoginInstagram : InstagramPage
    {
        private By username =  By.Name("username");
        private By pass = By.Name("password");
        private By login = By.XPath("/html/body/div[2]/div/div/div[2]/div/div/div[1]/section/main/article/div[2]/div[1]/div[2]/form/div/div[3]");
        public LoginInstagram(IWebDriver driver) : base(driver) { }
        public void User(string usernameDN)
        {
            WaitUntilElementIsVisible(driver, username, TimeSpan.FromSeconds(10));
            driver.FindElement(username).SendKeys(usernameDN);
            
        }
        public void Password(string PassDN)
        {
            WaitUntilElementIsVisible(driver, pass, TimeSpan.FromSeconds(10));
            driver.FindElement(pass).SendKeys(PassDN);
        }
        public void loginTk()
        {
            WaitUntilElementIsVisible(driver, login, TimeSpan.FromSeconds(10));
            driver.FindElement(login).Click();
        }

    }
    public class DashboardPage : LoginInstagram
    {
        private By href = By.XPath("/html/body/div[2]/div/div/div[2]/div/div/div[1]/div[1]/div[1]/div/div/div/div/div[2]/div[8]/div/span/div/a/div");
        public DashboardPage(IWebDriver driver) : base(driver) { }
        public void home()
        {
            
            WaitUntilElementIsVisible(driver, href, TimeSpan.FromSeconds(50));
            driver.FindElement(href).Click();
        }
        public string GetWelcomeMessage()
        {          
            IWebElement elementWithHref1 = WaitUntilElementIsVisible(driver, By.XPath("/html/body/div[2]/div/div/div[2]/div/div/div[1]/div[1]/div[1]/div/div/div/div/div[2]/div[8]/div/span/div/a"), TimeSpan.FromSeconds(10));
            return elementWithHref1.GetAttribute("href");
        }
    }
    public class UploadImage : DashboardPage
    {
        private By create = By.XPath("/html/body/div[2]/div/div/div[2]/div/div/div[1]/div[1]/div[2]/div[2]/section/main/div/div[4]/div[1]/div[2]/div/div/div/div/ul/li[3]/div/div/div/div/div[4]");
        public UploadImage(IWebDriver driver) : base(driver) { }
        public void Create()
        {
            WaitUntilElementIsVisible(driver, create, TimeSpan.FromSeconds(50));
            driver.FindElement(create).Click();
        }
        public void UploadFile(string NameFile)
        {
            try
            {
          
                IWebElement inputElement = driver.FindElement(By.XPath("/html/body/div[6]/div[1]/div/div[3]/div/div/div/div/div/div/div/div[2]/div[1]/form/input"));                       
                inputElement.SendKeys(NameFile);             
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void Next()
        {
            IWebElement elementWithHref2 = WaitUntilElementIsVisible(driver, By.XPath("/html/body/div[6]/div[1]/div/div[3]/div/div/div/div/div/div/div/div[1]/div/div/div/div[3]/div/div"), TimeSpan.FromSeconds(100));
            elementWithHref2.Click();
            
            IWebElement elementWithHref3 = WaitUntilElementIsVisible(driver, By.XPath("/html/body/div[6]/div[1]/div/div[3]/div/div/div/div/div/div/div/div[1]/div/div/div/div[3]/div/div"), TimeSpan.FromSeconds(100));
            elementWithHref3.Click();
            
            IWebElement elementWithHref4 = WaitUntilElementIsVisible(driver, By.XPath("/html/body/div[6]/div[1]/div/div[3]/div/div/div/div/div/div/div/div[1]/div/div/div/div[3]/div/div"), TimeSpan.FromSeconds(100));
            elementWithHref4.Click();
        }
        public string success()
        {
            IWebElement elementWithHref5 = WaitUntilElementIsVisible(driver, By.XPath("/html/body/div[6]/div[1]/div/div[3]/div/div/div/div/div/div/div/div[2]/div[1]/div/div[2]/div/span"), TimeSpan.FromSeconds(100));
            if (elementWithHref5.Text == "")
                return "false";
            else
                return "True";           
        }
    }
}

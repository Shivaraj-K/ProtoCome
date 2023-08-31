using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proto_Comerce.Pages
{
    public interface IDriver
    {
        public IWebDriver DriverInIt();
        public LoginPage loginPage { get; set; }
        public void Wait(By locator);
        public void ElementVisible(By locator);
    }
    public class Driver : IDriver
    {
        IWebDriver d;
        private readonly ScenarioContext _s;
        String browser;
        public Driver(ScenarioContext s)
        {
            _s = s;
        }

        public IWebDriver DriverInIt()
        {
            // browser=  _s.ScenarioInfo.Tags.FirstOrDefault(arg => arg.StartsWith("browser"));
             browser= TestContext.Parameters["browser"];

            
            //string browserName = ScenarioContext.Current.ScenarioInfo.Arguments.FirstOrDefault(arg => arg.StartsWith("--browser="));
            if (browser == null)
            {
                browser = ConfigurationManager.AppSettings["browser"];
            }
            Console.WriteLine(browser);
            if (d == null)
            {
                Console.WriteLine(browser);
                if (browser == "chrome")
                {
                    d = new ChromeDriver();
                }
                else if (browser == "firefox")
                {
                 
                    d = new FirefoxDriver();
                }

                else if (browser == "edge")
                {
                    d = new EdgeDriver();
                }

                d.Url = "https://rahulshettyacademy.com/loginpagePractise/";
                d.Manage().Window.Maximize();
                d.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                _s.Set(d, "d");
            }
            return d;
        }
        public LoginPage loginPage { get; set; }
        //public LoginPage log()
        //{
        //    return new LoginPage(d);
        //}

        public void Wait(By locator)
        {
            WebDriverWait w=new WebDriverWait(d,TimeSpan.FromSeconds(30));
            w.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(locator));
        }

        public void ElementVisible(By locator)
        {
            WebDriverWait w = new WebDriverWait(d, TimeSpan.FromSeconds(30));
            w.Until(ExpectedConditions.ElementIsVisible(locator));
        }
    }
}

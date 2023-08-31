using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proto_Comerce.Pages
{
    public class Location
    {
        //private readonly IDriver _d;
        private readonly ScenarioContext _s;
        public Location(ScenarioContext s)
        {
            _s = s;
            PageFactory.InitElements(s.Get<Driver>("driver").DriverInIt(), this);
        }
        //public Location(IDriver d) 
        //{
        //    _d = d;
        //    PageFactory.InitElements(d.DriverInIt(), this);
        //}

        [FindsBy(How = How.Id, Using = "country")]
        private IWebElement country;

        [FindsBy(How = How.XPath, Using = "//div[@Class='checkbox checkbox-primary']/label")]
        private IWebElement checkbox;

        [FindsBy(How=How.XPath,Using = "//div[@class='suggestions']//a")]
        private IList<IWebElement> li { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input[value = 'Purchase']")]
        private IWebElement button;

        public void Country(String Country)
        {
            country.SendKeys(Country);
            foreach (IWebElement w in li)
            {
                if(w.Text=="India")
                {
                    w.Click();
                    break;
                }
            }
            //_d.ElementVisible(By.Id("checkbox2"));
            Thread.Sleep(3000);
            checkbox.Click();
            _s.Get<IDriver>("driver").ElementVisible(By.CssSelector("input[value = 'Purchase']"));
            button.Click();
        }

    }
}

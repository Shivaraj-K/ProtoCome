using Dynamitey.DynamicObjects;
using OpenQA.Selenium;
//using PageFactoryCore;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proto_Comerce.Pages
{
    public class LoginPage
    {
       //private IDriver _d;
        private readonly ScenarioContext _s;
        public LoginPage(ScenarioContext s)
        {
            _s = s;
            PageFactory.InitElements(s.Get<IDriver>("driver").DriverInIt(), this);
        }
        //public LoginPage(IDriver d)
        //{
        //    _d = d;
        //    PageFactory.InitElements(d.DriverInIt(), this);
        //}

        [FindsBy(How = How.Id, Using = "username")]
        private IWebElement email { get; set; }

        [FindsBy(How=How.Id,Using = "password")]
        private IWebElement password { get; set; }

        [FindsBy(How = How.Id, Using = "signInBtn")]
        private IWebElement login { get; set; }

        [FindsBy(How = How.XPath, Using = "(//span[@class='checkmark'])[1]")]
        private IWebElement check { get; set; }

        public SelectProducts Login(String user,String pass)
        {
            email.SendKeys(user);
            password.SendKeys(pass);
            check.Click();
            login.Click();

            SelectProducts s = new SelectProducts(_s);
            return s;
        }
    }
}

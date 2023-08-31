using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow.Assist;

namespace Proto_Comerce.Pages
{
    public class CheckoutPage 
    {
        //private readonly IDriver _d;
        private readonly Table _t;
        private readonly ScenarioContext _s;

        public CheckoutPage(ScenarioContext s,Table t) 
        {
            _s = s;
            _t = t;
            PageFactory.InitElements(s.Get<IDriver>("driver").DriverInIt(), this);
        }

        [FindsBy(How=How.CssSelector,Using = ".col-md-6 h4")]
        private IList<IWebElement> l { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".btn-success")]
        private IWebElement check { get; set; }

        /*public void Products_verification()
        {
          ArrayList  a = new ArrayList();
           
            var dynamic = _t.CreateDynamicSet();

            foreach (var pro in dynamic)
            {
                foreach (IWebElement w in l)
                {
                    if (pro.products.Contains(w.Text))
                    {
                        a.Add(w.Text);
                    }
                }
                
               
            }
            foreach (IWebElement w in l)
            {
               
                Assert.True(a.Contains(w.Text));
            }
        }*/

        public Location Checkout()
        {
            check.Click();
            return new Location(_s);
        }


    }
}

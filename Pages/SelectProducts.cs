//using NUnit.Framework;
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
    public  class SelectProducts
    {
       // IDriver d;
        ArrayList a;
        private readonly ScenarioContext _s;

        public SelectProducts(ScenarioContext s)
        {
            _s = s;
            PageFactory.InitElements(s.Get<IDriver>("driver").DriverInIt(), this);
        }
        //public SelectProducts(IDriver dd)
        //{
        //    d = dd;
        //    PageFactory.InitElements(dd.DriverInIt(), this);
        //}

        [FindsBy(How = How.CssSelector, Using = ".mb-3")]
        private IList<IWebElement> l { get; set; }

        By locator = By.CssSelector(".mb-3");

        [FindsBy(How=How.PartialLinkText,Using = "Checkout")]
        private IWebElement check { get; set; }

        By loc = By.PartialLinkText("Checkout");
        public void SelectProduct(Table t)
        {
             a = new ArrayList();
            _s.Get<IDriver>("driver").Wait(locator);
          var dynamic=  t.CreateDynamicSet();
          
            foreach (var pro in dynamic)
            {
                a.Add(pro.products);
                foreach(IWebElement w in l)
                {
                   String Pro_Name=  w.FindElement(By.CssSelector(".card-body h4")).Text;
                    Console.WriteLine(Pro_Name + " ****************************  " + pro.products);
                    if (Pro_Name.Contains(pro.products))
                    {
                        
                        w.FindElement(By.CssSelector(".card-footer button")).Click();
                        break;
                    }
                
                }
            }

           

        }

        public CheckoutPage Checkout_Btn(Table t)
        {
            _s.Get<Driver>("driver").ElementVisible(loc);
            check.Click();

            //Console.WriteLine(a[0]+"=================");
            return new CheckoutPage(_s,t);

        }

        public ArrayList products()
        {
            ArrayList b=new ArrayList();
            Console.WriteLine(a[0] + "=================");
            for (int i=0;i<a.Count;i++)
            {
                b.Add(a[i]);    
            }

            return b;
        }

    }
}

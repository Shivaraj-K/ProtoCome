using Proto_Comerce.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proto_Comerce.StepDefinitions
{
    [Binding]
    public  class EcomSteps
    {
        private readonly ScenarioContext _s;
        //IDriver dd;
        SelectProducts s;
        CheckoutPage c;

        public EcomSteps(ScenarioContext s) 
        {
            _s = s;
        }

        [Given(@"The user on Ecom login page")]
        public void GivenTheUserOnEcomLoginPage()
        {
            
        }

        [When(@"The user login with valid Credential")]
        public void WhenTheUserLoginWithValidCredential()
        {
           s= _s.Get<IDriver>("driver").loginPage.Login("rahulshettyacademy", "learning");
        }

        [When(@"Select products and Add to cart")]
        public void WhenSelectProductsAndAddToCart(Table table)
        {
            s.SelectProduct(table);
           c= s.Checkout_Btn(table);

           Location l= c.Checkout() ;
            l.Country("ind");
            
        }


        [Then(@"Order successfully done")]
        public void ThenOrderSuccessfullyDone()
        {
            
        }

    }
}

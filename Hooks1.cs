using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using BoDi;
using OpenQA.Selenium;
using Proto_Comerce.Pages;
using Proto_Comerce.Utilities;
using TechTalk.SpecFlow;

namespace Proto_Comerce
{
    [Binding]
    public sealed class Hooks1 : ExtentRprt
    {
        private readonly IObjectContainer _c;
        private readonly ScenarioContext _s;
        IWebDriver d;

        //public Hooks1(IObjectContainer c) 
        //{
        //    _c = c;
        //}

        public Hooks1(ScenarioContext s)
        {
            _s = s;
        }

        [BeforeTestRun]
        public static void BeforeTest()
        {
            report();
        }
        [AfterTestRun]
        public static void TearDownMethod()
        {
            ExtentTearDown();
        }

        [BeforeFeature]
        public static  void  FeatureMethod(FeatureContext context)
        {
          f=  e.CreateTest<Feature>(context.FeatureInfo.Title);
        }

        [BeforeScenario]
        public void setUp(ScenarioContext ss)
        {
            // IDriver dd = new Driver();
            IDriver driver = new Driver(_s);
            _s.Set(driver, "driver");
          // IWebDriver d=dd.DriverInIt();
            //_c.RegisterInstanceAs<IWebDriver>(d);
            //_c.RegisterInstanceAs<IDriver>(dd);
           // dd.loginPage = new LoginPage(dd);
            _s.Get<Driver>("driver").loginPage = new LoginPage(_s);

            sc=f.CreateNode<Scenario>(ss.ScenarioInfo.Title);

        }

        [AfterStep]
        public void step(ScenarioContext ss)
        {
            String type=ss.StepContext.StepInfo.StepDefinitionType.ToString();
            String name = ss.StepContext.StepInfo.Text;
           /// IWebDriver dd = _c.Resolve<IWebDriver>();
            IWebDriver dd = _s.Get<IDriver>("driver").DriverInIt();
            if(ss.TestError==null)
            {
                if(type=="Given")
                {
                    sc.CreateNode<Given>(name);
                }
               else if (type == "When")
                {
                    sc.CreateNode<When>(name);
                }
                else if (type == "Then")
                {
                    sc.CreateNode<Then>(name);
                }
            }

            else if(ss.TestError!=null)
            {
                if (type == "Given")
                {
                    sc.CreateNode<Given>(name).Fail(ss.TestError.Message,MediaEntityBuilder.CreateScreenCaptureFromPath(screen( dd,  ss)).Build());
                }
                else if (type == "When")
                {
                    sc.CreateNode<When>(name).Fail(ss.TestError.Message, MediaEntityBuilder.CreateScreenCaptureFromPath(screen(dd, ss)).Build());
                }
                else if (type == "Then")
                {
                    sc.CreateNode<Then>(name).Fail(ss.TestError.Message, MediaEntityBuilder.CreateScreenCaptureFromPath(screen(dd, ss)).Build());
                }
            }
        }
    }
}

using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proto_Comerce.Utilities
{
    public  class ExtentRprt
    {
        public static ExtentHtmlReporter h;
        public static  ExtentReports e;
        public static ExtentTest f;
        public static ExtentTest sc;

        public static String dir = AppDomain.CurrentDomain.BaseDirectory;
        public static String path = dir.Replace("bin\\Debug\\net6.0\\", "TestResults\\");

        //public static  String CurrentDirectory = Environment.CurrentDirectory;
        //public  static String p = Directory.GetParent(CurrentDirectory).Parent.Parent.FullName;
        //public static String path = p + "\\index.html";
        public static void report()
        {
            
            h = new ExtentHtmlReporter(path);
            h.Config.DocumentTitle = "Ecom Report";
            h.Config.ReportName = "Ecom Reports";
            e = new ExtentReports();
            e.AttachReporter(h);
            e.AddSystemInfo("Tester", "Shivaraj");
        }
        

        public static void ExtentTearDown()
        {
            e.Flush();
        }

        public String screen(IWebDriver d,ScenarioContext s)
        {
            ITakesScreenshot it = (ITakesScreenshot)d;
            Screenshot ss=  it.GetScreenshot();
           Console.WriteLine(path.Remove(path.Length));
          String paths=  Path.Combine(path.Remove(path.Length-1), s.ScenarioInfo.Title+".png");
            ss.SaveAsFile(paths, ScreenshotImageFormat.Png);

            return paths;
        }
    }
}

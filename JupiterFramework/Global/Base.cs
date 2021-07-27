using JupiterFramework.Pages;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using RelevantCodes.ExtentReports;
using System;
using System.Threading;
using static JupiterFramework.Global.GlobalDefinitions;
using MarsFramework.Config;

namespace JupiterFramework.Global
{
    class Base
    {
        #region To access Path from resource file

        public static int Browser = Int32.Parse(JupiterResource.Browser);
        public static String ExcelPath = JupiterResource.ExcelPath;
        public static string ScreenshotPath = JupiterResource.ScreenShotPath;
        public static string ReportPath = JupiterResource.ReportPath;
        #endregion

        #region reports
        public static ExtentTest test;
        public static ExtentReports extent;
        #endregion

        #region setup and tear down
        [SetUp]
        public void Inititalize()
        {

            // advisasble to read this documentation before proceeding http://extentreports.relevantcodes.com/net/
            switch (Browser)
            {

                case 1:
                    GlobalDefinitions.driver = new FirefoxDriver();
                    break;
                case 2:
                    GlobalDefinitions.driver = new ChromeDriver();
                    GlobalDefinitions.driver.Manage().Window.Maximize();
                    break;

            }

            //Populate the excel data
            Thread.Sleep(3000);
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "HomePage");
            GlobalDefinitions.driver.Navigate().GoToUrl(GlobalDefinitions.ExcelLib.ReadData(2, "Url"));

            #region Initialise Reports

            extent = new ExtentReports(ReportPath, false, DisplayOrder.NewestFirst);
            extent.LoadConfig(JupiterResource.ReportXMLPath);
            test = extent.StartTest("My First Test", "Sample description");
            #endregion
            if (JupiterResource.IsLogin == "true")
            {
                HomePage obj = new HomePage();
                obj.HomeStep();
            }
            
            

        }


        [TearDown]
        public void TearDown()
        {
            // Screenshot
            String img = SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "Report");
            test.Log(LogStatus.Info, "Image example: " + img);
             //end test. (Reports)
           
            extent.EndTest(test);
            // calling Flush writes everything to the log file (Reports)
           
            
            extent.Flush();
            // Close the driver :)            
            GlobalDefinitions.driver.Close();
            GlobalDefinitions.driver.Quit();
        }
        #endregion

    }
}
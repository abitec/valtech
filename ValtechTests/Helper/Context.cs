using System;
using System.Configuration;
using System.Diagnostics;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ValtechTests.Helper
{
    public class Context
    {
        public IWebDriver Driver;

        public void BrowserSetup()
        {
            var chromeDriverProcesses = Process.GetProcessesByName("ChromeDriver");

            foreach (var chromeDriverProcess in chromeDriverProcesses)
            {
                try
                {
                    chromeDriverProcess.Kill();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            Driver = new ChromeDriver();
            Driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["BaseUrl"]);
            Driver.Manage().Window.Maximize();
        }

        public void CloseBrowser()
        {
            Driver.Quit();
            Driver.Dispose();
        }

    }
    
}

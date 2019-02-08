using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace UiTests
{
    [TestClass]
    public class Tests
    {
        public static WindowsDriver<WindowsElement> session;

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            var appId = System.IO.Path.GetFullPath(@"..\..\..\WpfAutomationTesting\bin\Debug\WpfAutomationTesting.exe");

            DesiredCapabilities appCapabilities = new DesiredCapabilities();
            appCapabilities.SetCapability("app", appId);
            session = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723/"), appCapabilities);
        }

        [TestMethod]
        public void TestTest()
        {
            var page = session.PageSource;

            var xPathQuery = "//Button[@Name=\"Add\"]";

            WebDriverWait wait = new WebDriverWait(session, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementExists(By.XPath(xPathQuery)));

            var btn = session.FindElementByXPath(xPathQuery);

            var records1 = session.FindElementsByXPath("//ListItem/Text");

            btn.Click();

            page = session.PageSource;

            var records2 = session.FindElementsByXPath("//ListItem/Text");
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            session.Close();
            session.Quit();
            session = null;
        }
    }
}

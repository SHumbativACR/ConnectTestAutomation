using BoDi;
using Enterprise.Framework.GenericLib;
using AutomationFramework.Constants;
using AutomationFramework.Pages;
using AutomationFramework.ProjectLib;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium.Appium.iOS;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using static Enterprise.Framework.Actions.BaseActions;

namespace AutomationFramework.Steps
{
    class LogoutSteps : BaseSteps
    {
        readonly string url = "https://connect-test.acr.org/";
        readonly string username = "acrconnect.testuser1@yahoo.com";
        readonly string password = "TEstaccount1";
        readonly string expectedPageTitle = "ACR Connect";


        public LogoutSteps(IWebDriver webDriver, ScenarioContext scenarioContext, IRunData runData, PageObjectManager pageObjectManager) : base(webDriver, scenarioContext, runData, pageObjectManager)
        {
            loginPage = pageObjectManager.GetLoginPage();
        }

        [Given(@"User is on Connect homepage")]

        public void UserIsOnConnectHomepage()
        {
         //   Driver.Navigate().GoToUrl(url);
            loginPage.SignIn(username,password);
        }

        [When(@"User clicks on sign out button and confirms signing out")]
        public void UserSignOut()
        {
            loginPage.SignOut();
        }

        [Then(@"User lands on Connect Splash page and page title is ACR Connect")]
        public void UserLandsOnConnectSplashPage()
        {
            Assert.AreEqual(expectedPageTitle, loginPage.GetSplashPageTitle());
        }
    }
}

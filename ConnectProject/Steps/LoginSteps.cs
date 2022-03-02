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
    public class LoginSteps : BaseSteps
    { 
       // readonly string url = "https://connect-test.acr.org/";
        readonly string username = "acrconnect.testuser1@yahoo.com";
        readonly string password = "TEstaccount1";
        readonly string expectedPageTitle = "Home Page";

        public LoginSteps(IWebDriver webDriver, ScenarioContext scenarioContext, IRunData runData, PageObjectManager pageObjectManager) : base(webDriver, scenarioContext, runData, pageObjectManager)
        {
            loginPage = pageObjectManager.GetLoginPage();
        }


        [Given(@"User navigates to Connect test environment Login Page")]
        public void UserNavigatesConnectTestEnvironmentLoginPage()
        {
           // Driver.Navigate().GoToUrl(url);
        }


        [When(@"User clicks on Sign in button and enters a valid username and password")]
        public void WhenUserClicksOnSignInButtonAndEntersAValidUsernameAndPassword()
        {
            loginPage.SignIn(username, password);
        }

        [Then(@"User lands on Connect homepage and Page Title is Home Page")]
        public void ThenUserLandsOnConnectHomepageAndPageTitleIsHomePage()
        {
            Assert.AreEqual(expectedPageTitle, loginPage.GetHomepageTitle());
        }


        
    }
    
}

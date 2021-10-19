using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using NUnit.Framework;
using AutomationFramework.ProjectLib;
using AutomationFramework.Pages;
using Bogus;

namespace AutomationFramework.Steps
{
    [Binding]
    public class RequestAccessSteps : BaseSteps
    {
        private HomePage homePage;
        readonly string username = "acrconnect.testuser43@gmail.com";
        readonly string password = "TestAccount43";
        String expectedMessage = "Your request has been submitted. You will receive a notification after the administrator has approved your request.";

        public RequestAccessSteps(IWebDriver webDriver, ScenarioContext scenarioContext, IRunData runData, PageObjectManager pageObjectManager) : base(webDriver, scenarioContext, runData, pageObjectManager)
        {
            homePage = pageObjectManager.GetHomePage();
        }

        [Given(@"User requests access to Connect")]
        public void UserRequestsAccessToConnect()
        {
            homePage.RequestAccess(username,password);
        }

        [Then(@"Confirmation message is displayed successfully")]
        public void ConfirmationMessageDisplayedSuccessfully()
        {
            String actualMessage = homePage.GetRequestConfirmation();
            Assert.AreEqual(expectedMessage, actualMessage);
        }


    }
}

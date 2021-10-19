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
    public class DenyAccessRequestSteps : BaseSteps
    {
        private HomePage homePage;
        private UserManagementPage userManagementPage;
        private LoginPage loginPage;
        readonly string username1 = "acrconnect.testuser43@gmail.com";
        readonly string password1 = "TestAccount43";
        readonly string username = "acrconnect.testuser1@yahoo.com";
        readonly string password = "TEstaccount1";
        string expectedNotification = "Your request was previously rejected by administrator. Please contact your administrator to reinstate your request.";

        public DenyAccessRequestSteps(IWebDriver webDriver, ScenarioContext scenarioContext, IRunData runData, PageObjectManager pageObjectManager) : base(webDriver, scenarioContext, runData, pageObjectManager)
        {
            homePage = pageObjectManager.GetHomePage();
            userManagementPage = pageObjectManager.GetUserManagementPage();
            loginPage = pageObjectManager.GetLoginPage();
        }


        [Given(@"Administrator navigates to User Management service")]
        public void AdministratorNavigatesToUserManagementService()
        {
            loginPage.SignIn(username, password);
            homePage.NavigateToUserManagement();
        }

        [Given(@"Denies access request")]
        public void DeniesAccessRequest()
        {
            userManagementPage.DenyAccessRequest();
        }

        [When(@"Rejected user tries to sign in to Connect")]
        public void RejectedUserTriesToSignInToConnect()
        {
            homePage.SignIn(username1,password1);
        }

        [Then(@"User is notified that their request was denied")]
        public void UserIsNotifiedThatTheirRequestWasDenied()
        {
            string actualNotification = homePage.GetDenialNotification();
            Assert.AreEqual(expectedNotification, actualNotification);
        }



    }
}

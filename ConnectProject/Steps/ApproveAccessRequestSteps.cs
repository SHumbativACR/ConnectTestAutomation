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
    public class ApproveAccessRequestSteps : BaseSteps
    {
        private HomePage homePage;
        private UserManagementPage userManagementPage;
        private LoginPage loginPage;
        readonly string username1 = "acrconnect.testuser43@gmail.com";
        readonly string password1 = "TestAccount43";
        readonly string username = "acrconnect.testuser1@yahoo.com";
        readonly string password = "TEstaccount1";
        string expectedPageTitle = "Home Page";

        public ApproveAccessRequestSteps(IWebDriver webDriver, ScenarioContext scenarioContext, IRunData runData, PageObjectManager pageObjectManager) : base(webDriver, scenarioContext, runData, pageObjectManager)
        {
            homePage = pageObjectManager.GetHomePage();
            userManagementPage = pageObjectManager.GetUserManagementPage();
            loginPage = pageObjectManager.GetLoginPage();
        }


        [Given(@"Administrator navigates to User Management service2")]
        public void AdministratorNavigatesToUserManagementService2()
        {
            loginPage.SignIn(username, password);
            homePage.NavigateToUserManagement();
        }

        [Given(@"Approves access request")]
        public void ApproveAccessRequest()
        {
            userManagementPage.ApproveAccessRequest();
        }

        [When(@"Approved user tries to sign in to Connect")]
        public void ApprovedUserTriesToSignInToConnect()
        {
            homePage.SignIn(username1, password1);
        }

        [Then(@"User lands on Connect homepage and Page Title is Home Page2")]
        public void ThenUserLandsOnConnectHomepageAndPageTitleIsHomePage2()
        {
            Assert.AreEqual(expectedPageTitle, loginPage.GetHomepageTitle());
        }




    }
}

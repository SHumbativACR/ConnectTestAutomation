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
    public class DisableUserSteps : BaseSteps
    {
        private UserManagementPage userManagementPage;
        private HomePage homePage;
        private LoginPage loginPage;
        readonly string username = "acrconnect.testuser1@yahoo.com";
        readonly string password = "TEstaccount1";
        readonly string username1 = "acrconnect.testuser12@gmail.com";
        readonly string password1 = "TEstaccount12";
        string expectedNotification = "Your account has been disabled by the Administrator.";

        public DisableUserSteps(IWebDriver webDriver, ScenarioContext scenarioContext, IRunData runData, PageObjectManager pageObjectManager) : base(webDriver, scenarioContext, runData, pageObjectManager)
        {
            loginPage = pageObjectManager.GetLoginPage();
            homePage = pageObjectManager.GetHomePage();
            userManagementPage = pageObjectManager.GetUserManagementPage();
        }


        [Given(@"Administrator navigates to User Management service3")]
        public void AdministratorNavigatesToUserManagementService3()
        {
            loginPage.SignIn(username, password);
            homePage.NavigateToUserManagement();
        }

        [Given(@"Disables platform user's role")]
        public void DisablesPlatformUsersRole()
        {
            userManagementPage.EnableDisableUser();
        }

        [When(@"Disabled user tries to sign in to Connect")]
        public void DisabledUserTriesToSignInToConnect()
        {
            homePage.SignIn(username1, password1);
        }

        [Then(@"User is notified that their account has been disabled")]
        public void UserIsNotifiedThatTheirAccountHasBeenDisabled()
        {
            string actualNotification = homePage.GetDisabledNotification();
            Assert.AreEqual(expectedNotification, actualNotification);
        }


    }
}

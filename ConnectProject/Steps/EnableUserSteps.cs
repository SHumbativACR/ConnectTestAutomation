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
    public class EnableUserSteps : BaseSteps
    {
        private UserManagementPage userManagementPage;
        private HomePage homePage;
        private LoginPage loginPage;
        readonly string username = "acrconnect.testuser1@yahoo.com";
        readonly string password = "TEstaccount1";
        readonly string username1 = "acrconnect.testuser12@gmail.com";
        readonly string password1 = "TEstaccount12";
        string expectedPageTitle = "Your account has been disabled by the Administrator.";

        public EnableUserSteps(IWebDriver webDriver, ScenarioContext scenarioContext, IRunData runData, PageObjectManager pageObjectManager) : base(webDriver, scenarioContext, runData, pageObjectManager)
        {
            loginPage = pageObjectManager.GetLoginPage();
            homePage = pageObjectManager.GetHomePage();
            userManagementPage = pageObjectManager.GetUserManagementPage();
        }


        [Given(@"Administrator navigates to User Management service4")]
        public void AdministratorNavigatesToUserManagementService4()
        {
            loginPage.SignIn(username, password);
            homePage.NavigateToUserManagement();
        }

        [Given(@"Enables platform user's role")]
        public void EnablesPlatformUsersRole()
        {
            userManagementPage.EnableDisableUser();
        }

        [When(@"Enabled user tries to sign in to Connect")]
        public void EnabledUserTriesToSignInToConnect()
        {
            homePage.SignIn(username1, password1);
        }

        [Then(@"User lands on Connect homepage and Page Title is Home Page3")]
        public void ThenUserLandsOnConnectHomepageAndPageTitleIsHomePage3()
        {
            Assert.AreEqual(expectedPageTitle, loginPage.GetHomepageTitle());
        }


    }
}

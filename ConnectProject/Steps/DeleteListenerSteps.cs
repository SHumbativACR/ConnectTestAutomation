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
    public class DeleteListenerSteps : BaseSteps
    {
        private DicomPage dicomPage;
        private HomePage homePage;
        private LoginPage loginPage;
        readonly string username = "acrconnect.testuser1@yahoo.com";
        readonly string password = "TEstaccount1";
        string expectedMessage = "Listener deleted successfully";

        public DeleteListenerSteps(IWebDriver webDriver, ScenarioContext scenarioContext, IRunData runData, PageObjectManager pageObjectManager) : base(webDriver, scenarioContext, runData, pageObjectManager)
        {
            loginPage = pageObjectManager.GetLoginPage();
            dicomPage = pageObjectManager.GetDicomPage();
            homePage = pageObjectManager.GetHomePage();
        }


        [Given(@"User navigates to Connect DICOM Listeners sub-tab3")]
        public void UserNavigatesToConnectDICOMListenersSubtab3()
        {
            loginPage.SignIn(username, password);
            homePage.NavigateToDICOMService();
        }

        [When(@"User deletes exisiting DICOM listener")]
        public void UserDeletesExistingDicomListener()
        {
            dicomPage.DeleteListener();
        }

        [Then(@"Notification is displayed successfully")]
        public void NotificationIsDisplayedSuccessfully()
        {
            Assert.AreEqual(expectedMessage, dicomPage.GetRemovalNotification());
        }


    }
}

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
    public class AssignEmptyDsToListenerSteps : BaseSteps
    {
        private DicomPage dicomPage;
        private HomePage homePage;
        private LoginPage loginPage;
        private DataManagerPage dataManagerPage;
        readonly string username = "acrconnect.testuser1@yahoo.com";
        readonly string password = "TEstaccount1";
        string emptyDatasetName = "EmptyDS_Automated";
        string listenerName = "ListenerDS_" + new Faker().Name.FirstName();
        string aet = new Faker().Name.LastName();
        string port = "9098";
        string expectedMessage = "Dataset Association saved successfully";
        
        public AssignEmptyDsToListenerSteps(IWebDriver webDriver, ScenarioContext scenarioContext, IRunData runData, PageObjectManager pageObjectManager) : base(webDriver, scenarioContext, runData, pageObjectManager)
        {
            loginPage = pageObjectManager.GetLoginPage();
            dicomPage = pageObjectManager.GetDicomPage();
            homePage = pageObjectManager.GetHomePage();
            dataManagerPage = pageObjectManager.GetDataManagerPage();
        }


        [Given(@"User navigates to Data section in Data Manager service")]
        public void UserNavigatesToDataSectionInDataManagerService()
        {
            loginPage.SignIn(username, password);
            homePage.NavigateToDataManagerService();
            dataManagerPage.NavigateToDataManagerServiceDataSection();
        }

        [Given(@"Creates empty dataset")]
        public void CreatesEmptyDataset()
        {
            dataManagerPage.CreateEmptyDataset(emptyDatasetName);
        }

        [Given(@"User navigates to DICOM Listeners page")]
        public void UserNavigatesToDICOMListenersPage()
        {
            homePage.NavigateToDICOMService();
        }

        [When(@"User creates a listener and assings empty dataset to the listener")]
        public void UserCreatesListenerAndAssignsEmptyDatasetToListener()
        {
            dicomPage.CreateListener(listenerName,aet,port);
            dicomPage.AssignDatasetToListener();
        }

        [Then(@"Confirmation message will be displayed successfully2")]
        public void ConfirmationMessageWillBeDisplayedSuccessfully2()
        {
            Assert.AreEqual(expectedMessage, dicomPage.GetDSAssignNotification());
        }

    }
}

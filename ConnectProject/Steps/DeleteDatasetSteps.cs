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
    public class DeleteDatasetSteps : BaseSteps
    {
        private DicomPage dicomPage;
        private HomePage homePage;
        private LoginPage loginPage;
        private DataManagerPage dataManagerPage;
        readonly string username = "acrconnect.testuser1@yahoo.com";
        readonly string password = "TEstaccount1";
        string testDatasetName = "DatasetForDeletion";
        string expectedMessage = "No Records Found";

        public DeleteDatasetSteps(IWebDriver webDriver, ScenarioContext scenarioContext, IRunData runData, PageObjectManager pageObjectManager) : base(webDriver, scenarioContext, runData, pageObjectManager)
        {
            loginPage = pageObjectManager.GetLoginPage();
            dicomPage = pageObjectManager.GetDicomPage();
            homePage = pageObjectManager.GetHomePage();
            dataManagerPage = pageObjectManager.GetDataManagerPage();
        }


        [Given(@"User imports a dataset to Data Manager service")]
        public void UserImportsDatasetToDataManagerService()
        {
            loginPage.SignIn(username, password);
            homePage.NavigateToDICOMService();
            dicomPage.NavigateToDICOMImportSubTab();
            dicomPage.UploadPXSFile(testDatasetName);
        }


        [Given(@"Navigates to Data Manager and selects the imported dataset")]
        public void NavigatesToDataManagerServiceAndSelectsImportedDataset()
        {
            dicomPage.SwitchToHomePage();
            homePage.NavigateToDataManagerService();
            dataManagerPage.SearchAndSelectDataset(testDatasetName);
        }

        [When(@"User deletes selected dataset")]
        public void UserDeletesSelectedDataset()
        {
            dataManagerPage.DeleteDataset(testDatasetName);
        }

        [Then(@"No records found message is displayed when user searches that dataset")]
        public void NoRecordsFoundMessageDisplayedWhenUserSearchesThatDataset()
        {
           // dataManagerPage.SearchAndSelectDataset(testDatasetName);
            string actualMessage = dataManagerPage.GetNoRecordsFoundMessage();
            Assert.AreEqual(expectedMessage, actualMessage);
        }

    }
}

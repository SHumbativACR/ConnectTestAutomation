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
    public class SelectAllSteps : BaseSteps
    {
        private DicomPage dicomPage;
        private HomePage homePage;
        private LoginPage loginPage;
        private DataManagerPage dataManagerPage;
        readonly string username = "acrconnect.testuser1@yahoo.com";
        readonly string password = "TEstaccount1";
        string testDatasetName = "SelectAllTest";
        string expectedCount = "5";

        public SelectAllSteps(IWebDriver webDriver, ScenarioContext scenarioContext, IRunData runData, PageObjectManager pageObjectManager) : base(webDriver, scenarioContext, runData, pageObjectManager)
        {
            loginPage = pageObjectManager.GetLoginPage();
            dicomPage = pageObjectManager.GetDicomPage();
            homePage = pageObjectManager.GetHomePage();
            dataManagerPage = pageObjectManager.GetDataManagerPage();
        }


        [Given(@"User navigates to DICOM service Import data and annotations sub-tab")]
        public void UserNavigatesToDICOMServiceImportDataAndAnnotationsSubTab()
        {
            loginPage.SignIn(username, password);
            homePage.NavigateToDICOMService();
            dicomPage.NavigateToDICOMImportSubTab();
        }


        [Given(@"Imports dataset and navigates to Data Manager service")]
        public void ImportsDatasetAndNavigatesToDataManagerService()
        {
            dicomPage.UploadPXSFile(testDatasetName);
            dicomPage.SwitchToHomePage();
            homePage.NavigateToDataManagerService();
        }

        [When(@"User selects that dataset and clicks on select all button")]
        public void UserSelectsThatDatasetAndClicksOnSelectAllButton()
        {
            dataManagerPage.SearchAndSelectDataset(testDatasetName);
        }

        [Then(@"The result should match the expected study count")]
        public void TheResultShouldMatchExpectedStudyCount()
        {
            string actualCount = dataManagerPage.clickOnSelectAllDatasets();
            Assert.AreEqual(expectedCount, actualCount);
        }

    }
}

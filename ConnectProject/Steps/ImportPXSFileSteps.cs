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
    public class ImportPXSFileSteps : BaseSteps
    {
        private DicomPage dicomPage;
        private HomePage homePage;
        private LoginPage loginPage;
        private DataManagerPage dataManagerPage;
        readonly string username = "acrconnect.testuser1@yahoo.com";
        readonly string password = "TEstaccount1";
        string testDatasetName = "PXS5";
        string expectedDataCount = "5";

        public ImportPXSFileSteps(IWebDriver webDriver, ScenarioContext scenarioContext, IRunData runData, PageObjectManager pageObjectManager) : base(webDriver, scenarioContext, runData, pageObjectManager)
        {
            loginPage = pageObjectManager.GetLoginPage();
            dicomPage = pageObjectManager.GetDicomPage();
            homePage = pageObjectManager.GetHomePage();
            dataManagerPage = pageObjectManager.GetDataManagerPage();
        }


        [Given(@"User navigates to DICOM Import data & annotations page and imports PXS studies")]
        public void UserNavigatesToDICOMImportDataAnnotationsPageAndImportsPXSStudies()
        {
            loginPage.SignIn(username, password);
            homePage.NavigateToDICOMService();
            dicomPage.NavigateToDICOMImportSubTab();
            dicomPage.UploadPXSFile(testDatasetName);
        }


        [When(@"User navigates to Data Manager service and searches for the imported dataset")]
        public void UserNavigatesToDataManagerServiceAndSearchesForImportedDataset()
        {
            dicomPage.SwitchToHomePage();
            homePage.NavigateToDataManagerService();
            dataManagerPage.SearchAndSelectDataset(testDatasetName);
        }

        [Then(@"Newly imported dataset is displayed successfully and study count is as expected")]
        public void NewlyImportedDatasetIsDisplayedSuccessfullyAndStudyCountIsAsExpected()
        {
            string actualDataCount = dataManagerPage.clickOnSelectAllDatasets();
            Assert.AreEqual(expectedDataCount, actualDataCount);
        }


    }
}

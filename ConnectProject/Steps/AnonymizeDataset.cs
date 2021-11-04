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
    public class AnonymizeDatasetSteps : BaseSteps
    {
        private DicomPage dicomPage;
        private HomePage homePage;
        private LoginPage loginPage;
        private DataManagerPage dataManagerPage;
        readonly string username = "acrconnect.testuser1@yahoo.com";
        readonly string password = "TEstaccount1";
        string testDatasetName = "DSForAnonymization";
        string datasetName = "AnonymizedDS";
        string expectedDataCount = "12";

        public AnonymizeDatasetSteps(IWebDriver webDriver, ScenarioContext scenarioContext, IRunData runData, PageObjectManager pageObjectManager) : base(webDriver, scenarioContext, runData, pageObjectManager)
        {
            loginPage = pageObjectManager.GetLoginPage();
            dicomPage = pageObjectManager.GetDicomPage();
            homePage = pageObjectManager.GetHomePage();
            dataManagerPage = pageObjectManager.GetDataManagerPage();
        }


        [Given(@"User navigates to DICOM service and imports a breast density dataset")]
        public void UserNavigatesToDICOMServiceAndImportsBreastDensityDataset()
        {
            loginPage.SignIn(username, password);
            homePage.NavigateToDICOMService();
            dicomPage.NavigateToDICOMImportSubTab();
            dicomPage.UploadBDFile2(testDatasetName);
        }

        [Given(@"Navigates to Data Manager service and selects the imported dataset")]
        public void NavigatesToDataManagerServiceAndSelectsTheImportedDataset()
        {
            dicomPage.SwitchToHomePage();
            homePage.NavigateToDataManagerService();
            dataManagerPage.SearchAndSelectDataset(testDatasetName);
        }

        [When(@"User anonymizes the dataset to a new dataset")]
        public void UserAnonymizesTheDatasetToNewDataset()
        {
            dataManagerPage.clickOnSelectAllDatasets();
            dataManagerPage.AnonymizationWithDefaultProfile(datasetName);
        }

        [Then(@"Anonymized dataset is created and all the studies are displayed correctly")]
        public void AnonymizedDatasetIsCreatedAndAllStudiesDisplayedCorrectly()
        {
            dataManagerPage.SearchAndSelectDataset(datasetName);
            string actualDataCount = dataManagerPage.clickOnSelectAllDatasets();
            Assert.AreEqual(expectedDataCount, actualDataCount);
        }


    }
}

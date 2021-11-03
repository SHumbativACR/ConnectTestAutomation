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
    public class ImportBDFileSteps : BaseSteps
    {
        private DicomPage dicomPage;
        private HomePage homePage;
        private LoginPage loginPage;
        private DataManagerPage dataManagerPage;
        readonly string username = "acrconnect.testuser1@yahoo.com";
        readonly string password = "TEstaccount1";
        string testDatasetName = "BD18";
        string expectedDataCount = "18";

        public ImportBDFileSteps(IWebDriver webDriver, ScenarioContext scenarioContext, IRunData runData, PageObjectManager pageObjectManager) : base(webDriver, scenarioContext, runData, pageObjectManager)
        {
            loginPage = pageObjectManager.GetLoginPage();
            dicomPage = pageObjectManager.GetDicomPage();
            homePage = pageObjectManager.GetHomePage();
            dataManagerPage = pageObjectManager.GetDataManagerPage();
        }

        
        [Given(@"User navigates to DICOM Import data & annotations page")]
        public void UserNavigatesToDICOMImportDataAnnotationsPage()
        {
            loginPage.SignIn(username, password);
            homePage.NavigateToDICOMService();
            dicomPage.NavigateToDICOMImportSubTab();
        }

        [Given(@"User imports excel file that contains Breast Density studies")]
        public void UserImportsExcelFileThatContainsBreastDensityStudies()
        {
            dicomPage.UploadBDFile(testDatasetName);
        }

        [When(@"User navigates to Data Manager service and searches for the dataset")]
        public void UserNavigatesToDataManagerServiceAndSearchesForTheDataset()
        {
            dicomPage.SwitchToHomePage();
            homePage.NavigateToDataManagerService();
            dataManagerPage.SearchAndSelectDataset(testDatasetName);
        }

        [Then(@"Newly imported dataset is displayed successfully")]
        public void NewlyImportedDatasetIsDisplayedSuccessfully()
        {
            string actualDataCount = dataManagerPage.clickOnSelectAllDatasets();
            Assert.AreEqual(expectedDataCount,actualDataCount);
        }


    }
}

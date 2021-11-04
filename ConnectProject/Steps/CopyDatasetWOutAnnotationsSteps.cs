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
    public class CopyDatasetWOutAnnotationsSteps : BaseSteps
    {
        private DicomPage dicomPage;
        private HomePage homePage;
        private LoginPage loginPage;
        private DataManagerPage dataManagerPage;
        readonly string username = "acrconnect.testuser1@yahoo.com";
        readonly string password = "TEstaccount1";
        string testDatasetName = "DS000999";
        string datasetName = "CopyTestNoAnnotations000999";
        string expectedDataCount = "18";

        public CopyDatasetWOutAnnotationsSteps(IWebDriver webDriver, ScenarioContext scenarioContext, IRunData runData, PageObjectManager pageObjectManager) : base(webDriver, scenarioContext, runData, pageObjectManager)
        {
            loginPage = pageObjectManager.GetLoginPage();
            dicomPage = pageObjectManager.GetDicomPage();
            homePage = pageObjectManager.GetHomePage();
            dataManagerPage = pageObjectManager.GetDataManagerPage();
        }


        [Given(@"User navigates to DICOM service and imports a dataset")]
        public void UserNavigatesToDICOMServiceAndImportsDataset()
        {
            loginPage.SignIn(username, password);
            homePage.NavigateToDICOMService();
            dicomPage.NavigateToDICOMImportSubTab();
            dicomPage.UploadBDFile(testDatasetName);
        }

        [Given(@"User navigates to Data Manager service and selects a newly created dataset from the list")]
        public void UserNavigatesToDataManagerServiceAndSelectsNewlyCreatedDatasetFromList()
        {
            dicomPage.SwitchToHomePage();
            homePage.NavigateToDataManagerService();
            dataManagerPage.SearchAndSelectDataset(testDatasetName);
        }

        [Given(@"User copy dataset to a new dataset without annotations")]
        public void UserCopyDatasetToNewDatasetWithoutAnnotations()
        {
            dataManagerPage.CopyDatasetWithoutAnnotations(datasetName);
        }

        [When(@"User searches and selects new created dataset")]
        public void UserSearchesAndSelectsNewCreatedDataset()
        {
            dataManagerPage.SearchAndSelectDataset(datasetName);
        }

        [Then(@"Newly created dataset is displayed and all the studies are present accurately")]
        public void NewlyCreatedDatasetIsDisplayedAndAllStudiesArePresentAccurately()
        {
            string actualDataCount = dataManagerPage.clickOnSelectAllDatasets();
            Assert.AreEqual(expectedDataCount, actualDataCount);
        }


    }
}

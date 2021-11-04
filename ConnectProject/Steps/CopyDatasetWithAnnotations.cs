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
    public class CopyDatasetWithAnnotationsSteps : BaseSteps
    {
        private DicomPage dicomPage;
        private HomePage homePage;
        private LoginPage loginPage;
        private DataManagerPage dataManagerPage;
        readonly string username = "acrconnect.testuser1@yahoo.com";
        readonly string password = "TEstaccount1";
        string testDatasetName = "DS1199";
        string datasetName = "CopyTestWithAnnotations1199";
        string expectedDataCount = "5";

        public CopyDatasetWithAnnotationsSteps(IWebDriver webDriver, ScenarioContext scenarioContext, IRunData runData, PageObjectManager pageObjectManager) : base(webDriver, scenarioContext, runData, pageObjectManager)
        {
            loginPage = pageObjectManager.GetLoginPage();
            dicomPage = pageObjectManager.GetDicomPage();
            homePage = pageObjectManager.GetHomePage();
            dataManagerPage = pageObjectManager.GetDataManagerPage();
        }


        [Given(@"User navigates to DICOM service and imports a dataset2")]
        public void UserNavigatesToDICOMServiceAndImportsDataset2()
        {
            loginPage.SignIn(username, password);
            homePage.NavigateToDICOMService();
            dicomPage.NavigateToDICOMImportSubTab();
            dicomPage.UploadPXSFile(testDatasetName);
        }

        [Given(@"User navigates to Data Manager service and selects a newly created dataset from the list2")]
        public void UserNavigatesToDataManagerServiceAndSelectsNewlyCreatedDatasetFromList2()
        {
            dicomPage.SwitchToHomePage();
            homePage.NavigateToDataManagerService();
            dataManagerPage.SearchAndSelectDataset(testDatasetName);
        }

        [Given(@"User copy dataset to a new dataset with annotations")]
        public void UserCopyDatasetToNewDatasetWithoutAnnotations()
        {
            dataManagerPage.CopyDatasetWithAnnotations(datasetName);
        }

        [When(@"User searches and selects new created dataset2")]
        public void UserSearchesAndSelectsNewCreatedDataset2()
        {
            dataManagerPage.SearchAndSelectDataset(datasetName);
        }

        [Then(@"Newly created dataset is displayed and all the studies are present accurately2")]
        public void NewlyCreatedDatasetIsDisplayedAndAllStudiesArePresentAccurately2()
        {
            string actualDataCount = dataManagerPage.clickOnSelectAllDatasets();
            Assert.AreEqual(expectedDataCount, actualDataCount);
        }


    }
}

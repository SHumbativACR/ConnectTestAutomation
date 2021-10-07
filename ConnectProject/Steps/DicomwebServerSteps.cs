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
    public class DicomwebServerSteps : BaseSteps
    {
        private DicomPage dicomPage;
        private HomePage homePage;
        private LoginPage loginPage;
        readonly string username = "acrconnect.testuser1@yahoo.com";
        readonly string password = "TEstaccount1";
        String serverName = "DICOMweb_" + new Faker().Name.FirstName();
        String expectedMessage = "DICOM/WebDICOM source server created successfully.";

        public DicomwebServerSteps(IWebDriver webDriver, ScenarioContext scenarioContext, IRunData runData, PageObjectManager pageObjectManager) : base(webDriver, scenarioContext, runData, pageObjectManager)
        {
            loginPage = pageObjectManager.GetLoginPage();
            dicomPage = pageObjectManager.GetDicomPage();
            homePage = pageObjectManager.GetHomePage();
        }


        [Given(@"User navigates to Connect DICOM service and clicks on Servers sub-tab")]
        public void UserNavigatesToConnectDICOMServiveAndClicksServersSubtab()
        {
            loginPage.SignIn(username, password);
            homePage.NavigateToDICOMService();
            dicomPage.NavigateToDICOMServersSubTab();
        }

        [When(@"User creates a new DICOMweb server and saves it")]
        public void UserCreatesNewDicomwebServerAndSavesIt()
        {
            dicomPage.CreateDicomwebServer(serverName);
        }

        [Then(@"Confirmation message is displayed successfully2")]
        public void ConfirmationMessageIsDisplayedSuccessfully2()
        {
            Assert.AreEqual(expectedMessage, dicomPage.GetCreationConfirmationMessage());
        }


    }
}

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
    [Binding]
    public class DeleteServerSteps : BaseSteps
    {
        private DicomPage dicomPage;
        private HomePage homePage;
        private LoginPage loginPage;
        readonly string username = "acrconnect.testuser1@yahoo.com";
        readonly string password = "TEstaccount1";
        String expectedMessage = "deleted successfully.";

        public DeleteServerSteps(IWebDriver webDriver, ScenarioContext scenarioContext, IRunData runData, PageObjectManager pageObjectManager) : base(webDriver, scenarioContext, runData, pageObjectManager)
        {
            loginPage = pageObjectManager.GetLoginPage();
            dicomPage = pageObjectManager.GetDicomPage();
            homePage = pageObjectManager.GetHomePage();
        }

        [Given(@"User navigates to Connect DICOM service and clicks on Servers sub-tab2")]
        public void UserNavigatesToConnectDICOMServiveAndClicksServersSubtab2()
        {
            loginPage.SignIn(username, password);
            homePage.NavigateToDICOMService();
            dicomPage.NavigateToDICOMServersSubTab();
        }

        [When(@"User deletes a DICOMweb server")]
        public void UserDeletesDicomwebServer()
        {
            dicomPage.DeleteServer();
        }

        [Then(@"Confirmation message is displayed successfully3")]
        public void ConfirmationMessageIsDisplayedSuccessfully3()
        {
            Assert.IsTrue(dicomPage.GetRemovalConfirmation().Contains(expectedMessage));
        }

    }
}

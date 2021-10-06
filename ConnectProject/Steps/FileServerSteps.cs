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
    public class FileServerSteps : BaseSteps
    {
        private DicomPage dicomPage;
        private HomePage homePage;
        private LoginPage loginPage;
        readonly string username = "acrconnect.testuser1@yahoo.com";
        readonly string password = "TEstaccount1";
        String serverName = "FileServer_" + new Faker().Name.FirstName();
        String expectedMessage = "DICOM/WebDICOM source server created successfully.";

        public FileServerSteps(IWebDriver webDriver, ScenarioContext scenarioContext, IRunData runData, PageObjectManager pageObjectManager) : base(webDriver, scenarioContext, runData, pageObjectManager)
        {
            loginPage = pageObjectManager.GetLoginPage();
            dicomPage = pageObjectManager.GetDicomPage();
            homePage = pageObjectManager.GetHomePage();
        }

        
        [Given(@"User navigates to Connect DICOM service")]
        public void UserNavigatesToConnectDICOMServive()
        {
            loginPage.SignIn(username,password);
            homePage.NavigateToDICOMService();
        }

        [Given(@"Clicks on Servers sub-tab")]
        public void ClicksOnServersSubTab()
        {
            dicomPage.NavigateToDICOMServersSubTab();
        }


        [When(@"User creates a new file server and saves it")]
        public void UserCreatesNewFileServerAndSavesIt()
        {
            dicomPage.CreateFileServer(serverName);
        }

        [Then(@"Confirmation message is displayed successfully")]
        public void ConfirmationMessageIsDisplayedSuccessfully()
        {
            Assert.AreEqual(expectedMessage, dicomPage.GetCreationConfirmationMessage());
        }




    }
}

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
    public class ModifyListenerSteps : BaseSteps
    {
        private DicomPage dicomPage;
        private HomePage homePage;
        private LoginPage loginPage;
        readonly string username = "acrconnect.testuser1@yahoo.com";
        readonly string password = "TEstaccount1";
        string expectedMessage = "Selected Listener modified successfully";

        public ModifyListenerSteps(IWebDriver webDriver, ScenarioContext scenarioContext, IRunData runData, PageObjectManager pageObjectManager) : base(webDriver, scenarioContext, runData, pageObjectManager)
        {
            loginPage = pageObjectManager.GetLoginPage();
            dicomPage = pageObjectManager.GetDicomPage();
            homePage = pageObjectManager.GetHomePage();
        }


        [Given(@"User navigates to Connect DICOM Listeners sub-tab2")]
        public void UserNavigatesToConnectDICOMListenersSubtab2()
        {
            loginPage.SignIn(username, password);
            homePage.NavigateToDICOMService();
        }

        [When(@"User modifies exisiting DICOM listener and saves it")]
        public void UserModifiesExistingDicomListenerAndSavesIt()
        {
            dicomPage.ModifyListener();
        }

        [Then(@"Confirmation message will be displayed successfully")]
        public void ConfirmationMessageWillBeDisplayedSuccessfully()
        {
            Assert.AreEqual(expectedMessage, dicomPage.GetModificationConfirmation());
        }


    }
}

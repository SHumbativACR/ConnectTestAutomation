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
    public class CreateListenerSteps : BaseSteps
    {
        private DicomPage dicomPage;
        private HomePage homePage;
        private LoginPage loginPage;
        readonly string username = "acrconnect.testuser1@yahoo.com";
        readonly string password = "TEstaccount1";
        string listenerName = "Listener_" + new Faker().Name.FirstName();
        string aet = new Faker().Name.LastName();
        string port = "9099";
        string expectedMessage = "Listener created successfully";

        public CreateListenerSteps(IWebDriver webDriver, ScenarioContext scenarioContext, IRunData runData, PageObjectManager pageObjectManager) : base(webDriver, scenarioContext, runData, pageObjectManager)
        {
            loginPage = pageObjectManager.GetLoginPage();
            dicomPage = pageObjectManager.GetDicomPage();
            homePage = pageObjectManager.GetHomePage();
        }


        [Given(@"User navigates to Connect DICOM Listeners sub-tab")]
        public void UserNavigatesToConnectDICOMListenersSubtab()
        {
            loginPage.SignIn(username, password);
            homePage.NavigateToDICOMService();
        }

        [When(@"User creates a new DICOM listener and saves it")]
        public void UserCreatesNewDicomListenerAndSavesIt()
        {
            dicomPage.CreateListener(listenerName, aet, port);
        }

        [Then(@"Confirmation message is displayed successfully5")]
        public void ConfirmationMessageIsDisplayedSuccessfully5()
        {
            Assert.AreEqual(expectedMessage, dicomPage.GetListenerConfirmation());
        }


    }
}

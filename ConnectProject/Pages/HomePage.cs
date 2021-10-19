using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace AutomationFramework.Pages
{
    public class HomePage : BasePage
    {
        public HomePage(IWebDriver webDriver) : base(webDriver) { }

        private readonly string URL = "https://connect-test.acr.org/";
        private readonly string URL2 = "https://connect-staging.acr.org/";
        private readonly string URL3 = "https://cdv-connectdeploy/";
        private readonly string HOME_PAGE_TITLE = "Home Page";
        private readonly string AILAB_PAGE_TITLE = "Home - AI-LAB";
        private readonly string DICOM_PAGE_TITLE = "DICOM";
        private readonly string DATA_MANGER_PAGE_TITLE = "Data Manager";

        // ========= Elements ========= //

        private readonly By serversTab = By.CssSelector("li:nth-of-type(2) > .nav-link");
        // Getting home ( login )
        private readonly By advancedButton = By.Id("details-button");
        private readonly By proceedLink = By.Id("proceed-link");
        private readonly By acrIdSignin = By.XPath("//*[text()='Sign in with ACR ID']");
        private readonly By usernameInput = By.Id("idp-discovery-username");
        private readonly By usernameInputTestEnv = By.CssSelector("input#idp-discovery-username");
        private readonly By nextButton = By.Id("idp-discovery-submit");
        private readonly By passwordInput = By.Id("okta-signin-password");
        private readonly By passwordInputTestEnv = By.CssSelector("input#okta-signin-password");
        private readonly By signinButton = By.Id("okta-signin-submit");

        // Request access flow Elements
        private readonly By yesButton = By.CssSelector("button#btn_YesRequest");
        private readonly By noButton = By.CssSelector("button#btn_NoRequest");
        private readonly By reasonForRequest = By.CssSelector("input#txt_reason");
        private readonly By requestSubmit = By.CssSelector("button#btn_RequestSubmit");
        private readonly By requestAccessModalText = By.XPath("(//div[@class='modal-body'])[1]");
        public string requestNotification;
        public string requestConfirmation;
        public string denialNotification;
        public string disabledNotification;

        // Home Page Icons
        private readonly By ailabLogo = By.XPath("//div/div/img[@alt='image']");
        private readonly By cirrLogo = By.XPath("(//a/div)[2]");
        private readonly By dataDanagerLogo = By.XPath("(//a/div)[3]");
        private readonly By dicomServiceLogo = By.XPath("(//a/div)[4]");
        private readonly By eventLoggerLogo = By.XPath("(//a/div)[5]");
        private readonly By masterIdIndexLogo = By.XPath("(//a/div)[6]");
        private readonly By userManagementLogo = By.XPath("(//a/div)[7]");
        private readonly By ailabHomepage = By.CssSelector(".col-md-12.mt-10 h1");
        private readonly By enterButton = By.CssSelector("//button[text()=' ENTER ' ]");
        private readonly By logoutButton = By.CssSelector("button#dropdownMenu2");
        private readonly By confirmLogout = By.CssSelector("[value]");


        // AI-LAB Side Tabs
        private readonly By annotateTab = By.XPath("//a[@href='Annotation/Index']/span[@class='site-menu-title']");
        private readonly By evaluateTab = By.XPath("//ul//a[@href='Evaluate/OnPrem']/span[@class='site-menu-title']");
        private readonly By createTab = By.XPath("//ul//a[@href='Create/TrainAndTest']");
        private readonly By runTab = By.XPath("//ul//a[@href='Run/OnPrem']/span[@class='site-menu-title']");


        // ===== Actions on Page ===== //

        /*
            protected void SwitchToTab(String tabTitle)
            {
                tabs = new ArrayList<String>(Driver.getWindowHandles());
                for (int i = 0; i < tabs.size(); i++)
                {
                    driver.switchTo().window(tabs.get(i));
                    String windowTitle = driver.getTitle();
                    if (windowTitle.equalsIgnoreCase(tabTitle))
                    {
                        break;
                    }
                }
            }

        */

        public void NavigateToDICOMService()
        {
            Click(dicomServiceLogo);
            Driver.SwitchTo().Window(Driver.WindowHandles[1]);
            Sleep(5);
        }

        public void NavigateToUserManagement()
        {
            Click(userManagementLogo);
      //    switchToTab("User Management");
            Sleep(1);
        }

        public void RequestAccess(String username, String password)
        {
            Click(acrIdSignin);
            Driver.FindElement(usernameInputTestEnv).SendKeys(username);
            Click(nextButton);
            Driver.FindElement(passwordInputTestEnv).SendKeys(password);
            Click(signinButton);
            WaitUntilElementVisible(yesButton);
            Click(yesButton);
            Driver.FindElement(reasonForRequest).SendKeys("TEST Request");
            Click(requestSubmit);
            Sleep(1);
        }

        public String GetRequestConfirmation()
        {
            return requestConfirmation = Driver.FindElement(By.XPath("/html//div[@id='div_reqSubmit']//a[@href='/External/Challenge?redirectUrl=%2F&provider=oidc']//small[@class='text-center text-danger']")).Text;
        }

        public void SignIn(String username, String password)
        {
            Click(acrIdSignin);
            Driver.FindElement(usernameInputTestEnv).SendKeys(username);
            Click(nextButton);
            Driver.FindElement(passwordInputTestEnv).SendKeys(password);
            Click(signinButton);
            Sleep(3);
        }

        public String GetDenialNotification()
        {
            return denialNotification = Driver.FindElement(By.XPath("//*[@class='text-center text-danger']")).Text;
        }

        public String GetDisabledNotification()
        {
            return disabledNotification = Driver.FindElement(By.XPath("//*[@class='text-center text-danger']")).Text;
        }


    }
}

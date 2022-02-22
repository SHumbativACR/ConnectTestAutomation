using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace AutomationFramework.Pages
{
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver webDriver) : base(webDriver) { }

        // ===== Elements ===== //

        private readonly By oktaSignInButton = By.XPath("//*[text()='Sign in with ACR ID']");
        private readonly By usernameInput = By.CssSelector("input#idp-discovery-username");
        private readonly By nextButton = By.Id("idp-discovery-submit");
        private readonly By passwordInput = By.CssSelector("input#okta-signin-password");
        private readonly By signInButton = By.Id("okta-signin-submit");
        private readonly By signOutButton = By.CssSelector("button#dropdownMenu2");
        private readonly By confirmLogout = By.CssSelector("[value]");
        private readonly By dataManagerLogo = By.XPath("(//a/div)[3]");


        // ===== Actions on Page ===== //

        public void SignIn(string username, string password)
        {
            Click(oktaSignInButton);
          //  WaitForPageToLoad();
            Driver.FindElement(usernameInput).SendKeys(username);
            Click(nextButton);
            Driver.FindElement(passwordInput).SendKeys(password);
            Click(signInButton);
            WaitUntilElementVisible(dataManagerLogo);
        }

        public string GetHomepageTitle() => Driver.Title;

        public string GetSplashPageTitle() => Driver.Title;

        public void SignOut()
        {
            Click(signOutButton);
            Click(confirmLogout);
        }

       



    }
}


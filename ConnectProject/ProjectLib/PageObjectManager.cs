using AutomationFramework.Pages;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace AutomationFramework.ProjectLib

{
    [Binding]
    public class PageObjectManager
    {
        private IWebDriver _driver { get; }  
        private LoginPage _loginPage;
        private LoginPage2 _loginPage2;


        public PageObjectManager(IWebDriver webDriver)
        {
            _driver = webDriver;
        }
       
        public LoginPage GetLoginPage() => _loginPage == null ? new LoginPage(_driver) : _loginPage;

        public LoginPage2 GetLoginPage2() => _loginPage2 == null ? new LoginPage2(_driver) : _loginPage2;
    }    
}

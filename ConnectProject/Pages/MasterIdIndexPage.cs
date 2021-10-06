using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace AutomationFramework.Pages
{
    public class MasterIdIndexPage : BasePage
    {

        public MasterIdIndexPage(IWebDriver webDriver) : base(webDriver) { }

        // ===== Elements ===== //
        private readonly By exportButton = By.XPath("button[title='Export all data to CSV'] > .mat-button-wrapper");
        private readonly By importButton = By.XPath("button[title='Import data from CSV file'] > .mat-button-wrapper");
        private readonly By backToHomeScreen = By.CssSelector(".navbar-link");












    }
}

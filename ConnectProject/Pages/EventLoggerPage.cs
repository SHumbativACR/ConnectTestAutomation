using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace AutomationFramework.Pages
{
    public class EventLoggerPage : BasePage
    {

        public EventLoggerPage(IWebDriver webDriver) : base(webDriver) { }


        // ====== Elements ====== //

        // View section Service Elements
        private readonly By allEvents = By.CssSelector(".text-light h6");
        private readonly By acrconnectEventLogger = By.CssSelector("a:nth-of-type(2) > div");
        private readonly By ailab = By.CssSelector("a:nth-of-type(3) > div");
        private readonly By dicomImagingService = By.CssSelector("a:nth-of-type(4) > div");
        private readonly By dataManager = By.CssSelector("a:nth-of-type(5) > div");
        private readonly By dicomService = By.CssSelector("a:nth-of-type(6) > div");
        private readonly By dicomAnonymizationService = By.CssSelector("a:nth-of-type(7) > div");
        private readonly By ailabMlpService = By.CssSelector("a:nth-of-type(8) > div");
        private readonly By masterIdIndexService = By.CssSelector("a:nth-of-type(9) > div");
        private readonly By ailabService = By.CssSelector("a:nth-of-type(10) > div");

        // Export Service Logs section Elements
        private readonly By selectAcrconnectAilabService = By.CssSelector("mat-option:nth-of-type(3) > .mat-option-text");
        private readonly By selectAcrconnectAilabUi = By.CssSelector("mat-option:nth-of-type(4) > .mat-option-text");
        private readonly By selectAcrconnectDataManagerService = By.CssSelector("mat-option:nth-of-type(5) > .mat-option-text");
        private readonly By selectAcrconnectDicomAnonymizationService = By.CssSelector("mat-option:nth-of-type(6) > .mat-option-text");
        private readonly By selectAcrconnectDicomImagingService = By.CssSelector("mat-option:nth-of-type(7) > .mat-option-text");
        private readonly By selectAcrconnectDicomService = By.CssSelector("mat-option:nth-of-type(8) > .mat-option-text");
        private readonly By selectAcrconnectHomepageService = By.CssSelector("mat-option:nth-of-type(9) > .mat-option-text");
        private readonly By selectAcrconnectMasterIdIndexService = By.CssSelector("mat-option:nth-of-type(10) > .mat-option-text");
        private readonly By selectTransientContainersService = By.CssSelector("mat-option:nth-of-type(11) > .mat-option-text");
        private readonly By emptyField = By.CssSelector("body > div:nth-child(6) > div:nth-of-type(1)");
        private readonly By exportButton = By.CssSelector(".btn.btn-primary.pull-right");
        private readonly By startDate = By.XPath("(//span[@class='mat-button-wrapper'])[1]");
        private readonly By endDate = By.XPath("(//span[@class='mat-button-wrapper'])[2]");
        private readonly By weeklyServiceLogStartDate = By.CssSelector("tr:nth-of-type(2) > td:nth-of-type(2) > .mat-calendar-body-cell-content");
        private readonly By weeklyServiceLogEndDate = By.CssSelector("tr:nth-of-type(2) > td:nth-of-type(6) > .mat-calendar-body-cell-content");





    }
}

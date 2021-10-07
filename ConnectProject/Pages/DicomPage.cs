using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;


namespace AutomationFramework.Pages
{
    public class DicomPage : BasePage
    {
        public DicomPage(IWebDriver webDriver) : base(webDriver) { }

        // ===== Elements ===== //

        String dicomwebURL = "http://dcm4chee-arc:8080/dcm4chee-arc/aets/DCM4CHEE/rs/";
        // Import Data & Annotations sub-tab Elements
        private readonly By importDataTab =By.XPath("//li/a[text()='Import data & annotations']");
        private readonly By dataSourceDropdown = By.XPath("//select[@ID='sever']");
        private readonly By dcm4cheeWeb = By.XPath("//option[text()='DCM4CHEE Web']");
        private readonly By dcm4cheeWebTestEnv = By.XPath("//option[text()='Local PACS (DICOMWEB)']");
        private readonly By chooseFileButton = By.XPath("//input");
        private readonly By fileDropArea = By.CssSelector(".upload_background");

        // Servers sub-tab Elements
        private readonly By serversTab = By.CssSelector("li:nth-of-type(2) > .nav-link");
        private readonly By createNewServer = By.CssSelector(".btn.btn-secondary.float-right");
        public String confirmationMessage;
        private readonly By serverNameField = By.CssSelector("#createModal [placeholder='Name']");
        private readonly By serverDropDown = By.XPath("(/html//select[@id='source_type'])[1]");
        private readonly By fileServer = By.XPath("//option[text()='File System']");
        private readonly By dicomWebServer = By.XPath("//option[text()='DICOMweb']");
        private readonly By hostIpField = By.CssSelector("#createModal [placeholder='Host\\/IP']");
        private readonly By acrDatasetPilot1File = By.CssSelector("(//*[text()='acr-dataset-pilot1'])[2]");
        private readonly By fileServerTestData = By.CssSelector("//*[text()='Breast density - 1000 studies']");
        private readonly By browseFile = By.CssSelector("#createModal [data-toggle]");
        private readonly By okButton = By.XPath("(//*[text()='OK'])[1]");
        private readonly By saveButton = By.XPath("(//*[text()='Save'])[1]");
        private readonly By verifyServerButton = By.CssSelector("tr:nth-of-type(1) > td:nth-of-type(4) > button:nth-of-type(1)");
        // Parent -- Following-sibling -- preceding-sibling VERIFY ->   //td[contains(text(),'bd')]/following-sibling::td/following-sibling::td/following-sibling::td//button[contains(text(),'Verify')]
        // Delete ->  //td[contains(text(),'bd')]/following-sibling::td/following-sibling::td/following-sibling::td//button[contains(text(),'Delete')]
        // ACREDIT UNITS ->   //a[contains(text(),'Unit# 04')]/parent::td//following-sibling::td[contains(text(),'Approved')]
        private readonly By deleteServer = By.XPath("(//td[contains(text(),'DICOMweb_')]/following-sibling::td)[3]/button[contains(text(),'Delete')]");
        private readonly By confirmDeletion = By.CssSelector(".modal-dialog.modal-dialog-centered.modal-sm > .modal-content .btn.btn-primary");
        private readonly By editServer = By.XPath("(//td[contains(text(),'TestServer')]/following-sibling::td)[3]/button[contains(text(),'Edit')]");
        private readonly By editServer2 = By.XPath("(//td[contains(text(),'TestServer')]/following-sibling::td)[3]/button[contains(text(),'Edit')]");
        private readonly By serverName = By.CssSelector("#editModal [placeholder='Name']");
        private readonly By saveModifications = By.CssSelector("div#editModal > div[role='document'] .btn.btn-primary");
        private readonly By serverConfirmationMessage = By.XPath("//span[text()='DICOM/WebDICOM source server created successfully.']");
        private readonly By serverRemovalConfirmationMessage = By.XPath("//span[contains(text(),'deleted successfully.')]");

        // Listener sub-tab Elements
        private readonly By listenerSubTab = By.CssSelector("li:nth-of-type(1) > .nav-link");
        private readonly By expandListener = By.CssSelector("mat-expansion-panel-header#mat-expansion-panel-header-0");
        private readonly By stopListener = By.CssSelector(".mat-button-wrapper");
        private readonly By listenerStoppedStatus = By.CssSelector(".text-danger");
        private readonly By listenerRunningStatus = By.CssSelector(".text-success");

        // Search & Retrieve sub-tab Elements
        private readonly By searchAndRetrieveSubTab = By.CssSelector("li:nth-of-type(3) > .nav-link");
        private readonly By serverDropDownSearchAndRetrieve = By.CssSelector("select#sever");
        private readonly By accessionNumberField = By.CssSelector("[class] [class='col-3']:nth-of-type(3) [type]");
        private readonly By searchButton = By.CssSelector(".float-right > .btn.btn-primary");
        private readonly By searchAndRetrieveResultConfirmation = By.CssSelector("snack-bar-container[role='status']  span");
        private readonly By selectAllSearchResult = By.CssSelector("th:nth-of-type(1) > input[type='checkbox']");
        private readonly By retrieveSearchResult = By.CssSelector("app-search-and-retrieve .row:nth-of-type(4) .btn-secondary.ng-star-inserted");
        private readonly By advancedToggle = By.CssSelector("//label[@for='customSwitch1']");
        private readonly By studyUidDropDown = By.CssSelector(".form-control.ng-pristine.ng-touched.ng-valid");
        private readonly By retrieveSearchResultAdvanced = By.CssSelector("div:nth-of-type(7) .btn.btn-secondary.ng-star-inserted");
        private readonly By retrievalConfirmation = By.XPath("//span[contains(text(),'100 studies are enqueued for retrieval.')]");

        // Retrieval Queue sub-tab Elements
        private readonly By retrievalQueue = By.CssSelector("li:nth-of-type(5) > .nav-link");
        private readonly By pageSeventh = By.CssSelector("li:nth-of-type(7) > .page-link");
        // Completed status -- Wait until 18332 then get status ->   //div[contains(text(),' c7df6b67-329d-4dbd-a896-094ce7719b7c ')]/parent::td/following-sibling::td/following-sibling::td/following-sibling::td/following-sibling::td/following-sibling::td//div[contains(text(),'Completed')]
        public String status1;
        private String getConfirmationText;

        // File upload map window
        private readonly By annotations = By.XPath("//span[text()='Select to map']");
        private readonly By annotatinosSelectAll = By.XPath("//div[text()='Select All']");
        private readonly By annotationsSelectBreastDensity = By.CssSelector(".item2  div");
        private readonly By createDatasetRadio = By.XPath("//span[text()='Create data set']");
        private readonly By datasetNameInput = By.XPath("//input[@name='createDataSetName']");
        private readonly By doneButton = By.XPath("//button[text()='Done ']");
        private readonly By datasetCreationConfirmation = By.CssSelector("snack-bar-container[role='status']  span");

        // Flash elements
        private readonly By datasetCreationComfirmation = By.CssSelector("snack-bar-container[role='status']  span");
        private readonly By studyRetrievalStatus = By.CssSelector("app-import .ng-star-inserted:nth-of-type(5) .float-right");
        private readonly By dicomServiceLogo = By.XPath("(//a/div)[4]");


        // ===== Actions on Page ===== //


        public void NavigateToDICOMServersSubTab()
        {
            Click(serversTab);
        }

        public void CreateFileServer(String fileServerName)
        {
            Click(createNewServer);
            Driver.FindElement(serverNameField).SendKeys(fileServerName);
            Click(serverDropDown);
            Click(fileServer);
            Click(browseFile);
            WaitUntilElementClickable(okButton);
            Click(okButton);
            WaitUntilElementVisible(saveButton);
            Click(saveButton);
            WaitUntilElementVisible(serverConfirmationMessage);
        }
       
        public String GetCreationConfirmationMessage()
        {
            return getConfirmationText = Driver.FindElement(serverConfirmationMessage).Text;
        }

        public void CreateDicomwebServer(String dicomwebServerName)
        {
            Click(createNewServer);
            Driver.FindElement(serverNameField).SendKeys(dicomwebServerName);
            Click(serverDropDown);
            Click(dicomWebServer);
            Driver.FindElement(hostIpField).SendKeys(dicomwebURL);
            Click(saveButton);
            WaitUntilElementVisible(serverConfirmationMessage);
        }

        public void DeleteServer()
        {
            Click(deleteServer);
            Sleep(1);
            Click(confirmDeletion);
            WaitUntilElementVisible(serverRemovalConfirmationMessage);
        }

        public String GetRemovalConfirmation()
        {
            return confirmationMessage = Driver.FindElement(serverRemovalConfirmationMessage).Text;
        }



    }
}

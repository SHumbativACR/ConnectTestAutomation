using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace AutomationFramework.Pages
{
    public class DataManagerPage : BasePage
    {
        public DataManagerPage(IWebDriver webDriver) : base(webDriver) { }

        // ===== Elements ===== //

        public String actualDataCount;

        // Datasets section Elements
        private readonly By datasetsSection = By.CssSelector("[href='\\#dataSetMenu']");
        private readonly By searchInput = By.Id("datasetSearch");
        private readonly By selectAllButton = By.CssSelector(".dataset-actions > button:nth-of-type(2)");
        public String actual_data_count;
        public String message;
        private readonly By noRecordsFoundMessage = By.CssSelector(".span_warning_header_searchResult");
        private readonly By deleteConfirmation = By.CssSelector("#deleteConfirmModal [class] [data-dismiss='modal']:nth-child(2)");
        private readonly By copyButton = By.CssSelector("button[title='Copy selected data objects']");
        private readonly By createNewCopyDataset = By.CssSelector("input[name='copyDataSetName']");
        private readonly By confirmCopy = By.CssSelector("#copyDatasetModal .btn_group_dataSet [data-dismiss='modal']:nth-of-type(1)");
        private readonly By searchBar = By.CssSelector("input#datasetSearch");
        private readonly By datasetData = By.CssSelector(".dataSetListingParentDiv .col-cell-data-wide:nth-of-type(1) .row [class='col-sm-6']:nth-of-type(2)");
        private readonly By copyStudiesButton = By.CssSelector("input[name='includeTag']");
        private readonly By listView = By.CssSelector("button#toggleListView > i[title='list view']");
        private readonly By firstDataset = By.CssSelector("div:nth-of-type(1) > .chk_dataset.ng-pristine.ng-untouched.ng-valid");
        private readonly By confirmationMessage = By.CssSelector("div[role='alertdialog']");
        private readonly By anonymizeButton = By.CssSelector("button[title='Anonymize selected data objects']");
        private readonly By selectAnonymizationProfileDropDown = By.XPath("//div[@id='anonymizeDataModal']/div[@class='modal-dialog modal-lg']/div[@class='modal-content']/div[@class='modal-body']/div[@class='container-fluid']//select");
        private readonly By outputAnonymizationDataset = By.CssSelector("input[role='combobox']");
        private readonly By confirmAnonymizationButton = By.CssSelector("#anonymizeDataModal .btn_group_dataSet [data-dismiss='modal']:nth-of-type(1)");
        private readonly By anonymizationConfirmationMessage = By.CssSelector("div:nth-of-type(3) > div[role='alertdialog']");
        private readonly By anonConfirmation = By.CssSelector("div[role='alertdialog']");
        private readonly By emptySpot = By.CssSelector("div#anonymizeDataModal > .modal-dialog.modal-lg .container-fluid > div:nth-of-type(3)");
        private readonly By editDatasetNameField = By.CssSelector(".ng-pristine.ng-untouched.ng-valid input[name='name']");
        private readonly By editDatasetSaveButton = By.XPath("//div[@id='editDatasetModal']/div[@class='modal-dialog modal-dialog-centered']//div[@class='modal-body']//form//button[@class='btn btn-primary btn_saveDataSet']");
        public String editedDataset;
        private readonly By datasetUpdateNotification = By.CssSelector("div[role='alertdialog']");


        // Dataset Edit
        private readonly By editDataset = By.CssSelector(".dataset-actions > button:nth-of-type(1)");
        private readonly By editDatasetNameInput = By.XPath("(//div[@class='col-sm-12']/div[@class='form-group']/input)[1]");
        private readonly By editSave = By.CssSelector("[aria-modal] [type='submit']");


        // Data section Elements
        private readonly By dataSection = By.CssSelector("[href='\\#home']");
        private readonly By selectAllButtonDataSection = By.XPath("//*[text()='Select All']");
        public String actual_data_count_data_section;
        private readonly By createNewDatasetFromDataSection = By.CssSelector(".pull-right > button:nth-of-type(2)");
        private readonly By addToExistingDataset = By.XPath("//div[@id='home']/home-selector/div[@class='card']/div[@class='card-body']//div[@class='pull-right']/button[5]");
        private readonly By editDsDataSection = By.XPath("//span[contains(text(),'Edit_DS')]");
        private readonly By confirmAddToExistingDataset = By.CssSelector(".btn.btn-addtodataset");
        private readonly By datasetNameField = By.CssSelector("input#name");
        private readonly By saveButton = By.CssSelector("#createModel [type='submit']");
        private readonly By firstDataInDataSection = By.CssSelector("home-selector > .card .div_listing.row > div:nth-of-type(1)");
        private readonly By secondDataInDataSection = By.CssSelector("home-selector > .card .div_listing.row > div:nth-of-type(2)");
        private readonly By thirdDataInDataSection = By.CssSelector("home-selector > .card .div_listing.row > div:nth-of-type(3)");
        private readonly By fourthDataInDataSection = By.CssSelector("home-selector > .card .div_listing.row > div:nth-of-type(4)");
        private readonly By fifthDataInDataSection = By.CssSelector("home-selector > .card .div_listing.row > div:nth-of-type(5)");


        // ===== Actions on Page ===== //






    }
}

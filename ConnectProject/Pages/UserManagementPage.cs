using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace AutomationFramework.Pages
{
    public class UserManagementPage : BasePage
    {

        public UserManagementPage(IWebDriver webDriver) : base(webDriver) { }

        // ===== Elements ===== //

        // User Management service Elements
        private readonly By inviteUserButton = By.CssSelector(".btn.btn-outline-primary.my-2.my-sm-0");
        private readonly By emailAddress = By.CssSelector("nput#userEmail");
        private readonly By administratorRole = By.XPath("/html//div[@id='inviteUser']/div[@role='document']/div[@class='modal-content']//form//input[@name='adminRole']");
        private readonly By platformUserRole = By.XPath("/html//div[@id='inviteUser']/div[@role='document']/div[@class='modal-content']//form//div[@class='col-md-4']/div[2]/input[@name='userRole']");
        private readonly By appUserRole = By.XPath("/html//div[@id='inviteUser']/div[@role='document']/div[@class='modal-content']//form//div[@class='col-md-4']/div[3]/input[@name='userRole']");
        private readonly By doneButton = By.CssSelector("app-user-list [role='dialog']:nth-child(3) .modal-footer [data-dismiss]");
        private readonly By closeWindow = By.CssSelector("button#closebutton > span");
        private readonly By confirmInvitation = By.CssSelector("div#inviteUser > div[role='document'] .btn.btn-primary");
        private readonly By copyToClipboard = By.CssSelector("div#inviteUser > div[role='document'] .btn.btn-primary");
        private readonly By notifyUserWindowAlert = By.CssSelector("div#inviteUser > div[role='document'] div[role='alert']");
        private readonly By editRole = By.XPath("(//td[@title='acrconnect.testuser12@gmail.com']/following-sibling::td)[4]/*[@title='Edit user']");
        private readonly By editRoleRegression = By.XPath("(//td[@title='acrconnect.testuser14@gmail.com']/following-sibling::td)[4]/*[@title='Edit user']");
        private readonly By resendInvitation = By.XPath("//mat-icon[@aria-label='Resend Invite']");
        private readonly By enableDisableToggle = By.XPath("//div[@class='mat-slide-toggle-bar mat-slide-toggle-bar-no-side-margin']");
        private readonly By enableDisableCheckbox = By.CssSelector("mat-checkbox[name='disableUser'] > .mat-checkbox-layout > .mat-checkbox-inner-container");
        private readonly By updateButton = By.CssSelector("div#editUser > div[role='document'] .btn.btn-primary");
        private readonly By updateNotification = By.CssSelector("snack-bar-container[role='status']  span");
        private readonly By activeStatus = By.XPath("//td[contains(text(),'Active')]");
        private readonly By invitedStatus = By.XPath("//td[contains(text(),'Invited')]");
        private readonly By disabledStatus = By.XPath("//td[contains(text(),'Disabled')]");
        private readonly By userNameSignout = By.CssSelector("button#dropdownMenu2");
        private readonly By signoutButton = By.CssSelector("[value='Sign Out']");

        // Request access flow Elements
        private readonly By yesButton = By.CssSelector("button#btn_YesRequest");
        private readonly By noButton = By.CssSelector("button#btn_NoRequest");
        private readonly By reasonForRequest = By.CssSelector("input#txt_reason");
        private readonly By requestSubmit = By.CssSelector("button#btn_RequestSubmit");
        private readonly By requestAccessModalText = By.XPath("(//div[@class='modal-body'])[1]");
        private readonly By oktaSignInButton = By.XPath("//*[text()='Sign in with ACR ID']");


        // Approve/Deny access requests Elements
        private readonly By requested_status = By.XPath("//td[contains(text(),'Requested')]");
        private readonly By rejectApproveAccessIcon = By.XPath("(//td[@title='acrconnect.testuser22@yahoo.com']/following-sibling::td)[4]/*[@title='Reject/Approve Access Request']");
        private readonly By cancelButton = By.CssSelector(".modal-footer > button:nth-of-type(3)");
        private readonly By denyButton = By.CssSelector("div#editUser > div[role='document']  .modal-footer > button:nth-of-type(2)");
        private readonly By approveButton = By.CssSelector("div#editUser > div[role='document'] .btn.btn-primary");
        private readonly By assignAdministratorRole = By.CssSelector("div#editUser > div[role='document'] > .modal-content .ng-pristine.ng-untouched.ng-valid input[name='adminRole']");
        private readonly By assignPlatformUserRole = By.CssSelector("div#editUser > div[role='document'] > .modal-content .ng-pristine.ng-untouched.ng-valid  .col-md-4 > div:nth-of-type(2) > input[name='userRole']");
        private readonly By assignAppUserRole = By.CssSelector("div#editUser > div[role='document'] > .modal-content .ng-pristine.ng-untouched.ng-valid  .col-md-4 > div:nth-of-type(3) > input[name='userRole']");
        private readonly By ailabAppCheckbox = By.XPath("/html//div[@id='editUser']/div[@role='document']//form/div[7]/div[@class='col-md-12']/div[1]/mat-checkbox/label[@class='mat-checkbox-layout']/div[@class='mat-checkbox-inner-container']");
        private readonly By selectAilabApp = By.CssSelector("div#editUser > div[role='document'] .ng-pristine.ng-untouched.ng-valid .example-margin.mat-accent.mat-checkbox.ng-pristine.ng-untouched.ng-valid > .mat-checkbox-layout > .mat-checkbox-inner-container");


        // ===== Actions on Page ===== //

        public void DenyAccessRequest()
        {
            Click(rejectApproveAccessIcon);
            Sleep(2);
            Click(denyButton);
            Sleep(2);
            Click(closeWindow);
            Click(userNameSignout);
            Click(signoutButton);
            WaitUntilElementVisible(oktaSignInButton);
        }

        public void ApproveAccessRequest()
        {
            Click(rejectApproveAccessIcon);
            Sleep(2);
            Click(assignPlatformUserRole);
            Click(approveButton);
            Sleep(2);
            Click(doneButton);
            Click(userNameSignout);
            Click(signoutButton);
            WaitUntilElementVisible(oktaSignInButton);
        }

        public void EnableDisableUser()
        {
            Click(editRole);
            Click(enableDisableCheckbox);
            Sleep(2);
            Click(updateButton);
            //Click(updateNotification);
            Sleep(10);
            Click(userNameSignout);
            Click(signoutButton);
            WaitUntilElementVisible(oktaSignInButton);
        }


    }
}

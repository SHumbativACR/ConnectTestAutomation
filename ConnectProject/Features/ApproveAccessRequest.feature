Feature: ApproveAccessRequest
	Verifying if admin user is able to approve access requests to ACR Connect

@SmokeTest
@test-ApproveAccessRequestTest
Scenario: Verify that admin can approve access request
	Given Administrator navigates to User Management service
	And Approves access request
	When Approved user tries to sign in to Connect
	Then User lands on Connect homepage and Page Title is Home Page
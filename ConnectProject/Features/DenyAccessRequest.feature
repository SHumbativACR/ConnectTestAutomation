Feature: ACR DenyAccessRequest
	Verifying if admin user is able to deny access requests to ACR Connect

@SmokeTest
@test-DenyAccessRequestTest
Scenario: Verify that admin can deny access request
	Given Administrator navigates to User Management service
	And Denies access request
	When Rejected user tries to sign in to Connect
	Then User is notified that their request was denied
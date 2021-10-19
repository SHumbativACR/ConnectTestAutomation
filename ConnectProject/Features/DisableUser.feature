Feature: DisableUser
	Verifying if administrator is able to disable platform user role

@SmokeTest
@test-DisableUserTest
Scenario: Verify that administrator can disable platform user
	Given Administrator navigates to User Management service
	And Disables platform user's role
	When Disabled user tries to sign in to Connect
	Then User is notified that their account has been disabled
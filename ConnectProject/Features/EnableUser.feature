Feature: EnableUser
	Verifying if administrator is able to enable platform user role

@SmokeTest
@test-EnableUserTest
Scenario: Verify that administrator can enable platform user
	Given Administrator navigates to User Management service
	And Enables platform user's role
	When Enabled user tries to sign in to Connect
	Then User lands on Connect homepage and Page Title is Home Page
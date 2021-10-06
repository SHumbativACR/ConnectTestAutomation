Feature: ACR Connect Login
	Verifying if user can sign in to Connect successfully with valid credentials

@SmokeTest @US3009 @TC0845
@test-loginTest
Scenario: Verify user is able to sign in successfully and Page title is 'Home Page'
	Given User navigates to Connect test environment Login Page
	When User clicks on Sign in button and enters a valid username and password
	Then User lands on Connect homepage and Page Title is Home Page
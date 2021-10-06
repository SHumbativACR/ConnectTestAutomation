Feature: ACR Connect Logout
	Verifying if user can sign out Connect successfully

@SmokeTest
@test-LogoutTest
Scenario: Verify that user is able to sign out successfully and Page title is 'ACR Connect'
	Given User is on Connect homepage
	When User clicks on sign out button and confirms signing out
	Then User lands on Connect Splash page and page title is ACR Connect
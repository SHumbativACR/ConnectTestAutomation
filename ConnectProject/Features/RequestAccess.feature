Feature: RequestAccess
	Verifying user is able to request an access to ACR Connect

@SmokeTest
@test-RequestAccessTest
Scenario: Verify that user can request access to Connect
	Given User requests access to Connect
	Then Confirmation message is displayed successfully4
Feature: FileServer
	Verifying if user is able to create a file server

@SmokeTest
@test-FileServerTest
Scenario: Verify user is able to create a file server and confirmation message is displayed once the server is created
	Given User navigates to Connect DICOM service
	And Clicks on Servers sub-tab
	When User creates a new file server and saves it
	Then Confirmation message is displayed successfully
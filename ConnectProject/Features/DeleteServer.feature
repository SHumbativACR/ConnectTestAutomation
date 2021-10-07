Feature: DeleteServer
	Verifying if user is able to delete a DICOM server

@SmokeTest
@test-FileServerTest
Scenario: Verify user is able to delete a server and confirmation message is displayed once the server is deleted
	Given User navigates to Connect DICOM service and clicks on Servers sub-tab
	When User deletes a DICOMweb server
	Then Confirmation message is displayed successfully3
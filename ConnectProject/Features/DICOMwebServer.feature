Feature: ACR Connect DICOMwebServer
	Verifying if user is able to create a DICOMweb server

@SmokeTest
@test-DicomServerTest
Scenario: Verify user is able to create a DICOMweb server and confirmation message is displayed once the server is created
	Given User navigates to Connect DICOM service and clicks on Servers sub-tab
	When User creates a new DICOMweb server and saves it
	Then Confirmation message is displayed successfully2
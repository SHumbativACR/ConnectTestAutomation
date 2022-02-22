Feature: ACR CreateListener
	Verifying if user is able to create a DICOM listener

@SmokeTest
@test-DicomListenerTest
Scenario: Verify user is able to create a DICOM listener and confirmation message is displayed once the listener is created
	Given User navigates to Connect DICOM Listeners sub-tab
	When User creates a new DICOM listener and saves it
	Then Confirmation message is displayed successfully5
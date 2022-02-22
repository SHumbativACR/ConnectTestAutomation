Feature: DeleteListener
	Verifying if user is able to delete existing DICOM listener

@SmokeTest
@test-DeleteListenerTest
Scenario: Verify user can delete existing DICOM listener and confirmation message is displayed once the listener is deleted
	Given User navigates to Connect DICOM Listeners sub-tab3
	When User deletes exisiting DICOM listener
	Then Notification is displayed successfully
Feature: AssignEmptyDsToListener
	Verifying if user is able to assign empty dataset to DICOM listener

@SmokeTest
@test-AssignDatasetTest
Scenario: Verify user is able to assign empty dataset to DICOM listener
	Given User navigates to Data section in Data Manager service
	And Creates empty dataset
	And User navigates to DICOM Listeners page
	When User creates a listener and assings empty dataset to the listener
	Then Confirmation message will be displayed successfully2
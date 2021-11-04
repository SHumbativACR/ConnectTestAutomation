Feature: SelectAll
	Verifying if user is able to select all the studies in dataset

@SmokeTest
@test-SelectAllTest
Scenario: Verify that user can select all the studies in a dataset
	Given User navigates to DICOM service Import data and annotations sub-tab
	And Imports dataset and navigates to Data Manager service
	When User selects that dataset and clicks on select all button
	Then The result should match the expected study count
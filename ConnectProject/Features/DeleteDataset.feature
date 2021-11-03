Feature: DeleteDataset
	Verifying if user can delete dataset from Data Manager service

@SmokeTest
@test-DeleteDatasetTest
Scenario: Verify that user can delete dataset from DM service
	Given User imports a dataset to Data Manager service
	And Navigates to Data Manager and selects the imported dataset
	When User deletes selected dataset
	Then No records found message is displayed when user searches that dataset
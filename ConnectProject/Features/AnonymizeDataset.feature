Feature: AnonymizeDataset
	Verifying if user is able to anonymize dataset

@SmokeTest
@test-AnonymizeDatasetTest
Scenario: Verify that user can anonymize dataset
	Given User navigates to DICOM service and imports a breast density dataset
	And Navigates to Data Manager service and selects the imported dataset
	When User anonymizes the dataset to a new dataset
	Then Anonymized dataset is created and all the studies are displayed correctly
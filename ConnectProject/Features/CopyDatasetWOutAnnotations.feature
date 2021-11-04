Feature: CopyDatasetWOutAnnotations
	Verifying if user is able to copy studies to a new dataset without annotations

@SmokeTest
@test-CopyDatasetWOutAnnotationsTest
Scenario: Verify that user can copy data without annotations
	Given User navigates to DICOM service and imports a dataset
	And User navigates to Data Manager service and selects a newly created dataset from the list
	And User copy dataset to a new dataset without annotations
	When User searches and selects new created dataset
	Then Newly created dataset is displayed and all the studies are present accurately
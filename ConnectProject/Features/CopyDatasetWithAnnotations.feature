Feature: CopyDatasetWithAnnotations
	Verifying if user is able to copy studies to a new dataset with annotations

@SmokeTest
@test-CopyDatasetWOutAnnotationsTest
Scenario: Verify that user can copy data with annotations
	Given User navigates to DICOM service and imports a dataset2
	And User navigates to Data Manager service and selects a newly created dataset from the list2
	And User copy dataset to a new dataset with annotations
	When User searches and selects new created dataset2
	Then Newly created dataset is displayed and all the studies are present accurately2